namespace HBMFS
{
    partial class EtiquetaTitulo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tituloLabel = new System.Windows.Forms.Label();
            this.iconoPicture = new System.Windows.Forms.PictureBox();
            this.iconoPicture2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconoPicture2)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloLabel
            // 
            this.tituloLabel.BackColor = System.Drawing.Color.Transparent;
            this.tituloLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.ForeColor = System.Drawing.Color.White;
            this.tituloLabel.Location = new System.Drawing.Point(0, 0);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(580, 45);
            this.tituloLabel.TabIndex = 0;
            this.tituloLabel.Text = "Título";
            this.tituloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tituloLabel.Click += new System.EventHandler(this.tituloLabel_Click);
            // 
            // iconoPicture
            // 
            this.iconoPicture.BackColor = System.Drawing.Color.Transparent;
            this.iconoPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconoPicture.InitialImage = null;
            this.iconoPicture.Location = new System.Drawing.Point(0, 0);
            this.iconoPicture.Name = "iconoPicture";
            this.iconoPicture.Size = new System.Drawing.Size(50, 45);
            this.iconoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconoPicture.TabIndex = 1;
            this.iconoPicture.TabStop = false;
            // 
            // iconoPicture2
            // 
            this.iconoPicture2.BackColor = System.Drawing.Color.Transparent;
            this.iconoPicture2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconoPicture2.InitialImage = null;
            this.iconoPicture2.Location = new System.Drawing.Point(557, 0);
            this.iconoPicture2.Name = "iconoPicture2";
            this.iconoPicture2.Size = new System.Drawing.Size(23, 45);
            this.iconoPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconoPicture2.TabIndex = 2;
            this.iconoPicture2.TabStop = false;
            // 
            // EtiquetaTitulo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.Controls.Add(this.iconoPicture2);
            this.Controls.Add(this.iconoPicture);
            this.Controls.Add(this.tituloLabel);
            this.Name = "EtiquetaTitulo";
            this.Size = new System.Drawing.Size(580, 45);
            ((System.ComponentModel.ISupportInitialize)(this.iconoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconoPicture2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconoPicture;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.PictureBox iconoPicture2;
    }
}
