using System;
using System.Collections.Generic;
using System.Linq;
using Pong.Comun;

namespace Pong.Elementos
{
    public class Pelota : Elemento
    {
        private Coordenada posicionInicial;
        private IEnumerable<IElemento> entorno;

        public Pelota(IEnumerable<IElemento> entorno, Dimension dimension, Coordenada posicion, Coordenada velocidad) : base(dimension, posicion, velocidad)
        {
            this.entorno = entorno;
            this.posicionInicial = posicion;
        }

        public void Tick()
        {
            this.Posicion = new Coordenada(this.Posicion.X + this.Velocidad.X, this.Posicion.Y + this.Velocidad.Y);
        }

        public override Coordenada Choque(IElemento elemento) => throw new NotImplementedException();

        protected override bool PuedeRealizarMovimiento(Coordenada coordenada)
        {
            this.DeterminarVelocidad(coordenada);
            return true;
        }

        private void DeterminarVelocidad(Coordenada coordenada)
        {
            IElemento choque = this.entorno.FirstOrDefault(i => ChoqueHelper.ExisteChoque(i, this.Dimension, coordenada));
            if (choque != null)
                this.Velocidad = choque.Choque(this);
        }
    }
}
