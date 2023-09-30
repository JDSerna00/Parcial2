using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public abstract class Parts
    {
        public double Grip { get; set; }
        public double Handling { get; set; }
        public double Speed { get; set; }
        public double Acceleration { get; set; }
        protected Parts(double grip, double handling, double speed, double acceleration)
        {
            if (grip > 5.0 || handling > 5.0 || speed > 5.0 || acceleration > 5.0)
            {
                throw new ArgumentException("Los valores de los parámetros no pueden ser superiores a 5.0.");
            }

            if (grip + handling + speed + acceleration > 10.0)
            {
                throw new ArgumentException("La suma de los valores de los parámetros no puede ser superior a 10.0.");
            }

            Grip = grip;
            Handling = handling;
            Speed = speed;
            Acceleration = acceleration;
            //La construcción de Parts como una clase abstracta permite integrar a futuro opciones como manufacturer, material, weight 
            //A su vez impide que se pueda crear un objeto Parts pues no tiene ningún sentido           
        }
    }
}
