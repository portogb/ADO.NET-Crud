using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities;
public class Car
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public string? CarKey { get; set; }
    public DateTime FabricationYear { get; set; }

    public Car()
    { }

    public Car(string name, string color, string carKey, DateTime fabricationYear)
    {
        Name = name;
        Color = color;
        CarKey = carKey;
        FabricationYear = fabricationYear;
    }
}   
