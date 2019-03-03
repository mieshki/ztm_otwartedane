using Android.Content.Res;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;


namespace ztm_otwartedane
{
    public partial class MainPage : ContentPage
    {


        List<BusStop> GetAllBusStops(string filter = "")
        {
            List<BusStop> busStops = new List<BusStop>()
            {
                new BusStop() {id = 0, name = "wagnera"},
                new BusStop() {id = 1, name = "otwarta"},
                new BusStop() {id = 2, name = "kurpinskiego"},
                new BusStop() {id = 3, name = "piecewska"},
                new BusStop() {id = 4, name = "warnenska"}
            };
            if (string.IsNullOrWhiteSpace(filter))
                return busStops;
            else
                return busStops.Where(item => item.name.ToLower().StartsWith(filter.ToLower())).ToList();
        }

        void TestBase()
        {
            MySqlConnection connection = new MySqlConnection("Server=www.mkwk018.cba.pl;Port=3306;Database=bus_stops;User Id=mieshki;Password=password;");

           

        }

        public MainPage()
        {
            InitializeComponent();

            


            listViewBusStops.ItemsSource = GetAllBusStops();

        }

        

        private void FilterBusStops_TextChanged(object sender, TextChangedEventArgs e)
        {
            var newSearch = e.NewTextValue;
            listViewBusStops.ItemsSource = GetAllBusStops(newSearch);
            
        }   

        private void btnUpdateBusStop_Clicked(object sender, EventArgs e)
        {
            //testLabel.Text = ApiRequests.GET("https://ckan.multimediagdansk.pl/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/4c4025f0-01bf-41f7-a39f-d156d201b82b/download/stops.json");

            TestBase();
        }
    }
}
