﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADE.NEON.Shared.Models
{
    public class AddressModel
    {
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string City { get; set; }
        public StateModel State { get; set; }
        public CountryModel Country { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    }
}
