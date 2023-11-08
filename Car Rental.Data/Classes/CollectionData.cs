using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Extensions;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new();
        readonly List<IVehicle> _vehicles = new();
        readonly List<IBooking> _bookings = new();
        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
        public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        public CollectionData() => SeedData();

        void SeedData()
        {
            Add<IPerson>(new Customer(NextPersonId, 12345, "Doe", "John"));
            Add<IPerson>(new Customer(NextPersonId, 98765, "Doe", "Jane"));
            Add<IVehicle>(new Car(NextVehicleId, "ABC123", "Volvo", 10000, VehicleTypes.Combi, 1));
            Add<IVehicle>(new Car(NextVehicleId, "DEF456", "Saab", 20000, VehicleTypes.Sedan, 1));
            Add<IVehicle>(new Car(NextVehicleId, "GHI789", "Tesla", 1000, VehicleTypes.Sedan, 3));
            Add<IVehicle>(new Car(NextVehicleId, "JKL012", "Jeep", 5000, VehicleTypes.Van, 1.5));
            Add<IVehicle>(new Motorcycle(NextVehicleId, "MNO345", "Yamaha", 30000, 0.5));
            Add<IBooking>(new Booking(NextBookingId, _vehicles[2], _persons[0], 1000, DateTime.Today));
            Add<IBooking>(new Booking(NextBookingId, _vehicles[3], _persons[1], 5000, DateTime.Today));            
            ReturnVehicle(4, 5000);
        }

        public List<T> Get<T>(Expression<Func<T, bool>>? expression)
        {
            var fields = typeof(CollectionData).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var listField = fields.FirstOrDefault(f => f.FieldType.Equals(typeof(List<T>)));
            if (listField is null)
            {
                throw new Exception("No list of the corresponding type found.");
            }

            var list = (List<T>)listField.GetValue(this);

            if (expression is null)
            {
                return list;
            }

            else
            {
                return list.Where(expression.Compile()).ToList();
            }
        }

        public T? Single<T>(Expression<Func<T, bool>>? expression)
        {
            return default;
        }
        public void Add<T>(T item)
        {
            var fields = typeof(CollectionData).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var listField = fields.FirstOrDefault(f => f.FieldType.Equals(typeof(List<T>)));
            if (listField is null)
            {
                throw new Exception("No list of the corresponding type found.");
            }

            var list = (List<T>)listField.GetValue(this);
            list.Add(item);            
        }

        public IBooking RentVehicle(int vehicleId, int customerId)
        {          
           
            var vehicle = _vehicles.FirstOrDefault(v => v.Id.Equals(vehicleId));
            var customer = _persons.FirstOrDefault(c => c.Id.Equals(customerId));
            if (vehicle != default && customer != default)

            {                               
                var booking = new Booking(NextBookingId, vehicle, customer, vehicle.Odometer, DateTime.Today);
                Add<IBooking>(booking);                
                return booking;
            }
            return default;
        }
            
     
        public IBooking ReturnVehicle(int vehicleId, int distance)
        {
            var booking =  _bookings.FirstOrDefault(b => b.Vehicle.Id.Equals(vehicleId) && b.Status.Equals(BookingStatuses.Open));
            if(booking != default)
            {                
                booking.Vehicle.VehicleStatus = VehicleStatuses.Available;
                booking.KmReturned = booking.KmRented + distance;
                booking.DateReturned = DateTime.Today;
                booking.Status = BookingStatuses.Closed;
                var duration = VehicleExtensions.Duration(booking.DateRented, DateTime.Today);
                booking.Cost = (int)((duration * booking.Vehicle.CostPerDay) + (booking.KmReturned - booking.KmRented) * booking.Vehicle.CostPerKm);
                booking.Vehicle.Odometer += distance;                
                return booking;
            }
            
            return default;
        }
        public string[] VehicleStatusNames() => Enum.GetNames(typeof(VehicleStatuses));
        public string[] VehicleTypeNames() => Enum.GetNames(typeof(VehicleTypes));
        public VehicleTypes GetVehicleType(string name) => (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name);

        public IEnumerable<IPerson> GetPersons() => _persons;      

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = 0) => _vehicles;       

        public IEnumerable<IBooking> GetBookings() => _bookings;

       
    }
}
