using System;

namespace Joystick.Analogico
{
    internal class AnalogicoHelper
    {
        public static JoystickPosicion DeterminarPosicion(AnalogicoEstado estado)
        {
            int minValue = 300;
            int maxValue = 700;

            if (estado.X > maxValue)
            {
                if (estado.Y < minValue)
                {
                    return JoystickPosicion.AbajoIzquierda;
                }

                if (estado.Y > maxValue)
                {
                    return JoystickPosicion.ArribaIzquierda;
                }

                return JoystickPosicion.Izquierda;
            }

            if (estado.X < minValue)
            {
                if (estado.Y < minValue)
                {
                    return JoystickPosicion.AbajoDerecha;
                }

                if (estado.Y > maxValue)
                {
                    return JoystickPosicion.ArribaDerecha;
                }

                return JoystickPosicion.Derecha;
            }

            if (estado.Y < minValue)
            {
                return JoystickPosicion.Abajo;
            }

            if (estado.Y > maxValue)
            {
                return JoystickPosicion.Arriba;
            }

            return JoystickPosicion.Centro;
        }

        public static AnalogicoEstado ParsearLinea(string linea)
        {
            string[] values = linea.Split(',');

            return new AnalogicoEstado(int.Parse(values[0]), int.Parse(values[1]), values[2] == "0");
        }
    }
}
