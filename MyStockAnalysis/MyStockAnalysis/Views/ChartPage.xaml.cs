using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyStockAnalysis
{

    public partial class ChartPage : ContentPage
    {
        public string API_KEY = "8d615ff3da0c731b43d2fa3068097e8b";
        public AbsoluteLayout layout = new AbsoluteLayout();

        public ChartPage( string type, string[] companies, DateTime selectedDate)
        {

        public ChartPage(ObservableCollection<Company> selectedCompanies, DateTime selectedDate, string type)
            //var layout = new AbsoluteLayout();

            foreach(string company in companies)
            {
                 GetDataFromApi(company, selectedDate);
            }
         

        }

        public async Task GetDataFromApi(string company, DateTime selectedDate)
        {
            string date = String.Format("{0:yyyyMMdd}", selectedDate);
 
            string url = "https://marketdata.websol.barchart.com/getHistory.json?apikey=" +
                            API_KEY +
                            "&symbol=" +
                            company +
                            "&type=daily&startDate=" +
                             date;

            await FetchApiDataAsync(url);
        }

        public async Task FetchApiDataAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

                }
            }
        }

        public void createChart()
        {

            ChartView newChart = new ChartView
            {
                Margin = new Thickness(5, 0, 10, 0),
                HeightRequest = 190,
                BackgroundColor = Color.Transparent
            };

            AbsoluteLayout.SetLayoutBounds(newChart, new Rectangle(.5, 40, 1, 190));
            AbsoluteLayout.SetLayoutFlags(newChart, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);
            newChart.SetBinding(ChartView.ChartProperty, "Graph1");

            layout.Children.Add(newChart);

            InitializeComponent();

            Content = layout;
            BindingContext = new ViewModels.ChartPageViewModel(jsonDoc, type);
        }

    }
}
