﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.NotificationService.Model
{
    public class MaintenanceJob
    {
        public string JobId { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
    }
}
