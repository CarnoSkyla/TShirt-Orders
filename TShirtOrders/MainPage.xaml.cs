using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace TShirtOrders
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public IList<TShirt> tshirtList { get; private set; }
        
        public MainPage()
        {
            InitializeComponent();

        
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var tshirtDatabase = App.Database;

            tshirtList = await tshirtDatabase.GetTShirtOrder();

            

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());

            
        }
        
        private async void RelayButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
            
        }

        private async void add_Clicked(object sender, EventArgs e)
        {
            var name = Name.Text;
            var tshirtGender = gender.Text;
            var tshirtSize = size.Text;
            var tshirtColor = color.Text;
            var datePicker = date.Date;
            var shippingAddress = address.Text;
            var deviceLocation = await Geolocation.GetLastKnownLocationAsync();


            TShirt tshirtStuff = new TShirt()
            {
                ID = 0,
                Name = name,
                Gender = tshirtGender,
                TShirtSize = tshirtSize,
                TShirtColor = tshirtColor,
                DateOfOrder = datePicker,
                ShippingAddress = shippingAddress,
                DeviceLocation = deviceLocation
            };

            
            
            

            
            await App.Database.InsertTShirtOrder(tshirtStuff);

            

            await Navigation.PushAsync(new ShirtOrders());
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShirtOrders());
        }
    }
}
