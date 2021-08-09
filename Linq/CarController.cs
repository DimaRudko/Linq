using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class CarController
    {
        public IEnumerable<string> GroupCarsByManufacturer(int minimumSpeed, List<Car> cars)
        {
            return cars.Where(c => c.MaxSpeed > minimumSpeed)
                .GroupBy(c => c.Manufacture)
                .Select(i => new
                {
                    Manufacture = i.Key,
                    MinMaxSpeed = i.Min(p => p.MaxSpeed).ToString(),
                    AverageSpeed = i.Average(p => p.MaxSpeed).ToString(),
                    MaxSpeed = i.Max(p => p.MaxSpeed).ToString()
                })
                .Select((x) => string.Join(" => ", x.Manufacture, x.MinMaxSpeed, x.AverageSpeed, x.MaxSpeed));
        }

        public bool CollectionHasCarWithMaxSpeedMoreThanMinMaxSpeed(IEnumerable<Car> cars, int minMaxSpeed)
        {
            return cars.Any(p => p.MaxSpeed > minMaxSpeed);
        }
        public bool AllCarsHasMaxSpeedMoreThanMinMaxSpeed(IEnumerable<Car> cars, int minMaxSpeed)
        {
            return cars.All(p => p.MaxSpeed > minMaxSpeed);
        }
        public IEnumerable<Car> PaginateCars(IEnumerable<Car> cars, int take, int page)
        {
            return cars.Skip( (page-1)* take).Take(take);
        }
    }
}
