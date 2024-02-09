using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrailleWebService.models
{
    public abstract class Shape : IShape
    {
        protected string[] parameters;

        public virtual string[] getParameters() // virtual is to let sub classes to override the method
        {
            return parameters;
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            parameters = new string[] { "radius"};
        }
    }
    public class Square : Shape
    {
        public Square()
        {
            parameters = new string[] { "side-length" };
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle()
        {
            parameters = new string[] { "length", "breadth" };
        }
    }
    public class Triangle : Shape
    {
        public Triangle()
        {
            parameters = new string[] { "side-length" };
        }
    }

    public class Parallelogram : Shape
    {
        public Parallelogram()
        {
         
           parameters = new string[] { "length", "breadth" };
        }
    }
}