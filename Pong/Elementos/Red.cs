using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Comun;

namespace Pong.Elementos
{
    public class Red : IElemento
    {
        public Red(Dimension dimension, Coordenada posicion)
        {
            this.Posicion = posicion;
            this.Dimension = dimension;
            this.Velocidad = new Coordenada(0, 0);
        }

        public event EventHandler<ChocadoEventArgs> Chocado;

        public Coordenada Posicion { get; private set; }

        public Dimension Dimension { get; private set; }

        public Coordenada Velocidad { get; private set; }

        public Coordenada Choque(IElemento elemento)
        {
            this.Chocado?.Invoke(this, new ChocadoEventArgs(elemento));
            return new Coordenada(elemento.Velocidad.X * -1, elemento.Velocidad.Y);
        }
    }
}
