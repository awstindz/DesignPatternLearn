using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            USBLine usbLine = new USBLine();
            usbLine.Charge();
            Console.WriteLine("---------------------");

            //USB-Micro
            IChargingLine microLine = new USBMicroLine();
            microLine.Charging();

            Console.WriteLine("---------------------");
            Console.WriteLine("object design pattern");
            IChargingLine typeCLineAdapter = new USBTypecLineAdapter(usbLine);
            typeCLineAdapter.Charging();

            Console.WriteLine("---------------------");
            Console.WriteLine("Class Adapter design pattern");
            IChargingLine lightingLineAdapter = new USBlightingLineAdapter();
            lightingLineAdapter.Charging();

            Console.ReadLine();
        }
    }
}
