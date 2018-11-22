using System.IO.Ports;

namespace Display
{
    public class Display7Segmentos : IDisplay
    {
        private SerialPort puerto;

        public Display7Segmentos(SerialPort puerto)
        {
            this.puerto = puerto;
        }

        public void MostrarNumero(int numero)
        {
            this.puerto.Write(numero.ToString());
        }
    }
}
