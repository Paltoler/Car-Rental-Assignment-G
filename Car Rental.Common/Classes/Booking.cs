using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Booking : IBooking 
    {
        

        public Booking(IVehicle vehicle, IPerson customer, int kmRented, DateTime dateRented)
        {
            Vehicle = vehicle;
            Customer = customer;
            KmRented = kmRented;
            DateRented = dateRented;
            Status = BookingStatuses.Open;
            vehicle.VehicleStatus = VehicleStatuses.Booked;
            bookingNo ++;
            BookingNumber = bookingNo; 
        }

        private static int bookingNo = 0;
        public int BookingNumber { get; set; }
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
            this.KmReturned = kmReturned;
            this.DateReturned = dateReturned;
            this.Status = BookingStatuses.Closed;
            if(this.DateReturned.HasValue)
            this.Cost = (int)(((((DateTime)dateReturned - this.DateRented).Days + 1) * vehicle.CostPerDay) + ((kmReturned - this.KmRented) * vehicle.CostPerKm));                        
        }
    }

   
}
