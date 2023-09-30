using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Engine : Parts
    {
        public Engine(double speed, double acceleration)
        : base(0.0, 0.0, speed, acceleration)
        {
            Grip = 0.0; // Engine no modifica Grip
        }

        public double ModifySpeed()
        {
            return Speed;
        }
    }
}
