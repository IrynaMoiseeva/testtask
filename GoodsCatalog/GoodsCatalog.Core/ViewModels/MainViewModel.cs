using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using MvvmCross.Core.ViewModels;
using GoodsCatalog.Core.Model;
using GoodsCatalog.Core.Repositories;

namespace GoodsCatalog.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public ICatalogRepository localCatalogRepository;

        const string MyKey = "moiseeva-GoodsCat-PRD-b60b1f533-6a22bdcd";

        private string apiebay = "https://svcs.ebay.com/MerchandisingService?OPERATION-NAME=getMostWatchedItems&SERVICE-NAME=MerchandisingService&SERVICE-VERSION=1.5.0&RESPONSE-DATA-FORMAT=JSON"
            + "&CONSUMER-ID=" + MyKey;

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

        public MainViewModel(ICatalogRepository localCatalogRepository)
        {
            this.localCatalogRepository = localCatalogRepository;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await InitDataAsync();
        }

        public async Task InitDataAsync()
        {
            /* Get data from ebay api and insert to the table 
                        
               await localCatalogRepository.DropTable();
               await localCatalogRepository.CreateTable();
               CatalogList = await GetDataAsync();
               var e = await localCatalogRepository.InsertAll(CatalogList);
                           
            */

            /* Get data from DB */
            CatalogList = new ObservableCollection<Catalog>();
            var list = await localCatalogRepository.GetCatalog();
            foreach (var item in list)
            {
                CatalogList.Add(item);
            }

        }

        public async Task<ObservableCollection<Catalog>> GetDataAsync()
        {
            var list = new ObservableCollection<Catalog>();
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiebay);
            try
            {
                var response = JsonConvert.DeserializeObject<RootObject>(json);

                var items = response.getMostWatchedItemsResponse.itemRecommendations;


                foreach (var item in items.item)
                {
                    var catalogitem = new Catalog
                    {
                        Price = Convert.ToDouble(item.buyItNowPrice.__value__),
                        Name = item.title,
                        PhotoUrl = item.imageURL
                    };
                    list.Add(catalogitem);
                }

            }

            catch (Exception exception)
            {
            }

            return list;
        }
    }
}
