﻿
namespace Shapes
{
    using System;
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius cannot be zaro or smaller than zero!");
                }
                this.radius = value;
            }
        }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
