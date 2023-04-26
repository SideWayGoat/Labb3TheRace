using Labb3TheRace.Controllers;
using Labb3TheRace.Models;

namespace Labb3TheRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("White Lightning", 120, 0);
            Car c2 = new Car("Black Lightning", 120, 0);

            Thread t1 = new Thread(() => c1.Race(c1));
            Thread t2 = new Thread(() => c2.Race(c2));
            Thread t3 = new Thread(() => UserInput.StatusUpdate(Car.GetAllCars()));

            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}