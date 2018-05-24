using System;
using System.Collections.Generic;
using System.Text;

namespace CMOVproj2.Models
{
    public static class CompanyData
    {

        public static IList<Company> Companies { get; private set; }

        static CompanyData()
        {
            Companies = new List<Company>();

            Companies.Add(new Company
            {
                Name = "Apple",
                Tick = "AAPL"
            });

            Companies.Add(new Company
            {
                Name = "Google",
                Tick = "GOOG"
            });
        }
    }
}
