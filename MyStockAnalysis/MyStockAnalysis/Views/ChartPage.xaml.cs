using MyStockAnalysis.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MyStockAnalysis
{

    public partial class ChartPage : ContentPage
    {


        public ChartPage(ObservableCollection<Company> selectedCompanies, DateTime selectedDate, string type)
        {
            InitializeComponent();
            selectedCompanies.ToList();
            //BindingContext = new ViewModels.ChartPageViewModel(jsonDoc, type);
        }

    }
}
