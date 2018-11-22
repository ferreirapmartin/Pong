using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick
{
    public abstract class Joystick : IJoystick
    {
        public event EventHandler<MovimientoEventArgs> Movimiento;

        public JoystickPosicion Posicion { get; protected set; }

        protected void CheckPosicion(JoystickPosicion nuevaPosicion)
        {
            this.Posicion = nuevaPosicion;
            this.Movimiento?.Invoke(this, new MovimientoEventArgs(nuevaPosicion));
        }
    }
}
