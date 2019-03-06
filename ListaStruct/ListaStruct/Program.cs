using System;
using System.Collections.Generic;

namespace ListaStruct
{
    class Program
    {
        struct A
        {
            public int NumeroUno;
            public int NumeroDos;
        }
        static void Main(string[] args)
        {
            var lista = new List<A>
            {
                new A{NumeroUno = 1, NumeroDos = 2}, new A{NumeroUno = 3, NumeroDos = 4}
            };
            for (var i = 0; i < lista.Count; i++)
            {
                var viejo = lista[i];
                lista[i] = new A { NumeroUno = viejo.NumeroUno * 2, NumeroDos = viejo.NumeroDos * 2 };
            }
            lista.ForEach(x => Console.WriteLine(x.NumeroUno));
            Console.ReadKey();
        }
    }
}
