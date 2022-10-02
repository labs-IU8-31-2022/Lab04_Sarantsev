using System;
using System.Linq;
using System.Collections;
using System.Xml.Linq;

namespace lab04
{
    public class Car
    {
        public List<string> CarsName;
        public Car(string name, int year, int max_speed)
        {
            Name = name;
            ProductionYear = year;
            MaxSpeed = max_speed;
        }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }
        public List<string> CarsNames { get; set; }
        public void FillCarsNames()
        {
            for (int i = 0; i < CarsName.Count; ++i)
            {
                CarsNames.Add(Name);
            }
        }
    }
    public class CarProductionYearComparer<T>: IComparer<T>
        where T: Car
    {
        public int Compare(T obj1, T obj2)
        {
            if (obj1.ProductionYear > obj2.ProductionYear)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }
    public class CarMaxSpeedComparer<T> : IComparer<T>
        where T : Car
    {
        public int Compare(T obj1, T obj2)
        {
            if (obj1.MaxSpeed > obj2.MaxSpeed)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class CarNamesComparer<T> : IComparer<T>
        where T : Car
    {
        public int Compare(T obj1, T obj2)
        {
            return obj1.Name.CompareTo(obj2.Name);
        }
    }

    public class CarCatalog
    {
        private List<Car> cars_ = new List<Car>();
        public CarCatalog(List<Car> input_cars)
        {
            foreach(Car i in input_cars)
            {
                cars_.Add(i);
            }
        }
        public void Passage()
        {
            Console.WriteLine("Choose the passage variant: ");
            int choise = Convert.ToInt16(Console.ReadLine());
            switch(choise)
            {
                case 1:
                    foreach (Car i in cars_)
                    {
                        Console.WriteLine(i.Name + " " + i.ProductionYear + " " + i.MaxSpeed);
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    {
                        foreach (Car i in cars_.Reverse<Car>())
                        {
                            Console.WriteLine(i.Name + " " + i.ProductionYear + " " + i.MaxSpeed);
                            Console.WriteLine();
                        }
                        break;
                    }
                case 3:
                    {
                        var selected_car = cars_.Where(cars => (cars.ProductionYear < 2000));
                        foreach (Car i in selected_car)
                        {
                            Console.WriteLine(i.Name + " " + i.ProductionYear + " " + i.MaxSpeed);
                            Console.WriteLine();
                        }
                        break;
                    }
                case 4:
                    {
                        var selected_car = cars_.Where(cars => (cars.MaxSpeed >100));
                        foreach (Car i in selected_car)
                        {
                            Console.WriteLine(i.Name + " " + i.ProductionYear + " " + i.MaxSpeed);
                            Console.WriteLine();
                        }
                        break;
                    }
                default:
                    break;
            }
        } 
    }
}

