using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Car : Vehicle
    {

        public Car(int Id, string regNo, string make, int odometer, VehicleTypes vehicleType, double costPerKm) :
            base(Id, regNo, make, odometer, costPerKm) 
        { VehicleType = vehicleType;
            if (vehicleType.Equals(VehicleTypes.Sedan)) CostPerDay = 100;
            if (vehicleType.Equals(VehicleTypes.Combi)) CostPerDay = 200;
            if (vehicleType.Equals(VehicleTypes.Van)) CostPerDay = 300;
        }


        
    }
}
