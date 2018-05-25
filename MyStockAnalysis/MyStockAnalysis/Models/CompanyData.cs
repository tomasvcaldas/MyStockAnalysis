using System;
using System.Collections.Generic;
using System.Text;

namespace MyStockAnalysis.Models
{
    public static class CompanyData
    {

        public static IList<Company> Companies { get; private set; }

        static CompanyData()
        {
            Companies = new List<Company>();

            Companies.Add(new Company
            {
                Name = "Google",
                Tick = "GOOG",
                Color = "#DC4C46"
            });

            Companies.Add(new Company
            {
                Name = "IBM",
                Tick = "IBM",
                Color = "#672E3B"
            });

            Companies.Add(new Company
            {
                Name = "HP",
                Tick = "HPQ",
                Color = "#F3D6E4"
            });

            Companies.Add(new Company
            {
                Name = "Microsoft",
                Tick = "MSFT",
                Color = "#C48F65"
            });

            Companies.Add(new Company
            {
                Name = "Oracle",
                Tick = "ORCL",
                Color = "#223A5E"
            });

            Companies.Add(new Company
            {
                Name = "Facebook",
                Tick = "FB",
                Color = "#898E8C"
            });

            Companies.Add(new Company
            {
                Name = "Twitter",
                Tick = "TWTR",
                Color = "#005960"
            });

            Companies.Add(new Company
            {
                Name = "Intel",
                Tick = "INTC",
                Color = "#9C9A40"
            });

            Companies.Add(new Company
            {
                Name = "AMD",
                Tick = "AMD",
                Color = "#4F84C4"
            });

            Companies.Add(new Company
            {
                Name = "Apple",
                Tick = "AAPL",
                Color = "#D2691E"
            });
        }
    }
}
