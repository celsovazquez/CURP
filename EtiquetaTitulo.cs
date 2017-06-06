using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HBMFS
{
    public partial class EtiquetaTitulo : UserControl
    {
        public EtiquetaTitulo()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public Image Image
        {
            get
            {
                return iconoPicture.Image;
            }
            set
            {
                iconoPicture.Image = value;
            }
        }

        public Image ImageRight
        {
            get
            {
                return iconoPicture2.Image;
            }
            set
            {
                iconoPicture2.Image = value;
            }
        }

        public string Titulo
        {
            get
            {
                return tituloLabel.Text;
            }
            set
            {
                tituloLabel.Text = value;
            }
        }

        public override Font Font
        {
            get
            {
                return tituloLabel.Font;
            }
            set
            {
                tituloLabel.Font = value;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = this.ClientRectangle;

            // Colores
            //Moorado
            //Color gradientBegin = Color.FromArgb(128, 0, 128);
            //Color gradientEnd = Color.FromArgb(100, 0, 100);

            //Azul
            Color gradientBegin = Color.FromArgb(25, 88, 217);
            Color gradientEnd = Color.FromArgb(0, 53, 126);
            try
            {
                using (LinearGradientBrush b = new LinearGradientBrush(bounds, gradientBegin, gradientEnd, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(b, bounds);
                }
            }
            catch { }
        }

        private void tituloLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
