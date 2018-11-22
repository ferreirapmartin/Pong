using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick.Analogico
{
    public class JoystickAnalogico : Joystick
    {
        private SerialPort puerto;

        public JoystickAnalogico(SerialPort puerto) : base()
        {
            this.puerto = puerto;
            this.puerto.DataReceived += this.Puerto_DataReceived;
            this.puerto.Open();
        }

        private void Puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            AnalogicoEstado estado = AnalogicoHelper.ParsearLinea(this.puerto.ReadLine());
            JoystickPosicion nuevaPosicion = AnalogicoHelper.DeterminarPosicion(estado);
            this.CheckPosicion(nuevaPosicion);
            this.CheckBoton(estado.BotonPresionado);
        }

        private void CheckBoton(bool presionado)
        {
            ////TODO: ver si implementar 
        }
    }
}
