using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace TShirtOrders
{
    public class TShirt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TShirtSize { get; set; }
        public DateTime DateOfOrder { get; set; }
        public string TShirtColor { get; set; }
        public string ShippingAddress { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public Location DeviceLocation { get; internal set; }
    }
}
