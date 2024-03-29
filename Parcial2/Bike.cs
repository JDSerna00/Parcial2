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

        public void AddPart(Parts part)
        {
            if (part == null)
            {
                throw new ArgumentNullException("La pieza no puede ser nula.");
            }


            // Sumar los parámetros de la pieza a los parámetros de la moto
            Speed += part.Speed;
            Acceleration += part.Acceleration;
            Handling += part.Handling;
            Grip += part.Grip;
        }
        public void AddChassis(Chassis chassis)
        {
            if (Chassis != null)
            {
                throw new InvalidOperationException("No se puede reemplazar el chasis existente.");
            }

            Chassis = chassis;
        }
        public bool CanBeUsedInRace()
        {
            // Verifica si la moto tiene todas sus partes esenciales para ser utilizada en una carrera.
            return FrontWheel != null && BackWheel != null && Engine != null && Muffler != null;
        }
        public Bike(Engine engine, Muffler muffler,FrontWheel frontWheel, BackWheel backWheel, Chassis chassis)
        {
            Speed = 1.0;
            Acceleration = 1.0;
            Handling = 1.0;
            Grip = 1.0;

            Muffler = muffler;
            FrontWheel = frontWheel;
            BackWheel = backWheel;
            Engine = engine;
            Chassis = chassis ?? new Chassis();


            if (Speed == 0.0 || Acceleration == 0.0 || Handling == 0.0 || Grip == 0.0)
            {
                throw new InvalidOperationException("Ningún parámetro puede tener un valor de 0.0.");
            }

            if (Engine == null)
            {
                Speed = 0.0;
            }
            else 
            {
                //Speed += Engine.ModifySpeed();
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
            else 
            {
                //Handling += FrontWheel.ModifyHandling();
                //Grip += BackWheel.ModifyGrip();
            }

            if (Muffler == null)
            {
                Acceleration /= 2.0;
            }
            else 
            {
                //Acceleration += Muffler.ModifyAcceleration();
            }
        }
    }
}
