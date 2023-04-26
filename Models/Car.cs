using System.Diagnostics;

namespace Labb3TheRace.Models
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public int Placement { get; set; }


        public Car(string _name, int _speed, int _distance)
        {
            this.Name = _name;
            this.Speed = _speed;
            this.Distance = _distance;
        }

        public static List<Car> cars { get; set; } = new List<Car>();

        private static int totalcars;

        public static List<Car> GetAllCars()
        {
            return cars;
        }

        public void Race(Car car)
        {
            cars.Add(car);
            totalcars++;
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Console.WriteLine($"The race is on! {Name} has left the starting line!");
            while (Distance <= 10000)
            {
                this.Distance += Speed;
                Thread.Sleep(1000);
                if (sw.Elapsed.TotalSeconds > 8)
                {
                    HandleRandomEvent(car);
                    sw.Restart();
                }
            }
            totalcars--;
            if(totalcars == 1)
            {
                car.Placement = 1;
            }
            else
            {
                car.Placement = 2;
            }
            Console.WriteLine($"{Name} finished {Placement}");

        }
        public void HandleRandomEvent(Car car)
        {
            var rnd = new Random();
            var theRandom = rnd.Next(1, 51);
            if (theRandom == 42)
            {
                Console.WriteLine($"{Name} ran out of fuel and needs 30 seconds to refuel");
                Thread.Sleep(30 * 1000);
            }
            else if (theRandom == 2 && theRandom == 3)
            {
                Console.WriteLine($"{Name} got a flat tyre and needs only 20 seconds to change it");
                Thread.Sleep(20 * 1000);
            }
            else if (theRandom >= 4 && theRandom <= 8)
            {
                Console.WriteLine($"A bird hit {Name}, the horror and shock has given him cause to reflect on life for 10 seconds ");
                Thread.Sleep(10 * 1000);
            }
            else if (theRandom >= 9 && theRandom <= 18)
            {
                Speed -= 1;
                Console.WriteLine($"{Name} has encountered engine problems and is now driving at {Speed} km/h ");
            }
        }
    }
}
