using System;

namespace GoodsCatalog.Core.Services.Abstract
{
    public abstract class PlatformService : IPlatformService
    {
        string IPlatformService.DestinationPath { get; }

        public abstract string GetPlatform();
    }
}
