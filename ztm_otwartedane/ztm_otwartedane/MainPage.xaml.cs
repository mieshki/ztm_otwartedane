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
        List<BusStop> allBusStops = new List<BusStop>();

        public static string ReadAllBusStops()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ztm_otwartedane.EmbeddedResources.allBusStopsJSON.txt");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }

        void ParseAllBusStops()
        {
            var allBusStopsJSON = ReadAllBusStops();
            var parsedBusStops = BusStopParser.FromJson(allBusStopsJSON);

            foreach (var busStop in parsedBusStops.BusStops)
            {
                allBusStops.Add(busStop);
            }
        }
        
        List<BusStop> GetAllBusStops(string filter = "")
        {
            if (string.IsNullOrWhiteSpace(filter))
                return allBusStops;
            else
                return allBusStops.Where(item => item.stopName.ToLower().StartsWith(filter.ToLower())).ToList();
        }
        public MainPage()
        {
            InitializeComponent();
            ParseAllBusStops();

            listViewBusStops.ItemsSource = GetAllBusStops();
        }

        

        private void FilterBusStops_TextChanged(object sender, TextChangedEventArgs e)
        {
            var newSearch = e.NewTextValue;
            listViewBusStops.ItemsSource = GetAllBusStops(newSearch);
            
        }

        async private void ListViewBusStops_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            var busStop = e.SelectedItem as BusStop;
            //DisplayAlert("title", busStop.stopName, "ok");
            
            await Navigation.PushAsync(new EstimatedArrives(busStop.stopID, busStop.stopName));
            listViewBusStops.SelectedItem = null;
        }
    }
}
