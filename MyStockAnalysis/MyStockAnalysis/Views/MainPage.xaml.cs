using System;
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
using Xamarin.Forms.Xaml;
using MyStockAnalysis.ViewModels;

namespace MyStockAnalysis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Console.Out.WriteLine("Main page");
            BindingContext = new MainPageViewModel(Navigation);
        }
    }
}
