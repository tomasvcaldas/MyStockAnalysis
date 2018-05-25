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
using MyStockAnalysis.Models;

namespace MyStockAnalysis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }

        private void RemoveCompanyFromList(object sender, EventArgs e)
        {
            var button = sender as Button;

            var company = button.BindingContext as Company;

            var vm = BindingContext as MainPageViewModel;
            vm.RemoveSelectedCompanies.Execute(company);
        }
    }
}
