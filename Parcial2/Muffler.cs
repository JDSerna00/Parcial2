﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Muffler : Parts
    {
        public Muffler()
        {

        }

        public double ModifyAcceleration()
        {
            return Acceleration;
        }
    }
}
