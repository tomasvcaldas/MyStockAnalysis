using System;
using System.Collections.Generic;
using System.Text;
using System.Json;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using MyStockAnalysis.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace MyStockAnalysis.ViewModels
{
    class ChartPageViewModel
    {
        private INavigation Navigation;
        private List<Microcharts.Entry> entries = new List<Microcharts.Entry>();
       
        public Chart Graph1 => new LineChart()
        {
            Entries = entries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent,
            LineAreaAlpha = 10
        };


        public ChartPageViewModel(JsonValue chartData,string type)
        {
            
            ApiResult apiResults = JsonConvert.DeserializeObject<ApiResult>(chartData.ToString());
            string selectedType = "null";
            foreach (var item in apiResults.results)
            {
                selectedType = getSelectedType(type, item);

                addToEntry(entries, float.Parse(selectedType, CultureInfo.InvariantCulture.NumberFormat), selectedType, "FF1493");

            }
        }

        public void addToEntry(List<Microcharts.Entry> entry, float value,string type, string color)
        {
            entry.Add(new Microcharts.Entry(value)
            {
                Color = SKColor.Parse(color),
                ValueLabel = type
            });
        }
        public string getSelectedType(String type, ResultLine received)
        {
            switch (type)
            {
                case "Open":
                    return received.open;
                case "Close":
                    return received.close;
                case "High":
                    return received.high;
                case "Low":
                    return received.low;
                default:
                    return "Null";
            }
        }
    }

}
