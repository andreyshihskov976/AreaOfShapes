using AreaOfShapes.Interfaces;

namespace AreaOfShapes.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle()
        {
            Radius = default(double);
        }

        public Circle(double radius)
        {
            if (radius - Constants.MinRadius < Constants.CalculationAccuracy)
				throw new ArgumentException("Неверно указан радиус круга.", nameof(radius));
			Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}