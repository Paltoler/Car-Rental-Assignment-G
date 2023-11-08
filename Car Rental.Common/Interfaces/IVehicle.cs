using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces
{
    public interface IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Id { get; set; }
        public int Odometer { get; set; }
        public int DistanceDrived { get; set; }

        

        public double CostPerKm { get; set; }
        

        public VehicleTypes VehicleType { get; set;}
        public int CostPerDay { get; set;}
        public  VehicleStatuses VehicleStatus { get; set; }


    }
}
