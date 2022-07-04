using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
            SportCar sportCar = new SportCar(200, 10);
            sportCar.Drive(100);
            Console.WriteLine(sportCar.Fuel);

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(10, 180);
            raceMotorcycle.Drive(150);
            Console.WriteLine(raceMotorcycle.Fuel);


            Car car = new Car(50, 140);
            car.Drive(100);
            Console.WriteLine(car.Fuel);




        }
    }
}
