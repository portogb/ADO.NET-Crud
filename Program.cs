using ConsoleApp.DAO.Impl;
using ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            CarImpl carImpl = new CarImpl();

            // SELECT BY ID
            Car car = await carImpl.GetByIdAsync(1);
            Console.WriteLine("Values");
            System.Console.WriteLine($"{car.Id} | {car.Name} | {car.Color} | {car.CarKey}");

            // SELECT
            List<Car> listCar = await carImpl.GetAllAsync();
            System.Console.WriteLine("List");
            foreach (var i in listCar)
            {
                System.Console.WriteLine($"{i.Id} | {i.Name} | {i.Color} | {i.CarKey}");
            }

            // INSERT
            // Car newCar = new Car("Fiat Toro", "Black", 00918);
            Car newCar = new Car("Toyota Corolla", "Black", 34127);
            int row0 = await carImpl.SaveAsync(newCar);
            System.Console.WriteLine(row0);

            // UPDATE
            // Car updateCar = new Car("Fiat Toro", "Black", 11918);
            Car updateCar = new Car("Corolla", "Black", 34128);
            int row1 = await carImpl.UpdateAsync(updateCar, 10);
            System.Console.WriteLine(row1);
            
            // DELETE
            int row2 = await carImpl.DeleteByIdAsync(10);
            System.Console.WriteLine(row2);
        }
    }
}
