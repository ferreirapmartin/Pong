using System;
using Pong.Comun;

namespace Pong.Elementos
{
    public interface IElemento
    {
        event EventHandler<ChocadoEventArgs> Chocado;

        Coordenada Posicion { get; }

        Dimension Dimension { get; }

        Coordenada Velocidad { get; }

        Coordenada Choque(IElemento elemento);
    }
}
