using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Car : IEquatable<Car>
    {
        public Car(string manufacture, string model, int maxSpeed)
        {
            Manufacture = manufacture;
            Model = model;
            MaxSpeed = maxSpeed;
        }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public int MaxSpeed { get; set; }

        public bool Equals(Car other)
        {
            return this.Manufacture == other.Manufacture
                && this.Model == other.Model
                && this.MaxSpeed == other.MaxSpeed;
        }
        public override int GetHashCode() => (Manufacture, Model, MaxSpeed).GetHashCode();
    }
}
