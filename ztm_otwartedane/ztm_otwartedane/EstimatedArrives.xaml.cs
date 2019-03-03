using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ztm_otwartedane
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EstimatedArrives : ContentPage
	{
        List<BusEstimatedTime> GetEstimatedArrives(int id)
        {
            string url = "http://87.98.237.99:88/delays?stopId=" + id;
            var response = ApiRequests.GET(url);

            return BusEstimatedTimeParser.FromJson(response).allArrives;
        }

		public EstimatedArrives (int id, string name)
		{
            this.Title = name;
            InitializeComponent ();
            estimatedArrives.ItemsSource = GetEstimatedArrives(id);
		}

        private void EstimatedArrives_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (estimatedArrives.SelectedItem == null)
                return;

            estimatedArrives.SelectedItem = null;
        }
    }
}