using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Entities
{
    public interface ITracked
    {

    }

    public interface IHasCreationTime : ITracked
    {
        DateTime? CreatedDate { get; set; }
    }

    public interface IHasCreatedUser : IHasCreationTime
    {
        long? CreatedUserId { get; set; }
    }

    public interface IHasUpdatedTime : ITracked
    {
        DateTime? UpdatedDate { get; set; }
    }

    public interface IHasUpdatedUser : IHasUpdatedTime
    {
        long? UpdatedUserId { get; set; }
    }

    public interface IHasDeletedTime : ITracked
    {
        DateTime? DeletedDate { get; set; }
    }

    public interface IHasDeletedUser : IHasDeletedTime
    {
        long? DeletedUserId { get; set; }
    }
}
