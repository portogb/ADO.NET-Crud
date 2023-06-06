using ConsoleApp.Entities;
using ConsoleApp.Service;

public class Program
{
    public static async Task Main(string[] args)
    {
        CarService service = new();

        Car car0 = new Car
        {
            Name = "Fiat Cronos",
            Color = "Red",
            CarKey = "00FG34",
            FabricationYear = DateTime.Today
        };

        Car car = new Car
        {
            Name = "Fiat Mobi",
            Color = "White",
            CarKey = "0HF21P",
            FabricationYear = DateTime.Now
        };

        // CREATE
        await service.SaveCar(car0);
        await service.SaveCar(car);

        // READ
        Car readCar = await service.GetCar(1);
        System.Console.WriteLine($"{readCar.Id} | {readCar.Name} | {readCar.Color} | {readCar.CarKey} | {readCar.FabricationYear}");

        // READ LIST
        List<Car> cars = await service.GetAllCars();
        foreach (Car i in cars)
        {
            System.Console.WriteLine($"{i.Id} | {i.Name} | {i.Color} | {i.CarKey} | {i.FabricationYear}");
        }

        // UPDATE
        Car c = new();
        c.Name = "Fiat 500e";
        c.Color = "Green";
        c.CarKey = "2PHZI0";
        c.FabricationYear = DateTime.Now;

        await service.UpdateCar(1, c); 
        await service.GetCar(1);
        System.Console.WriteLine($"{c.Name} | {c.Color} | {c.CarKey} | {c.FabricationYear}");

        // DELETE
        await service.DeleteCar(2);
    }
}