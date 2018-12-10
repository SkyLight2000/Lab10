using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Animal
    {
        private int age;
        private int weight;

        public string Name { get; set; }

        public string Type { get; set; }

        public string Breed { get; set; }

        public string Color { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
                else
                    throw new InvalidAgeException();
            }
        }

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
                else
                    throw new InvalidWeightException();
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Имя: {0}\n" +
                "Вид: {1}\n" +
                "Порода: {2}\n" +
                "Цвет: {3}\n" +
                "Возраст: {4}\n" +
                "Вес: {5} кг\n", Name, Type, Breed, Color, Age, Weight
                );
        }
    }

    public class AnimalException : Exception
    {
        public AnimalException(string messange) : base(messange) { }
    }

    public class InvalidAgeException : AnimalException
    {
        public InvalidAgeException() : base("Invalid age input") { }
    }

    public class InvalidWeightException : AnimalException
    {
        public InvalidWeightException() : base("Invalid weight input") { }
    }
}