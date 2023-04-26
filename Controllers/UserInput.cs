using Labb3TheRace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb3TheRace.Controllers
{
    public class UserInput 
    {
        public static void StatusUpdate(List<Car> cars)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if(input.ToLower() == "status")
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Name} is at distance {car.Distance} and is travelling at {car.Speed} km/h");
                    }
                }
            }
        }
    }
}
