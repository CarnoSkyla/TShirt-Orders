using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.TextToSpeech.Abstractions;
using Xamarin.Essentials;

namespace TShirtOrders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class Page1 : ContentPage
    {
        public IList<TShirtStockItem> StockItems { get; private set; }
        public Page1()
        {
            InitializeComponent();

           
        }

        protected async override void OnAppearing()
        {
            var db = App.Database;

            StockItems = await db.GetShirtStockItems();

            BindingContext = this;
        }


        private async void Submit_Clicked(object sender, EventArgs e)
        {

             await Navigation.PushAsync(new MainPage());


             await TextToSpeech.SpeakAsync("Your order has been submitted");


        }

        

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var x = e.Item;
            var y = e.Group;
            
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}