namespace Pong.Comun
{
    public class Coordenada
    {
        public Coordenada(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public override bool Equals(object obj)
        {
            Coordenada coordenada = obj as Coordenada;
            if (obj == null) return false;
            return this.X == coordenada.X && this.Y == coordenada.Y;
        }

        public override int GetHashCode()
        {
            return $"{this.X},{this.Y}".GetHashCode();
        }
    }
}
