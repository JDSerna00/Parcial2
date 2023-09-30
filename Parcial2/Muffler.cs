using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Muffler : Parts
    {
        public Muffler(double grip, double handling)
        : base(grip, handling, 0.0, 0.0)
        {
            Speed = 0.0; // Muffler no modifica Speed
            Acceleration = 0.0; // Muffler no modifica Acceleration
        }
    }
}
