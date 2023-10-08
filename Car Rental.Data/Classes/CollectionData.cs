using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new();
        readonly List<IVehicle> _vehicles = new();
        readonly List<IBooking> _bookings = new();

        public CollectionData() => SeedData();

        void SeedData()
        {
            _persons.Add(new Customer(12345, "Doe", "John"));
            _persons.Add(new Customer(98765, "Doe", "Jane"));
            _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200));
            _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, 100));
            _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100));
            _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300));
            _vehicles.Add(new Motorcycle("MNO345", "Yamaha", 30000, 0.5, 50));
            _bookings.Add(new Booking(_vehicles[2], _persons[0], 1000, new DateTime(2023, 9, 20)));
            _bookings.Add(new Booking(_vehicles[3], _persons[1], 5000, new DateTime(2023, 9, 20)));
            _bookings[1].ReturnVehicle(_vehicles[3], 5000, new DateTime(2023, 9, 20));
        }

        public IEnumerable<IPerson> GetPersons() => _persons;      

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = 0) => _vehicles;       

        public IEnumerable<IBooking> GetBookings() => _bookings;

       
    }
}
