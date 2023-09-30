using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class FrontWheel : Parts
    {
        public FrontWheel()
        {

        }

        public double ModifyHandling()
        {
            return (FrontWheelValue + BackWheelValue) / 2.0;
        }
    }
}
