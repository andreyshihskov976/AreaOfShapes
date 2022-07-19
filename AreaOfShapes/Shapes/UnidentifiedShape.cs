using AreaOfShapes.Interfaces;

namespace AreaOfShapes.Shapes
{
    public class UnidentifiedShape : IShape
    {
        private IShape shape;

        public UnidentifiedShape(IShape figure)
        {
            shape = figure;
        }

        public double GetArea()
        {
            return shape.GetArea();
        }
    }
}