using System.Data.Common;
using ConsoleApp.Data;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Service;

public class CarService
{
    public async Task<Car> SaveCar(Car car)
    {
        using DataContext context = new();
        await context.AddAsync(car);
        await context.SaveChangesAsync();
        return car;
    }

    public async Task<Car> GetCar(int id)
    {
        using DataContext context = new();
        Car? car = await context.Cars
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        return car;
    }

    public async Task<List<Car>> GetAllCars()
    {
        using DataContext context = new();
        List<Car> cars = await context.Cars
            .AsNoTracking()
            .ToListAsync();
        return cars;
    }

    public async Task<Car> UpdateCar(int id, Car car)
    {
        using DataContext context = new();
        Car? updatedCar = await context.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        
        updatedCar.Name = car.Name;
        updatedCar.Color = car.Color;
        updatedCar.CarKey = car.CarKey;
        updatedCar.FabricationYear = car.FabricationYear;

        context.Cars.Update(updatedCar);
        await context.SaveChangesAsync();

        return updatedCar;
    }

    public async Task DeleteCar(int id)
    {
        using DataContext context = new();
        Car? car = await context.Cars  
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        
        context.Cars.Remove(car);
        await context.SaveChangesAsync();
    }
}