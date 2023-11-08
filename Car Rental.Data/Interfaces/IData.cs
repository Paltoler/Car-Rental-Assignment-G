﻿using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces
{
    public interface IData
    {
        

        List<T> Get<T>(Expression<Func<T, bool>>? expression);
        T? Single<T>(Expression<Func<T, bool>>? expression);
        void Add<T>(T item);

        int NextVehicleId { get; }
        int NextPersonId { get; }
        int NextBookingId { get; }
        IBooking RentVehicle(int vehicleId, int customerId);
        IBooking ReturnVehicle(int vehicleId, int distance);
        string[] VehicleStatusNames();
        string[] VehicleTypeNames();
        public VehicleTypes GetVehicleType(string name);

    }
}
