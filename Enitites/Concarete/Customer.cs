﻿using Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enitites.Concarete
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Ctiy { get; set; }
    }
}
