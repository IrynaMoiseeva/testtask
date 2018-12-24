using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Core.DataBase;
using GoodsCatalog.Core.Model;

namespace GoodsCatalog.Core.Services
{
    public interface IPlatformService
    {
        string DestinationPath { get; }
    }
}
