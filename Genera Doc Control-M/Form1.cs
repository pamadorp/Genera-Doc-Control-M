using Excel=Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Security;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Document = Microsoft.Office.Interop.Word.Document;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
//using Documento = Microsoft.Office.Interop.Word.Document;
//using Microsoft.Office.Core;
namespace Genera_Doc_Control_M
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            txtPlantilla.Text = @"" + Directory.GetCurrentDirectory() + "\\Plantilla\\DRPCAP12300 - Plantilla.docx";
            //txtDocumento.Text = App.Path & "documento.doc";
        }

        private void btnGeneraDoc_Click(object sender, EventArgs e)
        {            
            List<EntityMPAC> datos = new List<EntityMPAC>();
            File.Delete("./Plantilla/Duplicados.txt");
            datos =LeerBDExcel();
            foreach (EntityMPAC entitympac in datos)
            {
                MiDocumento(entitympac);
            }
            
        }
        public void MiDocumento(EntityMPAC datos)
        {
            object missing = System.Type.Missing;
            //String NombreDocumento = "C:\\Users\\pamadorp\\OneDrive - Grupo BMV S.A.B. de C.V\\Documentos\\Control-M\\"+DateTime.Now.ToString()+"_Prueba.dotx";
            String NombreDocumento = @""+ Directory.GetCurrentDirectory()+"\\Plantilla\\"+datos.NombreJob+" - "+datos.Aplicacion+".docx";            
            //Objeto del Tipo Word Application
            Word.Application objWordApplication;
            //Objeto del Tipo Word Document
            Word.Document objWordDocument;
            // Objeto para interactuar con el Interop
            Object oMissing = System.Reflection.Missing.Value;
            objWordApplication = new Word.Application();            
            try
            {
                //Creamos una instancia de una Aplicación Word.
                if (!File.Exists(NombreDocumento))
                {
                    File.Copy(txtPlantilla.Text, NombreDocumento);
                    //A la aplicación Word, le añadimos un documento.                                
                    objWordDocument = objWordApplication.Documents.Open(NombreDocumento);
                    objWordDocument.Activate();
                    if (objWordDocument.Bookmarks.Exists("Nombre_Aplicacion"))
                    {
                        objWordDocument.Bookmarks["Area1"].Range.Text = datos.Notificar;
                        objWordDocument.Bookmarks["AccionJob"].Range.Text = datos.AccionJob;
                        objWordDocument.Bookmarks["Area2"].Range.Text = datos.Notificar;
                        objWordDocument.Bookmarks["Nombre_Aplicacion"].Range.Text = datos.Aplicacion;
                        objWordDocument.Bookmarks["Descripcion"].Range.Text = datos.Descripcion;
                        objWordDocument.Bookmarks["Comando"].Range.Text = datos.Comando;
                        objWordDocument.Bookmarks["Parametros"].Range.Text = datos.Parametros;
                        objWordDocument.Bookmarks["HostName"].Range.Text = datos.Hostname;
                        objWordDocument.Bookmarks["IP"].Range.Text = datos.Ip;
                        objWordDocument.Bookmarks["Owner"].Range.Text = datos.Owner;
                        objWordDocument.Bookmarks["DiasEjecucion"].Range.Text = datos.DiasEjecucion;
                        objWordDocument.Bookmarks["HoraEjecucion"].Range.Text = datos.HoraEjecucion;

                    }
                    objWordApplication.ActiveDocument.Save();
                    //objWordApplication.ActiveDocument.SaveAs(NombreDocumento.Replace("dotx","docx"));
                    objWordDocument.Close();
                }
                else {
                    /*
                    FileStream fs = new FileStream("./Plantilla/Duplicados.txt", FileMode.Append, FileAccess.Write);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        using (StreamWriter sw = new StreamWriter("./Plantilla/Duplicados.txt"))
                        {
                            sw.WriteLine(NombreDocumento);
                        }
                    }*/
                    TextWriter tw = new StreamWriter("./Plantilla/Duplicados.txt",true);
                    // write a line of text to the file                    
                    tw.WriteLine(NombreDocumento);
                    // close the stream
                    tw.Close();
                }
            }catch(Exception ex)
            {
                throw new Exception("Error"+ex.Message.ToString());
            }
            finally
            {
                // Finally, Close our Word application
                objWordApplication.Quit(ref missing, ref missing, ref missing);
                objWordApplication = null;
            }            
        }
        public List<EntityMPAC> LeerBDExcel() {
            //******NOTA TODOS LOS DOCUMENTOS EN LA RUTA DEBEN DE SER ARCHIVOS DE EXCEL****            
            Excel.Application exlApp = new Excel.Application();
            Workbook libroExcel;
            Worksheet hojaExcel;
            Excel.Range miRango;
            List<EntityMPAC> datos= new List<EntityMPAC>();
            EntityMPAC item =new EntityMPAC();
            try
            {
                libroExcel = exlApp.Workbooks.Open("C:\\Users\\pamadorp\\OneDrive - Grupo BMV S.A.B. de C.V\\Documentos\\Control-M\\OS-ST-FR-2008 MPAC.xlsx");
                //Definimos la hoja a utilizar
                hojaExcel = (Worksheet)libroExcel.Worksheets.get_Item("OS-ST-FR-2008 MPAC");
                try
                {
                    int fila = 6;                    
                    miRango = hojaExcel.UsedRange;
                    for (int cicloFila = fila; cicloFila <= 328; cicloFila++)
                    {
                        if ((string)(miRango.Cells[cicloFila, 6]).Value != null)
                        {
                            item.NombreJob = ValidaDato((string)(miRango.Cells[cicloFila, 1]).Value);
                            item.HoraEjecucion = ValidaDato((string)(miRango.Cells[cicloFila, 3]).Value).Trim();
                            item.DiasEjecucion = ValidaDato((string)(miRango.Cells[cicloFila, 4]).Value) == "DiasHabile" ? "L - V" : ValidaDato((string)(miRango.Cells[cicloFila, 4]).Value);
                            item.AccionJob = ValidaDato((string)(miRango.Cells[cicloFila, 6]).Value);
                            item.Aplicacion = ValidaDato((string)(miRango.Cells[cicloFila, 7]).Value);                            
                            item.Descripcion = ValidaDato((string)(miRango.Cells[cicloFila, 8]).Value);
                            switch ((string)(miRango.Cells[cicloFila, 6]).Value)
                            {                                
                                case "Modificar":
                                    item.Hostname = ValidaDato((string)(miRango.Cells[cicloFila, 10]).Value);
                                    item.Ip = ValidaDato((string)(miRango.Cells[cicloFila, 12]).Value);
                                    item.Comando = ValidaDato((string)(miRango.Cells[cicloFila, 14]).Value);
                                    item.Owner = ValidaDato((string)(miRango.Cells[cicloFila, 15]).Value);
                                    item.Parametros = ValidaDato((string)(miRango.Cells[cicloFila, 17]).Value);
                                    item.Notificar = ValidaDato((string)(miRango.Cells[cicloFila, 18]).Value);
                                break;
                                case "Eliminar":
                                    item.Hostname = ValidaDato((string)(miRango.Cells[cicloFila, 9]).Value);
                                    item.Ip = ValidaDato((string)(miRango.Cells[cicloFila, 11]).Value);
                                    item.Comando = ValidaDato((string)(miRango.Cells[cicloFila, 13]).Value);
                                    item.Owner = ValidaDato((string)(miRango.Cells[cicloFila, 16]).Value);
                                    break;
                            }
                            item.Parametros = ValidaDato((string)(miRango.Cells[cicloFila, 17]).Value);
                            item.Notificar = ValidaDato((string)(miRango.Cells[cicloFila, 18]).Value);
                            datos.Add(item);
                            item = new EntityMPAC();
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                }
                finally
                {
                    // cerrar
                    libroExcel.Close(false);
                    exlApp.Quit();
                }                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error " + e.Message);
            }
            return datos;
        }
       
        public string ValidaDato(string dato) {
            if (dato != null)
            {
                return dato.Trim();
            }
            else
            {
                return "";
            }            
        }
    }
}