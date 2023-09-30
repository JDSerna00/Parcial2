using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class FrontWheel : Parts
    {
        public FrontWheel(double grip, double handling, double speed, double acceleration)
        : base(grip, handling, speed, acceleration)
        {
            Handling = handling;
        }

        public double ModifyHandling()
        {
            return Handling;
        }
    }
}
