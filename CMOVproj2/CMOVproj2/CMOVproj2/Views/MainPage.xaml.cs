﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

namespace CMOVproj2
{
	public partial class MainPage : ContentPage
	{   

       

        public MainPage()
		{
			InitializeComponent();
           
   

            BindingContext = new ViewModels.MainPageViewModel(Navigation);

            

		}


    }
}
