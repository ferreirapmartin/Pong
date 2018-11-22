using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using Display;
using Joystick.Analogico;
using Joystick.Teclado;
using Pong.Comun;
using Pong.Elementos;

namespace Pong
{
    public partial class EscenarioForm : Form
    {
        private Escenario escenario;
        private Bitmap buffer;
        private JoystickTeclado joystick;
        private JoystickAnalogico joystickAnalogico;
        private IDisplay display;
        private SerialPort puerto;

        public EscenarioForm()
        {
            this.InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            this.puerto = new SerialPort("COM4", 100000);

            this.joystick = new JoystickTeclado();

            this.joystickAnalogico = new JoystickAnalogico(this.puerto);

            this.joystick.Movimiento += this.Joystick_Movimiento;

            this.display = new Display7Segmentos(this.puerto);

            this.joystickAnalogico.Movimiento += this.JoystickAnalogico_Movimiento;
        }

        private void JoystickAnalogico_Movimiento(object sender, Joystick.MovimientoEventArgs e)
        {
            switch (e.Posicion)
            {
                case Joystick.JoystickPosicion.Abajo:
                    this.escenario.RaquetaIzquierda.Mover(RaquetaDirecccionMovimiento.Abajo);
                    break;
                case Joystick.JoystickPosicion.Arriba:
                    this.escenario.RaquetaIzquierda.Mover(RaquetaDirecccionMovimiento.Arriba);
                    break;
            }
        }

        private void Joystick_Movimiento(object sender, Joystick.MovimientoEventArgs e)
        {
            switch (e.Posicion)
            {
                case Joystick.JoystickPosicion.Arriba:
                    this.escenario.RaquetaDerecha.Mover(RaquetaDirecccionMovimiento.Arriba);
                    break;
                case Joystick.JoystickPosicion.Abajo:
                    this.escenario.RaquetaDerecha.Mover(RaquetaDirecccionMovimiento.Abajo);
                    break;
            }
        }

        private void TmrMovimiento_Tick(object sender, EventArgs e)
        {
            this.escenario.Tick();
            this.Dibujar();
        }

        private void Dibujar()
        {
            using (var g = Graphics.FromImage(this.buffer))
            {
                g.Clear(Color.Black);
                g.FillRectangle(Brushes.White, this.escenario.Pelota.Posicion.X, this.escenario.Pelota.Posicion.Y, this.escenario.Pelota.Dimension.Ancho, this.escenario.Pelota.Dimension.Altura);
                g.FillRectangle(Brushes.White, this.escenario.ParedSuperior.Posicion.X, this.escenario.ParedSuperior.Posicion.Y, this.escenario.ParedSuperior.Dimension.Ancho, this.escenario.ParedSuperior.Dimension.Altura);
                g.FillRectangle(Brushes.White, this.escenario.ParedInferior.Posicion.X, this.escenario.ParedInferior.Posicion.Y, this.escenario.ParedInferior.Dimension.Ancho, this.escenario.ParedInferior.Dimension.Altura);
                g.FillRectangle(Brushes.White, this.escenario.RaquetaDerecha.Posicion.X, this.escenario.RaquetaDerecha.Posicion.Y, this.escenario.RaquetaDerecha.Dimension.Ancho, this.escenario.RaquetaDerecha.Dimension.Altura);
                g.FillRectangle(Brushes.White, this.escenario.RaquetaIzquierda.Posicion.X, this.escenario.RaquetaIzquierda.Posicion.Y, this.escenario.RaquetaIzquierda.Dimension.Ancho, this.escenario.RaquetaIzquierda.Dimension.Altura);

                g.FillRectangle(Brushes.White, this.escenario.RedIzquierda.Posicion.X, this.escenario.RedIzquierda.Posicion.Y, this.escenario.RedIzquierda.Dimension.Ancho, this.escenario.RedIzquierda.Dimension.Altura);
                g.FillRectangle(Brushes.White, this.escenario.RedDerecha.Posicion.X, this.escenario.RedDerecha.Posicion.Y, this.escenario.RedDerecha.Dimension.Ancho, this.escenario.RedDerecha.Dimension.Altura);
            }

            this.Invalidate(true);
        }

        private void CrearBuffer(object sender, EventArgs e)
        {
            this.buffer?.Dispose();
            this.buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void EscenarioForm_Load(object sender, EventArgs e)
        {
            this.CrearBuffer(sender, e);
            Coordenada escenarioPosicion = new Coordenada(0, 0);
            Dimension escenarioDimension = new Dimension(this.buffer.Width, this.buffer.Height);
            Dimension raquetaDimension = new Dimension(10, 100);
            Dimension pelotaDimension = new Dimension(20, 20);
            Dimension paredDimension = new Dimension(escenarioDimension.Ancho, 10);
            Dimension redDimension = new Dimension(2, escenarioDimension.Altura);

            this.escenario = new Escenario(escenarioPosicion, escenarioDimension, raquetaDimension, pelotaDimension, paredDimension, redDimension);

            this.escenario.RaquetaDerecha.GolRealizado += this.RaquetaDerecha_GolRealizado;
            this.escenario.RaquetaIzquierda.GolRealizado += this.RaquetaIzquierda_GolRealizado;
        }

        private void RaquetaIzquierda_GolRealizado(object sender, EventArgs e)
        {
            Raqueta raqueta = (Raqueta)sender;
            lblPuntajeRaquetaIzquierda.Text = raqueta.Goles.ToString();
            this.display.MostrarNumero(raqueta.Goles);
        }

        private void RaquetaDerecha_GolRealizado(object sender, EventArgs e)
        {
            lblPuntajeRaquetaDerecha.Text = ((Raqueta)sender).Goles.ToString();
        }

        private void EscenarioForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(this.buffer, Point.Empty);
        }

        private void EscenarioForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.joystick.KeyDown(sender, e);
        }
    }
}
