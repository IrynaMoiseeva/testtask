using System.Collections.Generic;

namespace GoodsCatalog.Core.Model
{
    public class BuyItNowPrice
    {
        // public string __invalid_name__@currencyId { get; set; }
        public string __value__ { get; set; }
    }

    public class ShippingCost
    {
        // public string __invalid_name__@currencyId { get; set; }
        //public string __value__ { get; set; }
    }

    public class Item
    {
        public string itemId { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string viewItemURL { get; set; }
        public string globalId { get; set; }
        public string timeLeft { get; set; }
        public string primaryCategoryId { get; set; }
        public string primaryCategoryName { get; set; }
        public string country { get; set; }
        public string imageURL { get; set; }
        public string shippingType { get; set; }
        public BuyItNowPrice buyItNowPrice { get; set; }
        //public ShippingCost shippingCost { get; set; }
        public string watchCount { get; set; }
    }

    public class ItemRecommendations
    {
        public List<Item> item { get; set; }
    }

    public class GetMostWatchedItemsResponse
    {
        public string ack { get; set; }
        public string version { get; set; }
        public string timestamp { get; set; }
        public ItemRecommendations itemRecommendations { get; set; }
    }

    public class RootObject
    {
        public GetMostWatchedItemsResponse getMostWatchedItemsResponse { get; set; }
    }
}
