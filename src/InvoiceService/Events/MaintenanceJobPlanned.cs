﻿using Pitstop.Infrastructure.Messaging;
using System;

namespace BWMS.InvoiceService.Events
{
    public class MaintenanceJobPlanned : Event
    {
        public readonly string JobId;
        public readonly (string Id, string Name, string TelephoneNumber) CustomerInfo;
        public readonly (string Name, string Brand, string Type) VehicleInfo;
        public readonly string Description;

        public MaintenanceJobPlanned(Guid messageId, string jobId, (string Id, string Name, string TelephoneNumber) customerInfo,
            (string Name, string Brand, string Type) vehicleInfo, string description) : base(messageId)
        {
            JobId = jobId;
            CustomerInfo = customerInfo;
            VehicleInfo = vehicleInfo;
            Description = description;
        }
    }
}
