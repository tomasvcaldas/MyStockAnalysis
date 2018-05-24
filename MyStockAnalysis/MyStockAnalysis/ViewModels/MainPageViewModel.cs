using MyStockAnalysis;
using MyStockAnalysis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Json;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace MyStockAnalysis.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string API_KEY = "8d615ff3da0c731b43d2fa3068097e8b";
        public event PropertyChangedEventHandler PropertyChanged;
        private string myCompany;
        private Company selectedCompany;
        private DateTime selectedDate;
        private QuoteType selectedType;
        public bool canCreate = false;
        private INavigation Navigation;

        

        public IList<Company> Companies { get { return CompanyData.Companies; } }

        public IList<QuoteType> QuoteTypes { get { return QuoteTypeData.QuoteTypes; } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand GetDataFromApi { get; private set; }


        public QuoteType SelectedType
        {
            get { return selectedType; }
            set
            {
                if (selectedType != value)
                {
                    selectedType = value;
                    OnPropertyChanged("SelectedType");
                }
            }
        }

        public string MyCompany
        {
            get { return myCompany; }
            set
            {
                if (myCompany != value)
                {
                    myCompany = value;
                    OnPropertyChanged();

                }
            }
        }

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                if (selectedCompany != value)
                {
                    selectedCompany = value;
                    MyCompany = selectedCompany.Tick;


                }
            }
        }

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }







        private void ChangeDate(DateTime newDate)
        {
            SelectedDate = newDate;  //Assing your new date to your property
        }



        public MainPageViewModel(INavigation _Navigation)
        {
            Console.Out.WriteLine("Main page");
            Navigation = _Navigation;

            GetDataFromApi = new Command(async () =>
            {



                string date = String.Format("{0:yyyyMMdd}", selectedDate);

                string url = "https://marketdata.websol.barchart.com/getHistory.json?apikey=" +
                                API_KEY +
                                "&symbol=" +
                                selectedCompany.Tick +
                                "&type=daily&startDate=" +
                                 date;



                JsonValue json = await FetchApiData(url);
            });



            async Task<JsonValue> FetchApiData(string url)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                request.ContentType = "application/json";
                request.Method = "GET";

                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

                        await Navigation.PushAsync(new ChartPage(jsonDoc, selectedType.Type));

                        return jsonDoc;

                    }
                }
            }


        }
    }
}
