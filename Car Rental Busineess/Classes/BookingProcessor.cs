using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public string error = String.Empty;
    public BookingProcessor(IData db) => _db = db;
    public IEnumerable<IPerson> GetCustomers() => _db.Get<IPerson>(null);
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _db.Get<IVehicle>(null);
    public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>(null);
    public IPerson? GetPerson(string ssn) => _db.Single<IPerson>(null);
    public IVehicle? GetVehicle(int vehicleID) => _db.Single<IVehicle>(null);
    public IVehicle? GetVehicle(string regNo) => _db.Single<IVehicle>(null);
    public async Task RentVehicle(int vehicleId, int customerID)
    {
        IsProcessing = true;
        await Task.Delay(3000);
        _db.RentVehicle(vehicleId, customerID);
        IsProcessing = false;        
    }
    public IBooking ReturnVehicle(int vehicleId, int distance) => _db.ReturnVehicle(vehicleId, distance);
    public bool IsProcessing { get; set; }

    public void AddVehicle(string regNo, string make, int odometer, double costKm, VehicleTypes type) 
    {
        if (regNo == null) 
        { 
            error = "RegNo must contain 6 characters."; 
        }
        else if (make == null)
        {
            error = "Make must contain at least two characters.";
        }
        else if (regNo.Length != 6)
        {
            error = "RegNo must contain 6 characters.";
        }
        else if (make.Length < 2)
        {
            error = "Make must contain at least two characters.";
        }
        else if (odometer < 0)
        {
            error = "Odometer must be a positive number.";
        }

        else if (costKm < 0)
        {
            error = "CostKm must be a positive number.";
        }

        else if (type == VehicleTypes.Motorcycle)
        {
            _db.Add<IVehicle>(new Motorcycle(_db.NextVehicleId, regNo, make, odometer, costKm));
            error = String.Empty;
        }

        else
        {
            _db.Add<IVehicle>(new Car(_db.NextVehicleId, regNo, make, odometer, type, costKm));
            error = String.Empty;
        }
    }

    public void AddCustomer(int ssn,  string firstName, string lastName)
    {
        if (firstName == null | lastName == null)
        {
            error = "The name fields can't be empty";
        }
        
        else if (ssn < 10000 || ssn > 99999)
        {
            error = "SSN must be 5 digits";
        }
        else if (firstName.Length < 2)
        {
            error = "First name must contain at least two characters";
        }
        else if (lastName.Length < 2)
        {
            error = "Last name must contain at least two characters";
        }

        else
        {
            _db.Add<IPerson>(new Customer(_db.NextPersonId, ssn, firstName, lastName));
            error = String.Empty;
        } 
            
    }

    public string[] VehicleStatusNames => _db.VehicleStatusNames();
    public string[] VehicleTypeNames => _db.VehicleTypeNames();
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);






}

