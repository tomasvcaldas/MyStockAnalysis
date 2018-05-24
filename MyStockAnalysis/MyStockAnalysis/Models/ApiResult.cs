using System;
using System.Collections.Generic;
using System.Text;

namespace MyStockAnalysis.Models
{
    public class ApiResult
    {
        public List<ResultLine> results { get; set; }
    }

    public class ResultLine
    {
        public string close { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string open { get; set; }
        public string tradingDay { get; set; }
    }

}
