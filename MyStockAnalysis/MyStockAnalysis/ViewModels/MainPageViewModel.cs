using MyStockAnalysis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Json;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace MyStockAnalysis.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string API_KEY = "8d615ff3da0c731b43d2fa3068097e8b";
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime selectedDate;
        private QuoteType selectedType;
        public bool canCreate = false;
        private INavigation Navigation;
        public ObservableCollection<Company> selectedCompanies { get; set; }

        public Command<Company> AddSelectedCompanies
        {
            get
            {
                return new Command<Company>((Company) =>
                {
                    selectedCompanies.Add(Company);
                });
            }
        }

        public Command<Company> RemoveSelectedCompanies
        {
            get
            {
                return new Command<Company>((Company) =>
                {
                    selectedCompanies.Remove(Company);
                });
            }
        }

        public IList<Company> Companies { get { return CompanyData.Companies; } }

        public IList<QuoteType> QuoteTypes { get { return QuoteTypeData.QuoteTypes; } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand GetCharts { get; private set; }


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

        public Company AddCompanyToSelectedCompanies
        {
            set
            {
                if (!selectedCompanies.Contains(value))
                {
                    AddSelectedCompanies.Execute(value);
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
            SelectedDate = newDate;
        }

        public MainPageViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            selectedCompanies = new ObservableCollection<Company>();

            GetCharts = new Command(async () =>
            {
                await Navigation.PushAsync(new ChartPage(selectedCompanies, selectedDate, selectedType.Type));
            });
        }
    }
}
