using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CMOVproj2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public IList<Company> Companies { get { return Models.CompanyData.Companies; } }

        Company selectedCompany;

        public event PropertyChangedEventHandler PropertyChanged;

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                if (selectedCompany != value)
                {
                    selectedCompany = value;
                    Console.Out.WriteLine("COMPANY: {0}", selectedCompany.Name);
                    
                }
            }
        }

    }
}
