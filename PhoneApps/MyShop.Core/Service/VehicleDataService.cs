using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Core
{

    public class VehicleDataService
    {
        private static CustomerVehicleRepository custVehicleRepository = new CustomerVehicleRepository();
        public VehicleDataService() { }

        public List<CustomerVehicle> GetAllDealers()
        {
            return custVehicleRepository.GetAllCustomers();
        }

        public CustomerVehicle GetDealersById(int dealerId)
        {
            return custVehicleRepository.GetCustomerVehicleById(dealerId);
        }
    }

	
}

