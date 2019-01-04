using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using MvvmCross.Core.ViewModels;
using GoodsCatalog.Core.Model;
using System.Collections.Generic;
using System.Diagnostics;

namespace GoodsCatalog.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string api = "https://webapi20190101060659.azurewebsites.net/product/getcatalog";

        private static ObservableCollection<Catalog> catalogList;

        public ObservableCollection<Catalog> CatalogList
        {
            get { return catalogList; }
            set
            {
                catalogList = value;
                RaisePropertyChanged(() => CatalogList);
            }
        }


        public override async Task Initialize()
        {
            await base.Initialize();
            await InitDataAsync();
        }

        public async Task InitDataAsync()
        {

            CatalogList = await GetDataAsync();

        }

        public async Task<ObservableCollection<Catalog>> GetDataAsync()
        {
            var list = new ObservableCollection<Catalog>();
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(api);
            try
            {
                var items = JsonConvert.DeserializeObject<List<Catalog>>(json);
                foreach (var item in items)
                {
                    var catalogitem = new Catalog
                    {
                        Price = Convert.ToDecimal(item.Price),
                        Name = item.Name,
                        PhotoUrl = item.PhotoUrl
                    };

                    list.Add(catalogitem);
                }
            }

            catch (Exception exception)
            {
                Debug.WriteLine("Exception Message: " + exception.Message);
            }

            return list;
        }
    }
}
