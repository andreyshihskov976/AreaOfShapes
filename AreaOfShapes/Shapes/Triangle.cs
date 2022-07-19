using AreaOfShapes.Interfaces;

namespace AreaOfShapes.Shapes
{
    public class Triangle : ITriangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        private readonly Lazy<bool> _isRightTriangle;
		public bool IsRightTriangle => _isRightTriangle.Value;

        public Triangle()
        {
            SideA = default(double);
            SideB = default(double);
            SideC = default(double);

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }

        public Triangle(double sideA, double sideB, double sideC)
        {

            if (sideA < Constants.CalculationAccuracy)
				throw new ArgumentException("Incorrect side specified.", nameof(sideA));

			if (sideB < Constants.CalculationAccuracy)
				throw new ArgumentException("Incorrect side specified.", nameof(sideB));

			if (sideC < Constants.CalculationAccuracy)
				throw new ArgumentException("Incorrect side specified.", nameof(sideC));

			var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
			var perimeter = sideA + sideB + sideC;
			if ((perimeter - maxSide) - maxSide < Constants.CalculationAccuracy)
				throw new ArgumentException("The longest side of the triangle must be less than the sum of the other sides.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }

        public double GetArea()
        {
            var halfP = (SideA + SideB + SideC) / 2d;
            return Math.Sqrt(halfP * (halfP - SideA) * (halfP - SideB) * (halfP - SideC));
        }

        public bool GetIsRightTriangle()
        {
            double maxSide = SideA;
            double b = SideB;
            double c = SideC;
			if (b - maxSide > Constants.CalculationAccuracy)
				Utils.Swap(ref maxSide, ref b);

			if (c - maxSide > Constants.CalculationAccuracy)
				Utils.Swap(ref maxSide, ref c);

			return Math.Abs(Math.Pow(maxSide, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
        }
    }
}