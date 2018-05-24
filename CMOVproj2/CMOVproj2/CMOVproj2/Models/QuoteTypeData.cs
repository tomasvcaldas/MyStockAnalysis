using System;
using System.Collections.Generic;
using System.Text;

namespace CMOVproj2.Models
{
    public static class QuoteTypeData
    {
        public static IList<QuoteType> QuoteTypes { get; private set; }

        static QuoteTypeData()
        {
            QuoteTypes = new List<QuoteType>();

            QuoteTypes.Add(new QuoteType
            {
                Type = "High"
            });

            QuoteTypes.Add(new QuoteType
            {
                Type = "Low"
            });

            QuoteTypes.Add(new QuoteType
            {
                Type = "Open"
            });

            QuoteTypes.Add(new QuoteType
            {
                Type = "Close"
            });
        }
    }
}
