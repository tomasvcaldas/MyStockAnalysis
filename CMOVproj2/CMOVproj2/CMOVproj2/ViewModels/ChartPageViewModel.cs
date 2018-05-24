using System;
using System.Collections.Generic;
using System.Text;
using System.Json;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using CMOVproj2.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace CMOVproj2.ViewModels
{
    class ChartPageViewModel
    {
        private INavigation Navigation;
        private List<Microcharts.Entry> entries = new List<Microcharts.Entry>();

        public Chart DistanceChart => new LineChart()
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
                if(type == "Open")
                {
                    selectedType = item.open;
                }
                else if(type == "Close")
                {
                    selectedType = item.close;
                }
                else if (type == "High")
                {
                    selectedType = item.high;
                }
                else if (type == "Low")
                {
                    selectedType = item.low;
                }
                entries.Add(new Microcharts.Entry(float.Parse(selectedType, CultureInfo.InvariantCulture.NumberFormat))
                {   
                    
                    Color = SKColor.Parse("FF1493"),
                    ValueLabel = selectedType
                });
                
            }

         
    }


    }
}
