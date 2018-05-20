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

namespace CMOVproj2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string API_KEY = "8d615ff3da0c731b43d2fa3068097e8b";
        public event PropertyChangedEventHandler PropertyChanged;
        private string myCompany;
        private Company selectedCompany;
        private DateTime selectedDate;


        public IList<Company> Companies { get { return Models.CompanyData.Companies; } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand GetDataFromApi { get; private set; }

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





        public MainPageViewModel()
        {
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
                        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                        return jsonDoc;
                    }
                }
            }
        }



    }
}
