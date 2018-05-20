using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CMOVproj2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new ViewModels.MainPageViewModel();

            

		}

        async void getDataFromAPi(object sender, EventArgs e)
        {
           

            string url = "https://marketdata.websol.barchart.com/getHistory.json?apikey=8d615ff3da0c731b43d2fa3068097e8b&symbol=INTC&type=daily&startDate=20180515";

            JsonValue json = await FetchApiData(url);
        }

        private async Task<JsonValue> FetchApiData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                    return jsonDoc;
                }
            }
        }




    }
}
