using System.Text.Json;
namespace DesignPattern.Pattern.Structural
{
    internal class FlyweightDesignPattern
    {
        public class FlyweightFactory
        {
            public static void addCarToPoliceDatabase(FlyweightFactory factory, Car car)
            {
                Console.WriteLine("\nClient: Adding a car to database.");

                var flyweight = factory.GetFlyweight(new Car
                {
                    Color = car.Color,
                    Model = car.Model,
                    Company = car.Company
                });

                flyweight.Operation(car);
            }

            private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

            public FlyweightFactory(params Car[] args)
            {
                foreach (var elem in args)
                {
                    flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
                }
            }

            public string getKey(Car key)
            {
                List<string> elements = new List<string>();

                elements.Add(key.Model);
                elements.Add(key.Color);
                elements.Add(key.Company);

                if (key.Owner != null && key.Number != null)
                {
                    elements.Add(key.Number);
                    elements.Add(key.Owner);
                }

                elements.Sort();

                return string.Join("_", elements);
            }

            public Flyweight GetFlyweight(Car sharedState)
            {
                string key = this.getKey(sharedState);

                if (flyweights.Where(t => t.Item2 == key).Count() == 0)
                {
                    Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                    this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
                }
                else
                {
                    Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
                }
                return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
            }

            public void listFlyweights()
            {
                var count = flyweights.Count;
                Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
                foreach (var flyweight in flyweights)
                {
                    Console.WriteLine(flyweight.Item2);
                }
            }
        }
        public class Car
        {
            public string Owner { get; set; }

            public string Number { get; set; }

            public string Company { get; set; }

            public string Model { get; set; }

            public string Color { get; set; }
        }

        public class Flyweight
        {
            private Car _sharedState;

            public Flyweight(Car car)
            {
                this._sharedState = car;
            }

            public void Operation(Car uniqueState)
            {
                string s = JsonSerializer.Serialize(this._sharedState);
                string u = JsonSerializer.Serialize(uniqueState);
                Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
            }
        }
    }
}
