using Pong.Elementos;

namespace Pong.Comun
{
    public class ChoqueHelper
    {
        public static bool ExisteChoque(IElemento elemento1, Dimension dimension, Coordenada posicionCandidata)
        {
            int e1_x1 = elemento1.Posicion.X;
            int e1_y1 = elemento1.Posicion.Y;
            int e1_x2 = e1_x1 + elemento1.Dimension.Ancho;
            int e1_y2 = e1_y1 + elemento1.Dimension.Altura;

            int e2_x1 = posicionCandidata.X;
            int e2_y1 = posicionCandidata.Y;
            int e2_x2 = e2_x1 + dimension.Ancho;
            int e2_y2 = e2_y1 + dimension.Altura;

            return (e2_x2 >= e1_x1 && e2_x1 <= e1_x2) && (e2_y2 >= e1_y1 && e2_y1 <= e1_y2);
        }
    }
}
