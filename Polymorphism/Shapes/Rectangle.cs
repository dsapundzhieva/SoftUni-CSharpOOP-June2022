using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
           this.Height = height;
           this.Width = width;
        }

        public double Height 
        { 
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zaro or smaller than zero!");
                }
                this.height = value;
            }
        }

        public double Width 
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zaro or smaller than zero!");
                }
                this.width = value;
            }
        }


        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
