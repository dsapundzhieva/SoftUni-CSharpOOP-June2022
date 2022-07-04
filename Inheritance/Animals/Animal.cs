using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Name connot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.Age), "Age must be possitive number!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Gender), "Gender cannot be null or whitespace!");
                }
                this.gender = value;
            }
        }

        protected abstract string ProduceSound();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(this.GetType().Name)
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
