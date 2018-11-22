namespace Pong.Comun
{
    public class Dimension
    {
        public Dimension(int ancho, int altura)
        {
            this.Ancho = ancho;
            this.Altura = altura;
        }

        public int Ancho { get; private set; }

        public int Altura { get; private set; }

        public override bool Equals(object obj)
        {
            Dimension coordenada = obj as Dimension;
            if (obj == null) return false;
            return this.Ancho == coordenada.Ancho && this.Altura == coordenada.Altura;
        }

        public override int GetHashCode()
        {
            return $"{this.Ancho},{this.Altura}".GetHashCode();
        }
    }
}
