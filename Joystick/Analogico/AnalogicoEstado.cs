namespace Joystick.Analogico
{
    internal class AnalogicoEstado
    {
        public AnalogicoEstado(int x, int y, bool botonPresionado)
        {
            this.X = x;
            this.Y = y;
            this.BotonPresionado = botonPresionado;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public bool BotonPresionado { get; private set; }
    }
}
