using System;
using System.Collections.Generic;
using Autofac;

namespace GoodsCatalog.Core.Module
{
    public class MappedTypeModule : Autofac.Module
    {
        private Dictionary<Type, Type> _mappedtypes;

        public MappedTypeModule(Dictionary<Type, Type> mappedtypes)
        {
            _mappedtypes = mappedtypes;
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var mappedtype in _mappedtypes)
            {
                builder.RegisterType(mappedtype.Key).As(mappedtype.Value);
            }
        }
    }
}
