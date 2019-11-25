using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using Xamarin.Essentials;
//sing Geocoding;
//using Geocoding.Google;

namespace TShirtOrders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShirtOrders : ContentPage
    {
        public List<TShirt> orders { get; set; }
        public ShirtOrders()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var tshirts = App.Database;

            orders = await tshirts.GetTShirtOrder();
            BindingContext = this;

            var connectivity = Connectivity.NetworkAccess;

            if(connectivity == NetworkAccess.Internet)
            {
                await TextToSpeech.SpeakAsync("Oh yeah we finally have internet");
            }
        }

        private async void PostBtn_Clicked(object sender, EventArgs e)
        {
            var tshirtData = App.Database;

             orders = await tshirtData.GetUnSubmittedOrders();
            var itemNumber = orders.Count - 1;
         
           
            var trip = orders[itemNumber].Status;


            var ordersToSubmit = orders.Select(x => new TShirt() { Image = x.Image, Name = x.Name, DateOfOrder = x.DateOfOrder, Gender = x.Gender, ShippingAddress = x.ShippingAddress, TShirtColor = x.TShirtColor, TShirtSize = x.TShirtSize });

            var json = JsonConvert.SerializeObject(ordersToSubmit);

            var http = new HttpClient();

            var uri = "http://10.0.2.2:5000/tshirt";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var post = await http.PostAsync(uri, content);

            // loop the orders  and channge the status
            // call the update method
             
            await DisplayAlert("Message", post.ReasonPhrase, "Cool");
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var x = App.Database;

            orders = await x.GetUnSubmittedOrders();

            foreach(var order in orders)
            {
                order.Status = true;

                await x.UpDateTShirtOrder(order);
            }
        }

        private async void MapBtn_Clicked(object sender, EventArgs e)
        {
            var tshirtInfo = App.Database;

            orders = await tshirtInfo.GetTShirtOrder();

            var getAddress = string.Empty;


            foreach(var eachOrder in orders)
            {
                getAddress = eachOrder.ShippingAddress;
            }


            var geocoder = await Geocoding.GetLocationsAsync(getAddress);

            
            await Map.OpenAsync(geocoder.First());
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
           


        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;

            var del = item.CommandParameter as TShirt;

            App.Database.DeleteTShirtOrder(del);
        }

       
    }
}
