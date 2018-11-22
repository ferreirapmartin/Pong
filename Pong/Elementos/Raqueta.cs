using System;
using System.Collections.Generic;
using System.Linq;
using Pong.Comun;

namespace Pong.Elementos
{
    public class Raqueta : Elemento
    {
        private IEnumerable<IElemento> entorno;
        private int seccion;

        public Raqueta(IEnumerable<IElemento> entorno, Coordenada posicion, Dimension dimension, Coordenada velocidad)
            : base(dimension, posicion, velocidad)
        {
            this.entorno = entorno;
            this.Goles = 0;
            this.seccion = Dimension.Altura / 3;
        }

        public event EventHandler GolRealizado;

        public int Goles { get; private set; }

        public void Mover(RaquetaDirecccionMovimiento movimiento)
        {
            this.Posicion = new Coordenada(this.Posicion.X, this.Posicion.Y + (this.Velocidad.Y * (int)movimiento));
        }

        public override Coordenada Choque(IElemento elemento)
        {
            int signo = elemento.Velocidad.X / Math.Abs(elemento.Velocidad.X);
            int velocidadX = (Math.Abs(elemento.Velocidad.X) + 1) * signo * -1, velocidadY = 1;
            int centroElemento = elemento.Posicion.Y + (elemento.Dimension.Altura / 2);

            if (centroElemento < this.Posicion.Y + this.seccion)
            {
                velocidadY = -1;
            }
            else if (centroElemento < this.Posicion.Y + (this.seccion * 2))
            {
                velocidadY = 0;
            }

            return new Coordenada(velocidadX, velocidadY);
        }

        public void Gol()
        {
            this.Goles++;
            this.GolRealizado?.Invoke(this, EventArgs.Empty);
        }

        protected override bool PuedeRealizarMovimiento(Coordenada coordenada)
        {
            return this.Posicion != coordenada && this.EsMovimientoValido(coordenada);
        }

        private bool EsMovimientoValido(Coordenada coordenada)
        {
            return this.entorno.All(i => !ChoqueHelper.ExisteChoque(i, this.Dimension, coordenada));
        }
    }
}
