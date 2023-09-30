using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class BackWheel : Parts
    {
        public BackWheel(double grip, double handling, double speed, double acceleration)
        : base(grip, handling, speed, acceleration)
        {

        }

        public double ModifyGrip()
        {
            return Grip;
        }
    }
}
