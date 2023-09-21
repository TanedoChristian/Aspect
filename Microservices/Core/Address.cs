﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LineAddress { get; set; }
        public string ZipCode { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
