using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Booking : IBooking 
    {
        

        public Booking(int id, IVehicle vehicle, IPerson customer, int kmRented, DateTime dateRented)
        {
            Id = id;
            Vehicle = vehicle;
            Customer = customer;
            KmRented = kmRented;
            DateRented = dateRented;
            Status = BookingStatuses.Open;
            vehicle.VehicleStatus = VehicleStatuses.Booked;           
        }

        public Booking()
        {

        }

        
        public int Id { get; set; }
        public IVehicle Vehicle { get; set; }
        public IPerson Customer { get; set; }
        public int KmRented { get; set; }
        public int? KmReturned { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public int? Cost { get; set; }
        public BookingStatuses Status { get; set; }
        public void ReturnVehicle(IVehicle vehicle, int kmReturned, DateTime dateReturned)
        {
            vehicle.VehicleStatus = VehicleStatuses.Available;
            KmReturned = kmReturned;
            DateReturned = dateReturned;
            Status = BookingStatuses.Closed;
            //if (DateReturned.HasValue)
            Cost = (int)((((dateReturned - DateRented).Days + 1) * vehicle.CostPerDay) + ((kmReturned - KmRented) * vehicle.CostPerKm));                    
        }
    }

   
}
