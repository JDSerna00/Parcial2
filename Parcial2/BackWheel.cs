using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class BackWheel : Parts
    {
        public BackWheel()
        {

        }

        public double ModifyGrip()
        {
            return (FrontWheelValue + BackWheelValue) / 2.0;
        }
    }
}
