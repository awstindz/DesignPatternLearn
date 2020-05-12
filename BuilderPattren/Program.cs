using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattren
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            HpBuilder hpBuilder = new HpBuilder();
            DellBuilder dellBuilder = new DellBuilder();

            Computer hp = director.Construct(hpBuilder);
            hp.ShowSteps();

            Console.ReadLine();

            Computer dell = director.Construct(dellBuilder);
            dell.ShowSteps();

            Console.ReadLine();
        }
    }
}
