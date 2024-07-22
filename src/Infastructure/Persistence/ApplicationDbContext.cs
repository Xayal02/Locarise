using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common.Entities;
using Domain.Common.Interfaces;
using Domain.Entities.Login;
using Domain.Entities.AboutUs;
using Domain.Entities.Services;
using Domain.Entities.HomePage;
using Domain.Entities.ContactUs;

namespace Infastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(ApplicationDbContext)
                                                                                 .GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ITracked>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        SetCreationAuditProperties(entry);
                        break;
                    case EntityState.Modified:
                        SetModificationAuditProperties(entry);
                        break;
                    case EntityState.Deleted:
                        CancelDeletionForSoftDelete(entry);
                        SetDeletionAuditProperties(entry);
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType });
            }
        }

        #region Configure Global Filters

        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType) where TEntity : class
        {
            if (ShouldFilterEntity<TEntity>(entityType))
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return false;
        }

        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>() where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted;
                expression = softDeleteFilter;
            }

            return expression;
        }

        #endregion

        #region Configure Audit Properties

        protected virtual void SetCreationAuditProperties(EntityEntry entry)
        {
            if (!(entry.Entity is IHasCreationTime hasCreationTimeEntity)) return;

            if (hasCreationTimeEntity.CreatedDate == default)
            {
                hasCreationTimeEntity.CreatedDate = DateTime.Now;
            }

            if (!(entry.Entity is IHasCreatedUser creationAuditedEntity)) return;

            if (creationAuditedEntity.CreatedUserId != null)
            {
                //CreatedUserId is already set
                return;
            }

            creationAuditedEntity.CreatedUserId = _currentUserService.UserId;
        }

        protected virtual void SetModificationAuditProperties(EntityEntry entry)
        {
            if (!(entry.Entity is IHasUpdatedTime hasModificationTimeEntity)) return;

            if (hasModificationTimeEntity.UpdatedDate == default)
            {
                hasModificationTimeEntity.UpdatedDate = DateTime.Now;
            }

            if (!(entry.Entity is IHasUpdatedUser modificationAuditedEntity)) return;

            if (modificationAuditedEntity.UpdatedUserId != null)
            {

                return;
            }

            modificationAuditedEntity.UpdatedUserId = _currentUserService.UserId;
        }

        protected virtual void SetDeletionAuditProperties(EntityEntry entry)
        {

            if (!(entry.Entity is IHasDeletedTime hasDeletionTimeEntity)) return;

            if (hasDeletionTimeEntity.DeletedDate == default)
            {
                hasDeletionTimeEntity.DeletedDate = DateTime.Now;
            }

            if (!(entry.Entity is IHasDeletedUser deletionAuditedEntity)) return;

            deletionAuditedEntity.DeletedUserId = _currentUserService.UserId;
            deletionAuditedEntity.DeletedDate = DateTime.Now;
        }

        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
            {
                return;
            }

            entry.Reload();
            entry.State = EntityState.Modified;
            ((ISoftDelete)entry.Entity).IsDeleted = true;
        }

        #endregion
    }
}
