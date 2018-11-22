using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick
{
    public interface IJoystick
    {
        event EventHandler<MovimientoEventArgs> Movimiento;

        JoystickPosicion Posicion { get; }
    }
}
