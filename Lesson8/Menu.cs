using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    class Menu
    {
        public void Start() 
        {
            Type t = typeof(DateTime);
            foreach (var property in t.GetProperties()) Console.WriteLine(property.Name);
        }
    }
}
