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
using System.Collections.ObjectModel;
using System.Linq;

namespace MyStockAnalysis.ViewModels
{
    class ChartPageViewModel
    {
        private INavigation Navigation;
        private List<Microcharts.Entry> companyEntry = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> appleEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> googleEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> ibmEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> microsoftEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> amdEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> intelEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> facebookEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> twitterEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> oracleEntries = new List<Microcharts.Entry>();
        private List<Microcharts.Entry> hpEntries = new List<Microcharts.Entry>();

        public Chart Apple => new LineChart()
        {
            Entries = appleEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart Google => new LineChart()
        {
            Entries = googleEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart IBM => new LineChart()
        {
            Entries = ibmEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart Microsoft => new LineChart()
        {
            Entries = microsoftEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart AMD => new LineChart()
        {
            Entries = amdEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart Intel => new LineChart()
        {
            Entries = intelEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart Facebook => new LineChart()
        {
            Entries = facebookEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart Twitter => new LineChart()
        {
            Entries = twitterEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart Oracle => new LineChart()
        {
            Entries = oracleEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };
        public Chart HP => new LineChart()
        {
            Entries = hpEntries,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            PointSize = 10,
            BackgroundColor = SKColors.Transparent
        };

        public ChartPageViewModel(List<JsonValue> allData,string type, ObservableCollection<Company> companies)
        {
            Boolean showValues = true;
            for (int i= 0; i < allData.Count; i++)
            {
                if(allData.Count > 1)
                {
                    showValues = false;
                }
                companyEntry = getSelectedCompanyEntry(companies[i]);
                ApiResult apiResults = JsonConvert.DeserializeObject<ApiResult>(allData[i].ToString());
                string selectedType = "null";
                foreach (var item in apiResults.results)
                {
                    selectedType = getSelectedType(type, item);

                    addToEntry(companyEntry, float.Parse(selectedType, CultureInfo.InvariantCulture.NumberFormat), selectedType, companies[i].Color, showValues);

                }
            }
        }

        public List<Microcharts.Entry> getSelectedCompanyEntry(Company company)
        {
            switch (company.Name)
            {
                case "Google":
                    return googleEntries;
                case "Apple":
                    return appleEntries;
                case "AMD":
                    return amdEntries;
                case "Facebook":
                    return facebookEntries;
                case "HP":
                    return hpEntries;
                case "IBM":
                    return ibmEntries;
                case "Intel":
                    return intelEntries;
                case "Microsoft":
                    return microsoftEntries;
                case "Oracle":
                    return oracleEntries;
                case "Twitter":
                    return twitterEntries;
                default:
                    return null;
            }
        }

        public void addToEntry(List<Microcharts.Entry> entry, float value,string type, string color, Boolean showValues)
        {   
            if(showValues == true)
            {
                entry.Add(new Microcharts.Entry(value)
                {
                    Color = SKColor.Parse(color),
                    ValueLabel = type
                });
            }

            else
            {
                entry.Add(new Microcharts.Entry(value)
                {
                    Color = SKColor.Parse(color)
                });
            }
           
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
