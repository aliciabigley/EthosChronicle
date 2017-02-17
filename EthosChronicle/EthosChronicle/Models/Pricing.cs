using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthosChronicle.Models
{
    public class Pricing
    {
        public int Id { get; set; }

        public string PackageType { get; set; }
        public double Price { get; set; }
        
    }
}