using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrailleWebService.models
{
    public class ShapeFactory
    {
        public static List<string> getShapes()
        {
            List<string> shapes = new List<string>();
            foreach (Type type in typeof(IShape).Assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract && typeof(IShape).IsAssignableFrom(type))
                {
                    shapes.Add(type.Name.ToLower());
                }
            }
            return shapes;
        }
        public static IShape CreateShape(string type)
        {
            switch (type.ToLower())
            {
                case "circle": return new Circle();
                case "square": return new Square();
                case "rectangle": return new Rectangle();
                case "triangle":return new Triangle();

                default: throw new ArgumentException("Invalid shape type");
            }
        }
        public static IShape CreatePerimeter(string shape)
        {
            switch (shape.ToLower())
            {
                case "circle":
                    return new Circle();
                case "square":
                    return new Square();
                case "rectangle":
                    return new Rectangle();
                case "triangle":
                    return new Triangle();
                default:
                    throw new ArgumentException("Invalid shape name");
            }
        }
    }
}