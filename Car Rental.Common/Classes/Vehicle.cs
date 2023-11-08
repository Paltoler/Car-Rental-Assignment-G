using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    public class Vehicle : IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Id { get; set; }
        public int Odometer { get; set; }        
        public int DistanceDrived { get; set; }
        public double CostPerKm { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public int CostPerDay { get; set; }
        public VehicleStatuses VehicleStatus { get; set; }
        

        public Vehicle(int id, string regNo, string make, int odometer, double costPerKm)
        {
            Id = id;
            RegNo = regNo;
            Make = make;
            Odometer = odometer;
            CostPerKm = costPerKm;            
            VehicleStatus = VehicleStatuses.Available;
        }
        public Vehicle() { }
    }
}
