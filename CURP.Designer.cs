namespace CURP
{
    partial class CURP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CURP));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.etiquetaTitulo1 = new HBMFS.EtiquetaTitulo();
            this.label1 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtCatcha = new System.Windows.Forms.TextBox();
            this.btnImprimirCurp = new System.Windows.Forms.Button();
            this.btnObtenerCurp = new System.Windows.Forms.Button();
            this.btnActualizarCatcha = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(49, 106);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.etiquetaTitulo1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 45);
            this.panel1.TabIndex = 1;
            // 
            // etiquetaTitulo1
            // 
            this.etiquetaTitulo1.BackColor = System.Drawing.Color.DarkBlue;
            this.etiquetaTitulo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etiquetaTitulo1.Image = global::CURP.Properties.Resources.curp_logo_blue;
            this.etiquetaTitulo1.ImageRight = null;
            this.etiquetaTitulo1.Location = new System.Drawing.Point(0, 0);
            this.etiquetaTitulo1.Name = "etiquetaTitulo1";
            this.etiquetaTitulo1.Size = new System.Drawing.Size(403, 45);
            this.etiquetaTitulo1.TabIndex = 4;
            this.etiquetaTitulo1.Titulo = "Obtención de la CURP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Obtención de la CURP";
            // 
            // titulo
            // 
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(50, 52);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(299, 23);
            this.titulo.TabIndex = 3;
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(101, 51);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(206, 92);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // txtCatcha
            // 
            this.txtCatcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCatcha.Location = new System.Drawing.Point(131, 149);
            this.txtCatcha.Name = "txtCatcha";
            this.txtCatcha.Size = new System.Drawing.Size(99, 20);
            this.txtCatcha.TabIndex = 0;
            this.txtCatcha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCatcha_KeyPress);
            // 
            // btnImprimirCurp
            // 
            this.btnImprimirCurp.Location = new System.Drawing.Point(323, 52);
            this.btnImprimirCurp.Name = "btnImprimirCurp";
            this.btnImprimirCurp.Size = new System.Drawing.Size(79, 23);
            this.btnImprimirCurp.TabIndex = 6;
            this.btnImprimirCurp.Text = "Imprimir";
            this.btnImprimirCurp.UseVisualStyleBackColor = true;
            this.btnImprimirCurp.Visible = false;
            this.btnImprimirCurp.Click += new System.EventHandler(this.btnImprimirCurp_Click);
            // 
            // btnObtenerCurp
            // 
            this.btnObtenerCurp.BackgroundImage = global::CURP.Properties.Resources.btnBackgroundBlue;
            this.btnObtenerCurp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnObtenerCurp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObtenerCurp.Image = global::CURP.Properties.Resources.iconos_32_px_07;
            this.btnObtenerCurp.Location = new System.Drawing.Point(236, 149);
            this.btnObtenerCurp.Name = "btnObtenerCurp";
            this.btnObtenerCurp.Size = new System.Drawing.Size(20, 20);
            this.btnObtenerCurp.TabIndex = 1;
            this.btnObtenerCurp.UseVisualStyleBackColor = true;
            this.btnObtenerCurp.Click += new System.EventHandler(this.btnObtenerCurp_Click);
            // 
            // btnActualizarCatcha
            // 
            this.btnActualizarCatcha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizarCatcha.BackgroundImage")));
            this.btnActualizarCatcha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizarCatcha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizarCatcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarCatcha.ForeColor = System.Drawing.Color.Maroon;
            this.btnActualizarCatcha.Image = global::CURP.Properties.Resources.iconos_32_px_33;
            this.btnActualizarCatcha.Location = new System.Drawing.Point(262, 149);
            this.btnActualizarCatcha.Name = "btnActualizarCatcha";
            this.btnActualizarCatcha.Size = new System.Drawing.Size(20, 20);
            this.btnActualizarCatcha.TabIndex = 2;
            this.btnActualizarCatcha.UseVisualStyleBackColor = true;
            this.btnActualizarCatcha.Click += new System.EventHandler(this.button2_Click);
            // 
            // CURP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 173);
            this.Controls.Add(this.btnImprimirCurp);
            this.Controls.Add(this.btnObtenerCurp);
            this.Controls.Add(this.txtCatcha);
            this.Controls.Add(this.btnActualizarCatcha);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(353, 195);
            this.Name = "CURP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CURP";
            this.Load += new System.EventHandler(this.CURP_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CURP_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private HBMFS.EtiquetaTitulo etiquetaTitulo1;
        private System.Windows.Forms.TextBox txtCatcha;
        private System.Windows.Forms.Button btnObtenerCurp;
        private System.Windows.Forms.Button btnImprimirCurp;
        private System.Windows.Forms.Button btnActualizarCatcha;
    }
}