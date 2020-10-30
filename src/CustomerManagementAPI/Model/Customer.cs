﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using BWMS.CustomerManagementAPI.Commands;

namespace BWMS.CustomerManagementAPI.Model
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }

        // v2 functionality:
        // public int? LoyaltyLevel
        // {
        //     get
        //     {
        //         switch (City.ToLowerInvariant())
        //         {
        //             case "amsterdam":
        //                 return 3;
        //             case "den haag":
        //                 return 2;
        //             default:
        //                 return 1;
        //         }
        //     }
        // }
    }
}
