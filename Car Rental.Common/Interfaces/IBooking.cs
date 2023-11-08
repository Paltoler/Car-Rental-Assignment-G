using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces
{
    public interface IBooking
    {
        int Id { get; set; }
        IVehicle Vehicle { get; set; }
        IPerson Customer { get; set; }
        int KmRented { get; set; }
        int? KmReturned { get; set; }
        DateTime DateRented { get; set; }
        DateTime? DateReturned { get; set; }
        BookingStatuses Status { get; set; }
        int? Cost { get; set; }
        void ReturnVehicle(IVehicle vehicle, int kmReturned, DateTime returned);


    }
}
