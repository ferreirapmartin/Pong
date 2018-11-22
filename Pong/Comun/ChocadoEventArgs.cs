using System;
using Pong.Elementos;

namespace Pong.Comun
{
    public class ChocadoEventArgs : EventArgs
    {
        public ChocadoEventArgs(IElemento elemento) : base()
        {
            this.Elemento = elemento;
        }

        public IElemento Elemento { get; }
    }
}
