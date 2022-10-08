using System;

namespace lab04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("TASK 1");

            MyMatrix matrix1 = new MyMatrix(2, 2);
            MyMatrix matrix2 = new MyMatrix(2, 2);
            MyMatrix matrix3 = new MyMatrix();
            matrix1.FillMatrix();
            matrix2.FillMatrix();
            matrix1.Print();
            Console.WriteLine();
            matrix2.Print();
            Console.WriteLine();
            matrix3 = matrix1 * 2;
            matrix3.Print();
            Console.WriteLine();
            Console.WriteLine(matrix3[1, 1]);

            Console.WriteLine("TASK 2");

            List<Car> cars = new List<Car>();
            Car test_car1 = new Car("Acar", 1990, 220);
            cars.Add(test_car1);
            Car test_car2 = new Car("Dcar", 1899, 320);
            cars.Add(test_car2);
            Car test_car3 = new Car("Bcar", 2010, 115);
            cars.Add(test_car3);
            foreach (Car cars_ in cars)
            {
                Console.WriteLine(cars_.Name);
                Console.WriteLine(cars_.ProductionYear);
                Console.WriteLine(cars_.MaxSpeed);
            }
            Console.WriteLine("Choose a comparison option: \n1) Names \n2) Production Year \n3) Max speed");
            string choise = Convert.ToString(Console.ReadLine());
            switch (choise)
            {
                case "Names":
                    {
                        CarNamesComparer<Car> sorting = new CarNamesComparer<Car>();
                        cars.Sort(sorting);
                        Console.WriteLine("Result: ");
                        foreach (Car index in cars)
                        {
                            Console.WriteLine(index.Name);
                            Console.WriteLine(index.ProductionYear);
                            Console.WriteLine(index.MaxSpeed);
                            Console.WriteLine();
                        }
                        break;
                    }
                case "Production Year":
                    {
                        CarProductionYearComparer<Car> sorting = new CarProductionYearComparer<Car>();
                        cars.Sort(sorting);
                        Console.WriteLine("Result: ");
                        foreach (Car index in cars)
                        {
                            Console.WriteLine(index.Name);
                            Console.WriteLine(index.ProductionYear);
                            Console.WriteLine(index.MaxSpeed);
                            Console.WriteLine();
                        }
                        break;
                    }
                case "Max speed":
                    {
                        CarMaxSpeedComparer<Car> sorting = new CarMaxSpeedComparer<Car>();
                        cars.Sort(sorting);
                        Console.WriteLine("Result: ");
                        foreach (Car index in cars)
                        {
                            Console.WriteLine(index.Name);
                            Console.WriteLine(index.ProductionYear);
                            Console.WriteLine(index.MaxSpeed);
                            Console.WriteLine();
                        }
                        break;
                    }
                default:
                    throw new Exception("Error");
                    break;
            }

            Console.WriteLine("TASK 3");

            CarCatalog carCatalog = new CarCatalog(cars);
            Console.WriteLine("simple: ");
            foreach(var car in carCatalog)
            {
                Console.WriteLine(car.Name + " " + car.ProductionYear + " " + car.MaxSpeed);
            }
            Console.WriteLine("reverse: ");
            foreach (var car in carCatalog.Reverse())
            {
                Console.WriteLine(car.Name + " " + car.ProductionYear + " " + car.MaxSpeed);
            }
            Console.WriteLine("subset with year: ");
            foreach (var car in carCatalog.Subset())
            {
                Console.WriteLine(car.Name + " " + car.ProductionYear + " " + car.MaxSpeed);
            }
            Console.WriteLine("subset with max_speed: ");
            foreach (var car in carCatalog.Subset(200))
            {
                Console.WriteLine(car.Name + " " + car.ProductionYear + " " + car.MaxSpeed);
            }
        }
    }
}
