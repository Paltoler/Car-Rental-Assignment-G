using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int id, string regNo, string make, int odometer, double costPerKm) :
            base(id, regNo, make, odometer, costPerKm)
        { VehicleType = VehicleTypes.Motorcycle; CostPerDay = 50; }
    }




}
