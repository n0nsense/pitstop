﻿using BWMS.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Commands;

namespace WebApp.RESTClients
{
    public interface IVehicleManagementAPI
    {
        [Get("/vehicles")]
        Task<List<Vehicle>> GetVehicles();

        [Get("/vehicles/{id}")]
        Task<Vehicle> GetVehicleByName([AliasAs("id")] string Name);

        [Post("/vehicles")]
        Task RegisterVehicle(RegisterVehicle command);
    }
}
