namespace Pong
{
    partial class EscenarioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrMovimiento = new System.Windows.Forms.Timer(this.components);
            this.lblPuntajeRaquetaIzquierda = new System.Windows.Forms.Label();
            this.lblPuntajeRaquetaDerecha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrMovimiento
            // 
            this.tmrMovimiento.Enabled = true;
            this.tmrMovimiento.Interval = 10;
            this.tmrMovimiento.Tick += new System.EventHandler(this.TmrMovimiento_Tick);
            // 
            // lblPuntajeRaquetaIzquierda
            // 
            this.lblPuntajeRaquetaIzquierda.AutoSize = true;
            this.lblPuntajeRaquetaIzquierda.Location = new System.Drawing.Point(308, 71);
            this.lblPuntajeRaquetaIzquierda.Name = "lblPuntajeRaquetaIzquierda";
            this.lblPuntajeRaquetaIzquierda.Size = new System.Drawing.Size(13, 13);
            this.lblPuntajeRaquetaIzquierda.TabIndex = 0;
            this.lblPuntajeRaquetaIzquierda.Text = "0";
            // 
            // lblPuntajeRaquetaDerecha
            // 
            this.lblPuntajeRaquetaDerecha.AutoSize = true;
            this.lblPuntajeRaquetaDerecha.Location = new System.Drawing.Point(489, 71);
            this.lblPuntajeRaquetaDerecha.Name = "lblPuntajeRaquetaDerecha";
            this.lblPuntajeRaquetaDerecha.Size = new System.Drawing.Size(13, 13);
            this.lblPuntajeRaquetaDerecha.TabIndex = 1;
            this.lblPuntajeRaquetaDerecha.Text = "0";
            // 
            // EscenarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblPuntajeRaquetaDerecha);
            this.Controls.Add(this.lblPuntajeRaquetaIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EscenarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EscenarioForm";
            this.Load += new System.EventHandler(this.EscenarioForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EscenarioForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EscenarioForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrMovimiento;
        private System.Windows.Forms.Label lblPuntajeRaquetaIzquierda;
        private System.Windows.Forms.Label lblPuntajeRaquetaDerecha;
    }
}