using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joystick.Teclado
{
    public class TecladoHelper
    {
        public static JoystickPosicion DeterminarPosicion(Keys keyCode)
        {
            JoystickPosicion nuevaPosicion;
            switch (keyCode)
            {
                case Keys.Up:
                    nuevaPosicion = JoystickPosicion.Arriba;
                    break;
                case Keys.Down:
                    nuevaPosicion = JoystickPosicion.Abajo;
                    break;
                default:
                    nuevaPosicion = JoystickPosicion.Centro;
                    break;
            }

            return nuevaPosicion;
        }
    }
}
