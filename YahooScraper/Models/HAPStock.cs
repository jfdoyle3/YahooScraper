//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YahooScraper.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HAPStock
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
        public string Symbol { get; set; }
        public string LastPrice { get; set; }
        public string Change { get; set; }
        public string ChgPc { get; set; }
        public string MarketTime { get; set; }
        public string Volume { get; set; }
        public string AvgVol3m { get; set; }
        public string MarketCap { get; set; }
        public string Method { get; set; }
    }
}