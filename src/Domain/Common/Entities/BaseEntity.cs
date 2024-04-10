﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
