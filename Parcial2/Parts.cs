using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public abstract class Parts
    {   
        protected Parts()
        {
            //La construcción de Parts como una clase abstracta permite integrar a futuro opciones como manufacturer, material, weight 
            //A su vez impide que se pueda crear un objeto Parts pues no tiene ningún sentido           
        }
    }
}
