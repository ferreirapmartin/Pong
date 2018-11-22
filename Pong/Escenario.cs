using System;
using System.Collections.Generic;
using Pong.Comun;
using Pong.Elementos;

namespace Pong
{
    public class Escenario
    {
        public Escenario(Coordenada posicion, Dimension dimension, Dimension raquetaDimension, Dimension pelotaDimension, Dimension paredDimension, Dimension redDimension)
        {
            this.Posicion = posicion;
            this.Dimension = dimension;

            this.ParedInferior = this.CrearPared(0, paredDimension);
            this.ParedSuperior = this.CrearPared(this.Dimension.Altura - paredDimension.Altura, paredDimension);

            this.RaquetaIzquierda = this.CrearRaqueta(0, raquetaDimension);
            this.RaquetaDerecha = this.CrearRaqueta(this.Dimension.Ancho - raquetaDimension.Ancho, raquetaDimension);

            this.RedIzquierda = this.CrearRed(0, redDimension);
            this.RedDerecha = this.CrearRed(this.Dimension.Ancho - redDimension.Ancho, redDimension);

            this.Pelota = this.CrearPelota(pelotaDimension, 2);

            this.RedIzquierda.Chocado += this.RedIzquierda_Chocado;
            this.RedDerecha.Chocado += this.RedDerecha_Chocado;
        }

        public Coordenada Posicion { get; private set; }

        public Dimension Dimension { get; private set; }

        public Raqueta RaquetaIzquierda { get; private set; }

        public Raqueta RaquetaDerecha { get; private set; }

        public Red RedIzquierda { get; private set; }

        public Red RedDerecha { get; private set; }

        public Pelota Pelota { get; private set; }

        public Pared ParedSuperior { get; private set; }

        public Pared ParedInferior { get; private set; }

        public void Tick()
        {
            this.Pelota.Tick();
        }

        private void OnGol(Raqueta raqueta, int velocidadX)
        {
            raqueta.Gol();
            this.Pelota = this.CrearPelota(this.Pelota.Dimension, velocidadX);
        }

        private void RedDerecha_Chocado(object sender, ChocadoEventArgs e)
        {
            if (e.Elemento is Pelota)
                this.OnGol(this.RaquetaDerecha, 2);
        }

        private void RedIzquierda_Chocado(object sender, ChocadoEventArgs e)
        {
            if (e.Elemento is Pelota)
                this.OnGol(this.RaquetaIzquierda, -2);
        }

        private Pelota CrearPelota(Dimension pelotaDimension, int velocidadX)
        {
            Coordenada centro = new Coordenada(this.Dimension.Ancho / 2, (this.Dimension.Altura - pelotaDimension.Altura) / 2);
            Coordenada velocidadInicial = new Coordenada(velocidadX, 0);
            IEnumerable<IElemento> entorno = new List<IElemento>() { this.ParedSuperior, this.ParedInferior, this.RaquetaIzquierda, this.RaquetaDerecha, this.RedIzquierda, this.RedDerecha };
            return new Pelota(entorno, pelotaDimension, centro, velocidadInicial);
        }

        private Raqueta CrearRaqueta(int posicionX, Dimension dimension)
        {
            Coordenada posicion = new Coordenada(posicionX, (this.Dimension.Altura - dimension.Altura) / 2);
            Coordenada velocidad = new Coordenada(0, dimension.Altura / 2);
            return new Raqueta(new List<IElemento> { this.ParedSuperior, this.ParedInferior }, posicion, dimension, velocidad);
        }

        private Pared CrearPared(int posicionY, Dimension dimension)
        {
            Coordenada posicion = new Coordenada(0, posicionY);
            return new Pared(dimension, posicion);
        }

        private Red CrearRed(int posicionX, Dimension dimension)
        {
            Coordenada posicion = new Coordenada(posicionX, 0);
            return new Red(dimension, posicion);
        }
    }
}
