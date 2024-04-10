﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public interface IMapTo<T>
    {
         void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
