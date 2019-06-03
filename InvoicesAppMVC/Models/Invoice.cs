namespace InvoicesAppMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Invoice
    {
        [DisplayName("Id")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DisplayName("Recipient")]
        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [DisplayName("Paid")]
        [JsonProperty("paid")]
        public bool Paid { get; set; }

        [DisplayName("Items")]
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        public Invoice()
        {
            Items = new List<Item>();
        }
    }
    public partial class Item
    {
        [DisplayName("Item ID")]
        [JsonProperty("itemId")]
        public uint ItemId { get; set; }

        [DisplayName("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DisplayName("Amount")]
        [JsonProperty("amount")]
        public uint Amount { get; set; }

        [DisplayName("Price")]
        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
