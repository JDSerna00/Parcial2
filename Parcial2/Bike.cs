﻿using System;
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
        }
    }
}
