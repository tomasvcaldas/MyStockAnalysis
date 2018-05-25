using Microcharts;
using Microcharts.Forms;
using MyStockAnalysis.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyStockAnalysis
{

    public partial class ChartPage : ContentPage
    {
        public string API_KEY = "a42e11004d816646f0726db9ad8fc0dd";
        public AbsoluteLayout layout = new AbsoluteLayout();
        public StackLayout stl = new StackLayout();


        public  ChartPage(ObservableCollection<Company> selectedCompanies, DateTime selectedDate, string type) {
            
            List<JsonValue> allData = new List<JsonValue>();
            JsonValue jsonDoc = "null";
            foreach(var company in selectedCompanies.ToList())
            {
               
                jsonDoc = GetDataFromApi(company, selectedDate);
                
                allData.Add(jsonDoc);
                createChart(company.Name, company.Color);
            }
            
            Content = layout;
            InitializeComponent();BindingContext = new ViewModels.ChartPageViewModel(allData, type, selectedCompanies);

        }

        public JsonValue GetDataFromApi(Company company, DateTime selectedDate)
        {
            
            string date = String.Format("{0:yyyyMMdd}", selectedDate);
 
            string url = "https://marketdata.websol.barchart.com/getHistory.json?apikey=" +
                            API_KEY +
                            "&symbol=" +
                            company.Tick +
                            "&type=daily&startDate=" +
                             date;

            JsonValue json =  FetchApiDataAsync(url);
            return json;
            
        }

        public JsonValue FetchApiDataAsync(string url)
        {
           
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";


            
            using (WebResponse response =  request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = Task.Run(() => JsonObject.Load(stream)).Result;
                   
                    return  jsonDoc;
                }
            }
        }

        public void createChart(string name,string color)
        {

            ChartView newChart = new ChartView
            {
                Margin = new Thickness(5, 0, 5, 0),
                HeightRequest = 140,
                BackgroundColor = Color.Transparent
            };

            AbsoluteLayout.SetLayoutBounds(newChart, new Rectangle(.5, 40, 1, 140));
            AbsoluteLayout.SetLayoutFlags(newChart, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);
            newChart.SetBinding(ChartView.ChartProperty, name);

            Label Name = new Label
            {
                Text = name,
                TextColor = Color.FromHex(color),
            };


            stl.Padding = new Thickness(10, 200, 5, 0);

            stl.Children.Add(Name);

            layout.Children.Add(newChart);
            layout.Children.Add(stl);

           
            
        }

    }
}
