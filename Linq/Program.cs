using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>()
            {
                new Car("Opel", "mA" , 100),
                new Car("Opel", "mB" , 120),
                new Car("Opel", "mC" , 90),
                new Car("Opel", "mD" , 80),
                new Car("BMW", "mA" , 100),
                new Car("BMW", "mB" , 120),
                new Car("Opel", "mA" , 100),
                new Car("Audi", "mB" , 120),
                new Car("Audi", "mC" , 90),
                new Car("Audi", "mD" , 80),
                new Car("Audi", "mA" , 100),
                new Car("Kia", "mB" , 120),
                new Car("Kia", "mC" , 90),
                new Car("Kia", "mD" , 80),
            };

            CarController carController = new CarController();

            //1. Создать метод, который будет группировать автомобили максимальная скорость которых больше заданного значения по производителю и вернет List<string>,
            //каждый элемент которого представлен с следующем формате: "Manufacture => Min Max Speed => Average Speed => Max Speed"
            var gropedCars = carController.GroupCarsByManufacturer(80, cars);
            foreach (var item in gropedCars)
            {
                Console.WriteLine(item);
            }

            //2. Добавить ещё один список автомобилей с такими же полями и вывести следующие списки:
            List<Car> anothercars = new List<Car>()
            {
                new Car("Zaz", "m1" , 100),
                new Car("Zaz", "m2" , 90),
                new Car("Zaz", "m3" , 110),
                new Car("Opel", "mA" , 100),
                new Car("Opel", "mB" , 120),
                new Car("BMW", "mA" , 100),
                new Car("BMW", "mB" , 120),
                new Car("BMW", "mC" , 130),
                new Car("BMW", "mD" , 110),
            };

            //- Список автомобилей, которые содержатся в обоих списках
            var carsIntersect = cars.Intersect(anothercars);
            Print(carsIntersect);
            //- Список автомобилей, которые есть только в каком - то одном списке
            var carsExcept = cars.Except(anothercars);
            Print(carsExcept);
            //- Объединить списки и убрать дубликаты. Данный список должен быть отсортирован по возрастанию Manufacture и убыванию Max Speed.
            var carsUnion = cars.Union(anothercars)
                .Distinct()
                .OrderBy(p => p.Manufacture)
                .ThenByDescending(p => p.MaxSpeed);
            Print(carsUnion);

            //3.Сделать подобие постраничного отображения данных.
            //На вход поступает количество элементов на странице и номер страницы.
            //Нужно вывести пачку данных которые удовлетворяют этому условию.
            Console.WriteLine($"Enter number of elements to show on View (max = {cars.Count})");
            int showElementsOnPage = Convert.ToInt32(Console.ReadLine());
            string text = (decimal)cars.Count / showElementsOnPage > 1 ? $"Select the page from 1 to {Math.Ceiling((decimal)cars.Count / showElementsOnPage)}" : "";
            int showPage = 1;
            if (!string.IsNullOrEmpty(text))
            {
                Console.WriteLine(text);
                showPage = Convert.ToInt32(Console.ReadLine());
            }
            Print(carController.PaginateCars(cars,showElementsOnPage,showPage));

            //4. Убедиться что коллекция содержит:
            //-Xотя бы один автомобиль максимальная скорость которого больше заданного значения.
            Console.WriteLine(carController.CollectionHasCarWithMaxSpeedMoreThanMinMaxSpeed(cars,120)); //false
            Console.WriteLine(carController.CollectionHasCarWithMaxSpeedMoreThanMinMaxSpeed(anothercars, 120)); //true
            //- Все автомобили имеют максимальную скорость больше заданого значения.
            Console.WriteLine(carController.AllCarsHasMaxSpeedMoreThanMinMaxSpeed(cars,100)); //false
            Console.WriteLine(carController.AllCarsHasMaxSpeedMoreThanMinMaxSpeed(anothercars, 50)); //true
        }

        public static void Print(IEnumerable<Car> cars)
        {
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Manufacture} {item.Model} {item.MaxSpeed}");
            }
            Console.WriteLine(new string('-', 30));
        }
    }
}
