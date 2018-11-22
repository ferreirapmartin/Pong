using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joystick.Teclado
{
    public class JoystickTeclado : Joystick
    {
        public void KeyDown(object sender, KeyEventArgs e)
        {
            JoystickPosicion nuevaPosicion = TecladoHelper.DeterminarPosicion(e.KeyCode);
            this.CheckPosicion(nuevaPosicion);
            this.CheckBoton(e.KeyCode);
        }

        private void CheckBoton(Keys keyCode)
        {
            ////TODO: Ver si implementar
        }
    }
}
