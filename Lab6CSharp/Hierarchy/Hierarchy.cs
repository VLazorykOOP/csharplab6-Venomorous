using System;
using System.Linq;

namespace Hierarchy
{
    interface IShowable
    {
        void Show();
    }

    interface ISearchable
    {
        bool MatchesSearch(string searchTerm);
    }

    class Place : IShowable, ISearchable
    {
        protected string name;

        public Place()
        {
            this.name = "Unknown";
        }

        public Place(string name)
        {
            this.name = name;
        }

        ~Place()
        {
            Console.WriteLine("Place destructor");
        }

        public virtual void Show()
        {
            Console.WriteLine($"Place: {name}");
        }

        public virtual bool MatchesSearch(string searchTerm)
        {
            return name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
        }
    }

    class Region : Place
    {
        protected string climate;

        public Region()
            : base()
        {
            this.climate = "Unknown";
        }

        public Region(string climate)
        {
            this.climate = climate;
        }

        public Region(string name, string climate)
            : base(name)
        {
            this.climate = climate;
        }

        ~Region()
        {
            Console.WriteLine("Region destructor");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Climate: {climate}");
        }
    }

    class Metropolis : Region
    {
        protected int population;

        public Metropolis()
            : base()
        {
            this.population = 0;
        }

        public Metropolis(int population)
        {
            this.population = population;
        }

        public Metropolis(string name, string climate, int population)
            : base(name, climate)
        {
            this.population = population;
        }

        ~Metropolis()
        {
            Console.WriteLine("Metropolis destructor");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Population: {population}");
        }
    }

    class City : Metropolis
    {
        protected string landmark;

        public City()
            : base()
        {
            this.landmark = "Unknown";
        }

        public City(string landmark)
        {
            this.landmark = landmark;
        }

        public City(string name, string climate, int population, string landmark)
            : base(name, climate, population)
        {
            this.landmark = landmark;
        }

        ~City()
        {
            Console.WriteLine("City destructor");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Landmark: {landmark}");
        }
    }

    class Program
    {
        public static void PrintOrderedArray(Place[] places)
        {
            var orderedArray = places.OrderBy(place => place.GetType().Name);

            foreach (var place in orderedArray)
            {
                place.Show();
                Console.WriteLine("------------------------------");
            }
        }

        public static void SearchAndDisplay(Place[] places, string searchTerm)
        {
            foreach (var place in places)
            {
                if (place.MatchesSearch(searchTerm))
                {
                    place.Show();
                    Console.WriteLine("------------------------------");
                }
            }
        }

        public static void Task()
        {
            Place[] places = new Place[4];

            places[0] = new Place("Nature Reserve");
            places[1] = new Region("Mountainous Region", "Cool");
            places[2] = new Metropolis("Metropolis A", "Temperate", 5000000);
            places[3] = new City("City X", "Warm", 100000, "City Park");

            PrintOrderedArray(places);

            Console.Write("Enter a name to search: ");
            string searchname = Console.ReadLine();

            Console.WriteLine("\nSearch Results:");
            SearchAndDisplay(places, searchname);
        }
    }
}
