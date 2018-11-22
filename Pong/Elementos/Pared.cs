using Pong.Comun;

namespace Pong.Elementos
{
    public class Pared : Elemento
    {
        public Pared(Dimension dimension, Coordenada posicion) : base(dimension, posicion)
        {
        }

        public override Coordenada Choque(IElemento elemento)
        {
            this.OnChocado(new ChocadoEventArgs(elemento));
            return new Coordenada(elemento.Velocidad.X, elemento.Velocidad.Y * -1);
        }
    }
}
