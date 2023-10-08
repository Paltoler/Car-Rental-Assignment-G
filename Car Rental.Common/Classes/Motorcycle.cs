using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Motorcycle : IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Odometer { get; set; }
        public double CostPerKm { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public int CostPerDay { get; set; }
        public VehicleStatuses VehicleStatus { get; set; }

        public Motorcycle(string regNo, string make, int odometer, double costPerKm, int costPerDay)
        {
            RegNo = regNo;
            Make = make;
            Odometer = odometer;
            CostPerKm = costPerKm;
            VehicleType = VehicleTypes.Motorcycle;
            CostPerDay = costPerDay;
            VehicleStatus = VehicleStatuses.Available;
        }
    }




}
