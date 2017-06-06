using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace CURP
{
    public partial class CURP : Form
    {
        public string peticion;
        public string[,] CURPDatos = new string[33, 2];
        public string CURPdato;
        public string CURPNombre;
        public string CURPApellidoPaterno;
        public string CURPApellidoMaterno;
        public string CURPDiaNacimiento;
        public string CURPMesNacimiento;
        public string CURPAnioNacimiento;
        public string CURPSexo;
        public string CURPEntidadNacimiento;
        public string mensaje;
        public string name;
        public string value;
        public bool download = false;

        Byte[] _dPost;

        public CURP()
        {
            InitializeComponent();
        }
       
        private void limpiarVariables()
        {
            for (int i = 0; i < ((CURPDatos.Length) / 2); i++)
            {
                CURPDatos[i, 0] = null;
                CURPDatos[i, 1] = null;
            }
        }

        private void obtenerTags()
        {            
            if (webBrowser1.Document != null)
            {
                if (peticion != "Imprimir")
                {
                    //obtengo la coleccion de tags del documento HTML.
                    HtmlElementCollection elemColl = null;
                    HtmlDocument doc = webBrowser1.Document;
                    if (doc != null)
                    {
                        try
                        {
                            elemColl = doc.GetElementsByTagName("HTML");
                            string html_body = webBrowser1.Document.Body.InnerHtml;
                            obtenerValuePost(elemColl, 0);
                            obtenerTags(html_body, value);

                            if (CURPDatos[0, 0] != null && CURPDatos[0, 1] != null)
                            {
                                titulo.Text = "Datos Obtenidos";
                                this.Close();
                            }
                            else
                            {
                                titulo.Text = "Datos No Obtenidos";
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            else
            {
                HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudieron obtener los Datos", true);
            }
        }

        private void Tags(HtmlElementCollection elemColl, Int32 depth)
        {
            int n = 0;
            try
            {
                foreach (HtmlElement elem in elemColl)
                {

                    string elemName;

                    elemName = elem.GetAttribute("ID");

                    if (depth == 3)
                    {
                        //checo si es un input.
                        if (elem.TagName == "INPUT")
                        {
                            //checo si tiene tipo oculto. Estos son los que me interesan.
                            if (elem.GetAttribute("type") == "hidden")
                            {
                                CURPDatos[n, 0] = elem.GetAttribute("name");
                                CURPDatos[n, 1] = elem.GetAttribute("value");
                                //MessageBox.Show(elementos_html[n, 1]);
                                n++;
                            }
                        }
                    }
                    //si existen elementos con elementos, como el caso del form.
                    if (elem.CanHaveChildren)
                    {
                        Tags(elem.Children, depth + 1);
                    }
                }
            }
            catch 
            { 
            }
        }

        private bool conexion()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com.mx");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CURP_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (peticion == "Obtener_Datos_Por_Curp")
                {
                    obtenerTags();                    
                }
                else if (peticion == "Obtener_Curp_Por_Datos")
                {
                    obtenerTags();
                }
                else if (peticion == "Imprimir")
                {
                    this.Close();
                    string a = webBrowser1.DocumentText;

                    //Uri url = webBrowser1.Url;

                    //string source = "";
                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    //byte[] byteArray = _dPost;
                    //request.Method = "POST";
                    //request.ContentType = "application/x-www-form-urlencoded; charset=utf-8\n\r";
                    //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                    //request.ContentLength = byteArray.Length;
                    //Stream newStream = request.GetRequestStream();
                    //// Send the data.
                    //newStream.Write(byteArray, 0, byteArray.Length);
                    //newStream.Close();

                    //WebResponse response = request.GetResponse();

                    //StreamReader sr = new StreamReader(response.GetResponseStream());
                    //int length = (int)response.ContentLength;

                    //BinaryReader bsRead = new BinaryReader(response.GetResponseStream());

                    //byte[] buff = bsRead.ReadBytes(length);
                    //source = Convert.ToBase64String(buff);

                    //subirArchivoTemporal(source);
                    //titulo.Text = "CURP Impresa.";
                    //this.Close();

                    // Read the content.



                    ////Uri url = webBrowser1.Url;

                    ////string source = "";
                    ////HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    ////request.Method = "POST";
                    ////request.ContentType = "application/x-www-form-urlencoded; charset=utf-8\n\r";
                    ////request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    ////request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                    ////request.ContentLength =_dPost.Length;
                    ////Stream newStream = request.GetRequestStream();
                    ////// Send the data.
                    ////newStream.Write(_dPost, 0, _dPost.Length);
                    ////newStream.Close();

                    ////HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    ////StreamReader sr = new StreamReader(response.GetResponseStream());
                    ////int length = (int)response.ContentLength;

                    ////BinaryReader bsRead = new BinaryReader(response.GetResponseStream());
                    ////byte[] buff = bsRead.ReadBytes(length);
                    ////source = Convert.ToBase64String(buff);

                    ////subirArchivoTemporal(source);
                    ////titulo.Text = "CURP Impresa.";
                    ////this.Close();
                    //////Button1.Visible = true;
                    //////Button2.Visible = true;
                }
            }
            catch
            {
                //HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudo conectar con el Servidor", true);                
                //this.Close();
            }
        }

        private void cargarDatos()
        {
            try
            {
                string strurl = "";
                if (peticion == "Imprimir")
                {
                    Dispose();
                    this.Close();
                }

                if (conexion())
                {
                    strurl = "http://consultas.curp.gob.mx/CurpSP/captchac_u_r_p";
                    //navego en la pagina.                            
                    webBrowser1.Navigate(strurl);

                    btnActualizarCatcha.PerformClick();
                    txtCatcha.Focus();
                }
                else
                {
                    mensaje = "Sin_Conexion";
                    this.Close();
                }
            }
            catch
            { }
        }

        private void obtenerCurp()
        {
            try
            {
                string strurl = "";

                btnImprimirCurp.Visible = false;
                progressBar1.Visible = false;
                titulo.Visible = true;

                //webBrowser1.Visible = false;
                //titulo.Visible = true;
                //progressBar1.Visible = true;

                switch (peticion)
                {
                    case "Obtener_Datos_Por_Curp":
                        try
                        {
                            //muestro la barra de progreso.
                            titulo.Text = "Obteniendo Datos, por Favor espere...";
                            //limpio mi arrreglo de variables.
                            limpiarVariables();
                            //cadena para consultar la curp en línea.                          
                            strurl = "http://consultas.curp.gob.mx/CurpSP/curpporcurp.do?strCurp=" + CURPdato.Trim() + "&strTipo=B&codigo=" + txtCatcha.Text.Trim();
                            webBrowser1.Visible = false;
                            progressBar1.Visible = true;
                            titulo.Visible = true;

                            webBrowser1.Navigate(strurl);
                        }
                        catch
                        {
                            //HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudo conectar con el Servidor", false);                            
                        }
                        break;

                    case "Obtener_Curp_Por_Datos":
                        try
                        {
                            //muestro la barra de progreso.
                            titulo.Text = "Obteniendo Datos, por Favor espere...";
                            //limpio mi arrreglo de variables.
                            limpiarVariables();
                            //cadena para consultar la curp en línea.
                            strurl = "http://consultas.curp.gob.mx/CurpSP/curpdatos.do?strPrimerApellido=" + CURPApellidoPaterno.Trim() + "&strSegundoAplido=" + CURPApellidoMaterno.Trim() + "&strNombre=" + CURPNombre.Trim() + "&strdia=" + CURPDiaNacimiento.Trim() + "&strmes=" + CURPMesNacimiento.Trim() + "&stranio=" + CURPAnioNacimiento.Trim() + "&sEntidadA=" + CURPEntidadNacimiento.Trim() + "&sSexoA=" + CURPSexo.Trim() + "&strTipo=A&codigo=" + txtCatcha.Text.Trim();
                            //navego en la pagina.
                            webBrowser1.Visible = false;
                            progressBar1.Visible = true;
                            titulo.Visible = true;

                            webBrowser1.Navigate(strurl);
                        }
                        catch
                        {
                            //HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudo conectar con el Servidor", true);                            
                            this.Close();
                        }
                        break;

                    case "Imprimir":
                        this.Close();
                        //try
                        //{
                        //    if (CURPDatos[0, 0] != null && CURPDatos[0, 1] != null)
                        //    {
                        //        titulo.Text = "Imprimiendo...";
                        //        string direccionImprimir, datosPost = "", Cabeceras;
                        //        Byte[] dPost;
                        //        direccionImprimir = "http://consultas.curp.gob.mx/CurpSP/imprime.do";


                        //        datosPost += name +"=" + @CURPDatos[31, 1];

                        //        //datosPost += CURPDatos[((CURPDatos.Length) / 2) - 1, 0] + "=" + CURPDatos[((CURPDatos.Length) / 2) - 1, 1];



                        //        //Cabeceras = "Content-Type: application/x-www-form-urlencoded" + "\n" + "\r";**
                        //        Cabeceras = "Content-Type: application/x-www-form-urlencoded; charset=utf-8\n\r";

                        //        dPost = UTF8Encoding.UTF8.GetBytes(datosPost);
                        //        //dPost =  ASCIIEncoding.ASCII.GetBytes(datosPost);

                        //        _dPost = dPost;
                        //        webBrowser1.Navigate(direccionImprimir, "", dPost, Cabeceras);
                        //    }
                        //    else
                        //    {
                        //        HF_Controls.Functions.Message(Program._Titulo_Mensaje, "Debe consultar la CURP antes de imprimir", false);                                
                        //        this.Close();
                        //    }
                        //}
                        //catch
                        //{
                        //    //HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudo conectar con el Servidor", true);                            
                        //    this.Close();
                        //}
                        break;
                }
            }
            catch
            { }
        }

        public void subirArchivoTemporal(string txtArchivo)
        {
            //string path = Path.GetTempPath();
            //string dirArchivo = path + "CURPfromInternet"+CURPDatos[0,1]+".pdf";
            //byte[] archivoBytes = Convert.FromBase64String(txtArchivo);

            //using (FileStream stream = File.Open(dirArchivo, FileMode.Create))
            //{
            //    stream.Write(archivoBytes, 0, archivoBytes.Length);
            //}
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Value = (int)(((double)e.CurrentProgress / e.MaximumProgress) * 100);
        }

        private void CURP_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mensaje != "Sin_Conexion")
            {
                if (CURPDatos[0, 0] != null && CURPDatos[0, 1] != "")
                {
                    mensaje = "Encontrado";
                }
                else
                {
                    string HTMLtext = webBrowser1.DocumentText;
                    if (HTMLtext.IndexOf("no se encuentra en la Base de Datos Nacional de la CURP") != -1)
                    {
                        mensaje = "No_Encontrado";
                    }
                    else
                    {
                        mensaje = "No_Obtenido";
                    }

                }
            }
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string strurl = "http://consultas.curp.gob.mx/CurpSP/captchac_u_r_p";
                webBrowser1.Navigate(strurl);

                titulo.Visible = false;
                progressBar1.Visible = false;
                webBrowser1.Visible = true;
            }
            catch 
            { 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void btnObtenerCurp_Click(object sender, EventArgs e)
        {
            obtenerCurp();

            
            //string strurl;
            ////muestro la barra de progreso.
            //titulo.Text = "Obteniendo Datos, por Favor espere...";
            ////limpio mi arrreglo de variables.
            //limpiarVariables();
            ////cadena para consultar la curp en línea.
            ////strurl = "http://consultas.curp.gob.mx/CurpSP/curp21.do?strCurp=" + CURPdato.Trim() + "&strTipo=B&entfija=erenapo&depfija=04001";
            //strurl = "http://consultas.curp.gob.mx/CurpSP/curp21.do?strCurp=" + CURPdato.Trim() + "&strTipo=B&codigo="+txtCatcha.Text.Trim();
            //webBrowser1.Navigate(strurl);
        }

        private void btnObtenerTags_Click(object sender, EventArgs e)
        {
            obtenerTags();          
        }

        protected void obtenerTags(string _html_body, string _value)
        {
            try
            {
                string html = _html_body;

                int index_strCurp = 0, index_strPrimerApellido = 0, index_strSegundoAplido = 0, index_strNombre = 0, index_strSexo = 0, index_strFechanacimiento = 0, index_strCveEnt = 0,
                    index_strCveDP = 0, index_strCURPDOCUMPROBACTAENTIDREGIS = 0, index_strCURPDOCUMPROBACTAMUNICREGIS = 0, index_strsCURPDOCUMPROBANIOREGISTRO = 0, index_strCURPDOCUMPROBACTALIBRO = 0;
                int index_strCurp_aux = 0, index_strPrimerApellido_aux = 0, index_strSegundoAplido_aux = 0, index_strNombre_aux = 0, index_strSexo_aux = 0, index_strFechanacimiento_aux = 0, index_strCveEnt_aux = 0,
                    index_strCveDP_aux = 0, index_strCURPDOCUMPROBACTAENTIDREGIS_aux = 0, index_strCURPDOCUMPROBACTAMUNICREGIS_aux = 0,
                    index_strsCURPDOCUMPROBANIOREGISTRO_aux = 0, index_strCURPDOCUMPROBACTALIBRO_aux = 0;

                string strCurp = "", strPrimerApellido = "", strSegundoAplido = "", strNombre = "", strSexo = "", strFechanacimiento = "", strCveEnt = "",
                    strCveDP = "", strCURPDOCUMPROBACTAENTIDREGIS = "", strNombreCURPDOCUMPROBACTAENTIDREGIS = "", strCURPDOCUMPROBACTAMUNICREGIS = "", strNombreCURPDOCUMPROBACTAMUNICREGIS = "",
                    strsCURPDOCUMPROBANIOREGISTRO = "", strCURPDOCUMPROBACTALIBRO = "", depfija = "", entfija = "";

                #region strCurp
                index_strCurp = html.IndexOf("Curp</SPAN>");
                index_strCurp = html.IndexOf("Nota", index_strCurp);
                index_strCurp = html.IndexOf(">", index_strCurp) + 1;
                index_strCurp_aux = html.IndexOf("<", index_strCurp);

                strCurp = html.Substring(index_strCurp, index_strCurp_aux - index_strCurp).Trim() ?? "";
                #endregion
                #region strPrimerApellido
                index_strPrimerApellido = html.IndexOf("Primer Apellido</SPAN>");
                index_strPrimerApellido = html.IndexOf("Nota", index_strPrimerApellido);
                index_strPrimerApellido = html.IndexOf(">", index_strPrimerApellido) + 1;
                index_strPrimerApellido_aux = html.IndexOf("<", index_strPrimerApellido);

                strPrimerApellido = html.Substring(index_strPrimerApellido, index_strPrimerApellido_aux - index_strPrimerApellido).Trim() ?? "";
                #endregion
                #region strSegundoAplido
                index_strSegundoAplido = html.IndexOf("Segundo Apellido</SPAN>");
                index_strSegundoAplido = html.IndexOf("Nota", index_strSegundoAplido);
                index_strSegundoAplido = html.IndexOf(">", index_strSegundoAplido) + 1;
                index_strSegundoAplido_aux = html.IndexOf("<", index_strSegundoAplido);

                strSegundoAplido = html.Substring(index_strSegundoAplido, index_strSegundoAplido_aux - index_strSegundoAplido).Trim() ?? "";
                #endregion
                #region strNombre
                index_strNombre = html.IndexOf("Nombre(s)</SPAN>");
                index_strNombre = html.IndexOf("Nota", index_strNombre);
                index_strNombre = html.IndexOf(">", index_strNombre) + 1;
                index_strNombre_aux = html.IndexOf("<", index_strNombre);

                strNombre = html.Substring(index_strNombre, index_strNombre_aux - index_strNombre).Trim() ?? "";
                #endregion
                #region strSexo
                index_strSexo = html.IndexOf("Sexo</SPAN>");
                index_strSexo = html.IndexOf("Nota", index_strSexo);
                index_strSexo = html.IndexOf(">", index_strSexo) + 1;
                index_strSexo_aux = html.IndexOf("<", index_strSexo);

                strSexo = html.Substring(index_strSexo, index_strSexo_aux - index_strSexo).Trim() ?? "";
                #endregion
                #region strFechanacimiento
                index_strFechanacimiento = html.IndexOf("Fecha de Nacimiento</SPAN>");
                index_strFechanacimiento = html.IndexOf("Nota", index_strFechanacimiento);
                index_strFechanacimiento = html.IndexOf(">", index_strFechanacimiento) + 1;
                index_strFechanacimiento_aux = html.IndexOf("<", index_strFechanacimiento);

                strFechanacimiento = html.Substring(index_strFechanacimiento, index_strFechanacimiento_aux - index_strFechanacimiento).Trim() ?? "";
                #endregion
                #region strCveEnt
                index_strCveEnt = html.IndexOf("Entidad de Nacimiento</SPAN>");
                index_strCveEnt = html.IndexOf("Nota", index_strCveEnt);
                index_strCveEnt = html.IndexOf(">", index_strCveEnt) + 1;
                index_strCveEnt_aux = html.IndexOf("<", index_strCveEnt);

                strCveEnt = html.Substring(index_strCveEnt, index_strCveEnt_aux - index_strCveEnt).Trim() ?? "";
                #endregion
                #region strCveDP
                index_strCveDP = html.IndexOf("Tipo Doc. Probatorio</SPAN>");
                index_strCveDP = html.IndexOf("Nota", index_strCveDP);
                index_strCveDP = html.IndexOf(">", index_strCveDP) + 1;
                index_strCveDP_aux = html.IndexOf("<", index_strCveDP);

                strCveDP = html.Substring(index_strCveDP, index_strCveDP_aux - index_strCveDP).Trim() ?? "";
                #endregion

                #region strCURPDOCUMPROBACTAENTIDREGIS / strNombreCURPDOCUMPROBACTAENTIDREGIS
                index_strCURPDOCUMPROBACTAENTIDREGIS = html.IndexOf("Entidad</B>");
                index_strCURPDOCUMPROBACTAENTIDREGIS = html.IndexOf("Nota", index_strCURPDOCUMPROBACTAENTIDREGIS);
                index_strCURPDOCUMPROBACTAENTIDREGIS = html.IndexOf(">", index_strCURPDOCUMPROBACTAENTIDREGIS) + 1;
                index_strCURPDOCUMPROBACTAENTIDREGIS_aux = html.IndexOf("<", index_strCURPDOCUMPROBACTAENTIDREGIS);

                string entidad = html.Substring(index_strCURPDOCUMPROBACTAENTIDREGIS, index_strCURPDOCUMPROBACTAENTIDREGIS_aux - index_strCURPDOCUMPROBACTAENTIDREGIS).Trim() ?? "";
                strCURPDOCUMPROBACTAENTIDREGIS = entidad.Substring(0, 2).Trim() ?? "";
                strNombreCURPDOCUMPROBACTAENTIDREGIS = entidad.Substring(2, entidad.Length - 2).Trim() ?? "";
                #endregion
                #region strCURPDOCUMPROBACTAMUNICREGIS / strNombreCURPDOCUMPROBACTAMUNICREGIS
                index_strCURPDOCUMPROBACTAMUNICREGIS = html.IndexOf("Municipio</B>");
                index_strCURPDOCUMPROBACTAMUNICREGIS = html.IndexOf("Nota", index_strCURPDOCUMPROBACTAMUNICREGIS);
                index_strCURPDOCUMPROBACTAMUNICREGIS = html.IndexOf(">", index_strCURPDOCUMPROBACTAMUNICREGIS) + 1;
                index_strCURPDOCUMPROBACTAMUNICREGIS_aux = html.IndexOf("<", index_strCURPDOCUMPROBACTAMUNICREGIS);

                string municipio = html.Substring(index_strCURPDOCUMPROBACTAMUNICREGIS, index_strCURPDOCUMPROBACTAMUNICREGIS_aux - index_strCURPDOCUMPROBACTAMUNICREGIS).Trim() ?? "";
                strCURPDOCUMPROBACTAMUNICREGIS = municipio.Substring(0, 3).Trim() ?? "";
                strNombreCURPDOCUMPROBACTAMUNICREGIS = municipio.Substring(3, municipio.Trim().Length - 3).Trim() ?? "";
                #endregion
                #region strsCURPDOCUMPROBANIOREGISTRO
                index_strsCURPDOCUMPROBANIOREGISTRO = html.IndexOf("Año</B>");
                index_strsCURPDOCUMPROBANIOREGISTRO = html.IndexOf("Nota", index_strsCURPDOCUMPROBANIOREGISTRO);
                index_strsCURPDOCUMPROBANIOREGISTRO = html.IndexOf(">", index_strsCURPDOCUMPROBANIOREGISTRO) + 1;
                index_strsCURPDOCUMPROBANIOREGISTRO_aux = html.IndexOf("<", index_strsCURPDOCUMPROBANIOREGISTRO);

                strsCURPDOCUMPROBANIOREGISTRO = html.Substring(index_strsCURPDOCUMPROBANIOREGISTRO, index_strsCURPDOCUMPROBANIOREGISTRO_aux - index_strsCURPDOCUMPROBANIOREGISTRO).Trim() ?? "";
                #endregion
                #region strCURPDOCUMPROBACTALIBRO
                index_strCURPDOCUMPROBACTALIBRO = html.IndexOf("Libro</B>");
                index_strCURPDOCUMPROBACTALIBRO = html.IndexOf("Nota", index_strCURPDOCUMPROBACTALIBRO);
                index_strCURPDOCUMPROBACTALIBRO = html.IndexOf(">", index_strCURPDOCUMPROBACTALIBRO) + 1;
                index_strCURPDOCUMPROBACTALIBRO_aux = html.IndexOf("<", index_strCURPDOCUMPROBACTALIBRO);

                strCURPDOCUMPROBACTALIBRO = html.Substring(index_strCURPDOCUMPROBACTALIBRO, index_strCURPDOCUMPROBACTALIBRO_aux - index_strCURPDOCUMPROBACTALIBRO).Trim() ?? "";
                #endregion
                #region depfija
                depfija = "04001";
                #endregion
                #region entfija
                entfija = "erenapo";
                #endregion

                #region Datos Curp
                CURPDatos[0, 0] = "strCurp";
                CURPDatos[0, 1] = strCurp;
                CURPDatos[1, 0] = "strPrimerApellido";
                CURPDatos[1, 1] = strPrimerApellido;
                CURPDatos[2, 0] = "strSegundoAplido";
                CURPDatos[2, 1] = strSegundoAplido;
                CURPDatos[3, 0] = "strNombre";
                CURPDatos[3, 1] = strNombre;
                CURPDatos[4, 0] = "strSexo";
                CURPDatos[4, 1] = strSexo;
                CURPDatos[5, 0] = "strFechanacimiento";
                CURPDatos[5, 1] = strFechanacimiento;
                CURPDatos[6, 0] = "strCveEnt";
                CURPDatos[6, 1] = strCveEnt;
                CURPDatos[7, 0] = "strEstatus";
                CURPDatos[7, 1] = "";
                CURPDatos[8, 0] = "strFolio";
                CURPDatos[8, 1] = "";
                CURPDatos[9, 0] = "strFechaAlta";
                CURPDatos[9, 1] = "";
                CURPDatos[10, 0] = "strFolioDP";
                CURPDatos[10, 1] = "";
                CURPDatos[11, 0] = "strCveDP";
                CURPDatos[11, 1] = strCveDP;
                CURPDatos[12, 0] = "strCURPDOCUMPROBACTAENTIDREGIS";
                CURPDatos[12, 1] = strCURPDOCUMPROBACTAENTIDREGIS;
                CURPDatos[13, 0] = "strNombreCURPDOCUMPROBACTAENTIDREGIS";
                CURPDatos[13, 1] = strNombreCURPDOCUMPROBACTAENTIDREGIS;
                CURPDatos[14, 0] = "strCURPDOCUMPROBACTAMUNICREGIS";
                CURPDatos[14, 1] = strCURPDOCUMPROBACTAMUNICREGIS;
                CURPDatos[15, 0] = "strNombreCURPDOCUMPROBACTAMUNICREGIS";
                CURPDatos[15, 1] = strNombreCURPDOCUMPROBACTAMUNICREGIS;
                CURPDatos[16, 0] = "strsCURPDOCUMPROBANIOREGISTRO";
                CURPDatos[16, 1] = strsCURPDOCUMPROBANIOREGISTRO;
                CURPDatos[17, 0] = "strCURPDOCUMPROBACTATOMO";
                CURPDatos[17, 1] = "";
                CURPDatos[18, 0] = "strCURPDOCUMPROBACTAFOJA";
                CURPDatos[18, 1] = "";
                CURPDatos[19, 0] = "strCURPDOCUMPROBNUM";
                CURPDatos[19, 1] = "";
                CURPDatos[20, 0] = "strCURPDOCUMPROBACTACRIP";
                CURPDatos[20, 1] = "";
                CURPDatos[21, 0] = "strImpresiones";
                CURPDatos[21, 1] = "";
                CURPDatos[22, 0] = "strRecibos";
                CURPDatos[22, 1] = "";
                CURPDatos[23, 0] = "strCveDependencia";
                CURPDatos[23, 1] = "";
                CURPDatos[24, 0] = "strDependencia";
                CURPDatos[24, 1] = "";
                CURPDatos[25, 0] = "depfija";
                CURPDatos[25, 1] = depfija;
                CURPDatos[26, 0] = "entfija";
                CURPDatos[26, 1] = entfija;
                CURPDatos[27, 0] = "curpsInvalidas";
                CURPDatos[27, 1] = "";
                CURPDatos[28, 0] = "errores";
                CURPDatos[28, 1] = "";
                CURPDatos[29, 0] = "strEstatus";
                CURPDatos[29, 1] = "";
                CURPDatos[30, 0] = "estcurpclave";
                CURPDatos[30, 1] = "";
                CURPDatos[31, 0] = "value";
                CURPDatos[31, 1] = _value;
                CURPDatos[32, 0] = "";
                CURPDatos[32, 1] = "";
                #endregion
            }
            catch
            { }
        }

        private void obtenerValuePost(HtmlElementCollection elemColl, Int32 depth)
        {
            int n = 0;
            try
            {
                foreach (HtmlElement elem in elemColl)
                {
                    string elemName;

                    elemName = elem.GetAttribute("ID");

                    if (depth == 3)
                    {
                        //checo si es un input.
                        if (elem.TagName == "INPUT")
                        {
                            //checo si tiene tipo oculto. Estos son los que me interesan.
                            if (elem.GetAttribute("type") == "hidden")
                            {
                                name = elem.GetAttribute("name");
                                value = elem.GetAttribute("value");
                                n++;
                                break;
                            }
                        }
                    }
                    //si existen elementos con elementos, como el caso del form.
                    if (elem.CanHaveChildren)
                    {
                        obtenerValuePost(elem.Children, depth + 1);
                    }
                }
            }
            catch
            {
            }
        }

        private void btnImprimirCurp_Click(object sender, EventArgs e)
        {
            try
            {
                peticion = "Imprimir";
                HtmlElement btn = webBrowser1.Document.GetElementsByTagName("input")[3];
                btn.InvokeMember("click");

            }
            catch
            {
                //HF_Controls.Functions.Message(Program._Titulo_Mensaje, "No se pudo conectar con el Servidor", true);                            
                this.Close();
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = webBrowser1.Document.Forms.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webBrowser1.Url);
            request.CookieContainer = new CookieContainer();

            request.CookieContainer.SetCookies(webBrowser1.Document.Url, "");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            
            StreamReader sr = new StreamReader(response.GetResponseStream());
            int length = (int)response.ContentLength;

            BinaryReader bsRead = new BinaryReader(response.GetResponseStream());
            byte[] buff = bsRead.ReadBytes(length);
            string source = Convert.ToBase64String(buff);


            string _filename = @"E:\somefile.pdf";

            //create a webcliente

            WebClient cliente = new WebClient();

            //do some magic here (pass the webbrowser cokies to the webclient)

            //cliente.Headers.Add(HttpRequestHeader.Cookie, webBrowser1.Document.Cookie);

            //and just download the file


            cliente.DownloadFile(webBrowser1.Url, _filename);



            subirArchivoTemporal(source);
        }

        private void txtCatcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                obtenerCurp();
            }
        }
    }
}