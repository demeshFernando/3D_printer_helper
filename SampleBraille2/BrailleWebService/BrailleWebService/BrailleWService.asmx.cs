using BrailleWebService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BrailleWebService
{
    /// <summary>
    /// Summary description for BrailleWService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BrailleWService : System.Web.Services.WebService
    {
        
        [WebMethod]
        public List<string> Shapes()
        {
            return ShapeFactory.getShapes();
        }


        [WebMethod]
        public string[] parameters(String shape)
        {
            try
            {
                IShape sh = ShapeFactory.CreateShape(shape);
                return sh.getParameters();

            } 
            catch(ArgumentException e)
            {
                return new string[] { };
            }
        }

        [WebMethod]
        public double circumference(double radius)
        {
            double circum;
                circum = 2 * 22.0 / 7 * radius;
            return circum;
        }

        [WebMethod]
        public double perimeter(string shape, double length, double breadth)
        {
            double perimeter;

            if (shape.Equals("square"))
            {
                perimeter = length * 4;
            }
            else if (shape.Equals("rectangle"))
            {
                perimeter = (length + breadth) * 2;
            }
            else if (shape.Equals("triangle"))
            {
                perimeter = length * 3;
            }
            else
            {
                perimeter = -1;
            }

            return perimeter;

        }

        [WebMethod]
        public int reqDotAmount(double perimeter)
        {
            int dotAmount= Convert.ToInt32(perimeter/0.25);
             return dotAmount;

        }

    }
}
