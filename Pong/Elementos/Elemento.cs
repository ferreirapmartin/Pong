using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Comun;

namespace Pong.Elementos
{
    public abstract class Elemento : IElemento
    {
        private Coordenada posicion;

        public Elemento(Dimension dimension, Coordenada posicion) : this(dimension, posicion, new Coordenada(0, 0))
        {
        }

        public Elemento(Dimension dimension, Coordenada posicion, Coordenada velocidad)
        {
            this.Dimension = dimension;
            this.posicion = posicion;
            this.Velocidad = velocidad;
        }

        public event EventHandler<ChocadoEventArgs> Chocado;

        public Coordenada Posicion
        {
            get
            {
                return this.posicion;
            }

            protected set
            {
                if (this.PuedeRealizarMovimiento(value))
                    this.posicion = value;
            }
        }

        public Dimension Dimension { get; protected set; }

        public Coordenada Velocidad { get; protected set; }

        public abstract Coordenada Choque(IElemento elemento);

        protected void OnChocado(ChocadoEventArgs chocadoEventArgs)
        {
            this.Chocado?.Invoke(this, chocadoEventArgs);
        }

        protected virtual bool PuedeRealizarMovimiento(Coordenada coordenada) => true;
    }
}
