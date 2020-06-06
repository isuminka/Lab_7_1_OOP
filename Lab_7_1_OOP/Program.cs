using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab_7_1_OOP
{
    public class Animal : IComparable<Animal>
    {
        public string Type;
        public string Name;
        public int Age;
        public string Color;
        public double Weight;
        public Animal() { }
        public Animal(string type, string name, int age, string color, double weight)
        {
            this.Type = type;
            this.Name = name;
            this.Age = age;
            this.Color = color;
            this.Weight = weight;

        }

        virtual public void Show()
        {
            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", Type, Name, Color, Age, Weight);

        }

        public class CompareByAgeAndWeight : IComparer<Animal>
        {
            int IComparer<Animal>.Compare(Animal ob1, Animal ob2)
            {
                Animal p1 = ob1 as Animal;
                Animal p2 = ob2 as Animal;
                if (p1.Weight > p2.Weight && p1.Age > p2.Age) return 1;
                if (p1.Weight < p2.Weight && p1.Age < p2.Age) return -1;
                return 0;
            }
        }

        public int CompareTo(Animal ob)
        {
            Animal p = ob as Animal;
            if (p != null)
            {
                return this.Weight.CompareTo(p.Weight);
            }
            else
            {
                throw new Exception("Неможливо порiвняти!");
            }

        }
    }

    class Animals3 
    {
        private Animal[] animals;
        private int n;

        public Animals3()
        {
            animals = new Animal[10];
            n = 0;
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            for (int i = 0; i < n; ++i)
            {
                yield return animals[i];
            }
        }

        public void Add(Animal m)
        {
            if (n >= 10) return;
            animals[n] = m;
            ++n;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal an1 = new Animal("Кiт", "Мурзiк", 3, "Сiрий", 5);
            Animal an2 = new Animal("Пес", "Бобiк", 6, "Чорний", 10);
            Animal an3 = new Animal("Кiт", "Вася", 2, "Бiлий", 4);
            Animal an4 = new Animal("Папуга", "Кеша", 1, "Зелений", 0.3);
            Animal an5 = new Animal("Пес", "Мухтар", 7, "Коричневий", 6);
            Animal an6 = new Animal("Кiт", "Мурчик", 4, "Сiрий", 4);
            Animal an7 = new Animal("Хом'як", "Гоша", 1, "Рудий", 0.2);
            Animal an8 = new Animal("Кiт", "Барсiк", 7, "Бiлий", 6);
            Animal an9 = new Animal("Папуга", "Ара", 1, "Бiлий", 0.5);
            Animal an10 = new Animal("Пес", "Арчi", 2, "Коричневий", 4);

            Animal[] animals = new Animal[10];
            animals[0] = an1;
            animals[1] = an2;
            animals[2] = an3;
            animals[3] = an4;
            animals[4] = an5;
            animals[5] = an6;
            animals[6] = an7;
            animals[7] = an8;
            animals[8] = an9;
            animals[9] = an10;


            IList<Animal> animals3 = new List<Animal>();
            animals3.Add(an1);
            animals3.Add(an2);
            animals3.Add(an3);
            animals3.Add(an4);
            animals3.Add(an5);
            animals3.Add(an6);
            animals3.Add(an7);
            animals3.Add(an8);
            animals3.Add(an9);
            animals3.Add(an10);

            Console.WriteLine("Оберiть: ");
            Console.WriteLine("1 - Порiвняння тварин за вагою (IComparable)");
            Console.WriteLine("2 - Порiвняння тварин за вагою та зростом (IComparer)");
            Console.WriteLine("3 - Список тварин, впорядкованих за вагою (IEnumerable)");
            Console.WriteLine("Ваш вибiр: ");

            int k = Convert.ToInt32(Console.ReadLine());
            if (k == 1)
            {
                Array.Sort(animals);
                foreach (Animal elem in animals)
                {
                    elem.Show();
                }
            }
            else if (k == 2)
            {
                Array.Sort(animals, new Animal.CompareByAgeAndWeight());
                foreach (Animal elem in animals)
                {
                    elem.Show();
                }
            }

            else if (k == 3)
            {
                var sortedAnimals = animals3.OrderBy(animal => animal.Weight);

                foreach (Animal b in sortedAnimals)
                {
                    b.Show();
                }

            }
        }
    }
}
