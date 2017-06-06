using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CURP
{
    public partial class Form1 : Form
    {
        //declaro variables
        //array que contendrá todos las variables de la consulta de la CURP.
        public static string[,] CURP_DATOS = new string[33, 2];
        public static string mensaje;
        
        public Form1()
        {
            InitializeComponent();
        }


        private void limpiarVariables()
        {
            for (int i = 0; i < ((CURP_DATOS.Length) / 2); i++)
            {
                CURP_DATOS[i, 0] = null;
                CURP_DATOS[i, 1] = null;
            }
            /*label3.Text = "";
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
            label10.Text = "";
            label12.Text = "";
            label15.Text = "";
            label18.Text = "";
            mensaje = string.Empty;*/
        }

        private void obtnerVariables()
        {
            if (CURP_DATOS[0, 1] != null && CURP_DATOS[1, 1] != null)
            {
                label3.Text = CURP_DATOS[1, 1];
                label4.Text = CURP_DATOS[2, 1];
                label6.Text = CURP_DATOS[3, 1];
                label8.Text = CURP_DATOS[5, 1];
                label10.Text = CURP_DATOS[4, 1];
                label12.Text = CURP_DATOS[6, 1];
                label15.Text = CURP_DATOS[15, 1];
                label18.Text = CURP_DATOS[16, 1];
            }
            else
                HF_Controls.Functions.Message(Program._Titulo_Mensaje, "La CURP ingresada no existe, favor de verificar", false);                
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CURP formCURP = new CURP();
                formCURP.peticion = "Imprimir";
                formCURP.CURPDatos = CURP_DATOS;
                formCURP.ShowDialog();
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            curp.Text = string.Empty;

        }
        
        //Obtencion de datos de la curp
        private void obtenerDatos()
        {
          
            limpiarVariables();
            try
            {
         
                if (curp.Text.Length == 18)
                {
                    CURP formCURP = new CURP();
                    formCURP.peticion = "Obtener_Datos";
                    formCURP.CURPdato = curp.Text;
                    if (formCURP.ShowDialog() == DialogResult.OK)
                    {
                        //obtengo el arreglo con todos los elementos de la CURP.
                        CURP_DATOS = formCURP.CURPDatos;
                        mensaje = formCURP.mensaje;
                        if ((CURP_DATOS[0, 0] != null && CURP_DATOS[0, 1] != null) && mensaje == "Encontrado")
                        {
                            HF_Controls.Functions.Message(Program._Titulo_Mensaje, "Los Datos de la CURP se encontraron satisfactoriamente", false);                            
                            //obtnerVariables();
                        }
                        else if ((CURP_DATOS[0, 0] == null && CURP_DATOS[0, 1] == null) && mensaje == "No_Encontrado")
                        {
                            HF_Controls.Functions.Message(Program._Titulo_Mensaje, "La CURP que ingresó no fue encontrada, Verifíquela e intente nuevamente", false);                            
                        }
                        else if ((CURP_DATOS[0, 0] == null && CURP_DATOS[0, 1] == null) && mensaje == "Sin_Conexion")
                        {
                            HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudo tener acceso al Servidor de Datos, Verifique su conexión a internet", false);                            
                        }
                        else
                        {
                            HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudieron obtener los Datos, Verifique la CURP e intente nuevamente", false);                            
                        }
                    }
                }
                else
                {
                    HF_Controls.Functions.Message(Program._Titulo_Mensaje, "La CURP que ingresó es Inválida, Verifíque que tenga exactamente 18 caracteres e intente nuevament", false);                    
                }
            }
            catch { }
        }

        private void obtenerDatosCurp_Click(object sender, EventArgs e)
        {
                CURP formCURP = new CURP();
                formCURP.CURPdato = curp.Text.Trim();
                formCURP.peticion = "Obtener_Datos_Por_Curp";
                formCURP.ShowDialog();

                try
                {
                    //obtengo el arreglo con todos los elementos de la CURP.
                    CURP_DATOS = formCURP.CURPDatos;
                    mensaje = formCURP.mensaje;
                }
                catch
                { }

            /*limpiarVariables();
            try
            {
                if (curp.Text.Length == 18)
                {
                    CURP formCURP = new CURP();
                    formCURP.peticion = "Obtener_Datos";
                    formCURP.CURPdato = curp.Text;
                    if (formCURP.ShowDialog() == DialogResult.OK)
                    {
                        //obtengo el arreglo con todos los elementos de la CURP.
                        CURP_DATOS = formCURP.CURPDatos;
                        mensaje = formCURP.mensaje;
                        if ((CURP_DATOS[0, 0] != null && CURP_DATOS[0, 1] != null) && mensaje == "Encontrado")
                        {
                            MessageBox.Show("Los Datos de la CURP se encontraron satisfactoriamente", "CURP  Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            obtnerVariables();
                        }
                        else if ((CURP_DATOS[0, 0] == null && CURP_DATOS[0, 1] == null) && mensaje == "No_Encontrado")
                        {
                            MessageBox.Show("La CURP que ingresó no fue encontrada, Verifíquela e intente nuevamente", "CURP No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if ((CURP_DATOS[0, 0] == null && CURP_DATOS[0, 1] == null) && mensaje == "Sin_Conexion")
                        {
                            MessageBox.Show("No se pudo tener acceso al Servidor de Datos, Verifique su conexión a internet", "Sin Conexión a Internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se pudieron obtener los Datos, Verifique la CURP e intente nuevamente", "Operación Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La CURP que ingresó es Inválida, Verifíque que tenga exactamente 18 caracteres e intente nuevamente", "CURP Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }*/
        }

        private void curp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                obtenerDatosCurp_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
