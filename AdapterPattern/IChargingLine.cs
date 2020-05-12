using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface IChargingLine
    {
        void Charging();
    }

    public class USBMicroLine : IChargingLine
    {
        public void Charging()
        {
            Console.WriteLine("USB-Micro");
        }
    }

    public class USBLine
    {
        public void Charge()
        {
            Console.WriteLine("Charging for device");
        }
    }

    public class USBlightingLineAdapter : USBLine, IChargingLine
    {
        public void Charging()
        {
            Console.WriteLine("USB-Lighting");
            base.Charge();            
        }
    }

    public class USBTypecLineAdapter : IChargingLine
    {
        private readonly USBLine _usbLine;

        public USBTypecLineAdapter(USBLine usbLine)
        {
            this._usbLine = usbLine;
        }

        public void Charging()
        {
            Console.WriteLine("USB-TypeC");
            this._usbLine.Charge();
        }
    }

}
