﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BWMS.InvoiceService.Model
{
    public class Invoice
    {
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Specification { get; set; }
        public string JobIds { get; set; }
    }
}
