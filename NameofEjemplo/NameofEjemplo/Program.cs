using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameofEjemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            ImprimirNombre<String>();
            Console.ReadLine();
        }
        private static void ImprimirNombre<T>()
        {
            Console.WriteLine(nameof(T));
        }
    }
}
