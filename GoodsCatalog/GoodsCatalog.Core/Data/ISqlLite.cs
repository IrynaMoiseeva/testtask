using Autofac;
using GoodsCatalog.Core.Module;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodsCatalog.Core.Data
{
    public class Bootstarpper
    {
        public IContainer Build(Dictionary<Type, Type> mappedtypes)
        {
            var cb = new ContainerBuilder();
            cb.RegisterModule<MyModule>();
            if (mappedtypes != null && mappedtypes.Any())
            {
                cb.RegisterModule(new MappedTypeModule(mappedtypes));
            }

            return cb.Build();
        }
    }
}