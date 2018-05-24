using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Json;
using Xamarin.Forms;

namespace CMOVproj2
{

    public partial class ChartPage : ContentPage
	{
        

        public ChartPage(JsonValue jsonDoc, string type)
        {

            InitializeComponent();
            BindingContext = new ViewModels.ChartPageViewModel(jsonDoc,type);
        }
	
    }
}
