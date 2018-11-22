using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick
{
    public class MovimientoEventArgs : EventArgs
    {
        public MovimientoEventArgs(JoystickPosicion posicion) : base()
        {
            this.Posicion = posicion;
        }

        public JoystickPosicion Posicion { get; }
    }
}
