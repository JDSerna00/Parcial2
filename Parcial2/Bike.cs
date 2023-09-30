using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Bike
    {
        public FrontWheel FrontWheel { get; set; }
        public BackWheel BackWheel { get; set; }
        public Chassis Chassis { get; private set; }
        public Engine Engine { get; set; }
        public Muffler Muffler { get; set; }

        public double Speed { get; private set; }
        public double Acceleration { get; private set; }
        public double Handling { get; private set; }
        public double Grip { get; private set; }

        public Bike(Chassis chassis = null)
        {
            Speed = 1.0;
            Acceleration = 1.0;
            Handling = 1.0;
            Grip = 1.0;

            Chassis = chassis ?? new Chassis();

            if (FrontWheel == null || BackWheel == null || Engine == null || Muffler == null)
            {
                throw new InvalidOperationException("La moto no tiene todas las partes requeridas.");
            }

            if (Speed == 0.0 || Acceleration == 0.0 || Handling == 0.0 || Grip == 0.0)
            {
                throw new InvalidOperationException("Ninguna parte de la moto puede tener un valor de 0.0.");
            }

            if (Engine == null)
            {
                Speed = 0.0;
            }

            if (FrontWheel == null || BackWheel == null)
            {
                Acceleration = 0.0;
            }

            if (FrontWheel == null && BackWheel == null)
            {
                Acceleration = 0.0;
                Handling = 0.0;
                Grip = 0.0;
            }

            if (Muffler == null)
            {
                Acceleration /= 2.0;
            }
        }
    }
}
