using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genera_Doc_Control_M
{
    public class EntityMPAC
    {
        string notificar = "";
        string fecha="";
        string nombreJob="";
        string accionJob = "";
        string aplicacion = "";
        string descripcion = "";
        string comando = "";
        string parametros = "";
        string hostname = "";
        string ip = "";  
        string owner = "";
        string diasEjecucion = "L - V";
        string horaEjecucion = "";
        public string Notificar { get => notificar; set => notificar = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string NombreJob { get => nombreJob; set => nombreJob = value; }
        public string Aplicacion { get => aplicacion; set => aplicacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Comando { get => comando; set => comando = value; }
        public string Parametros { get => parametros; set => parametros = value; }
        public string Hostname { get => hostname; set => hostname = value; }
        public string Ip { get => ip; set => ip = value; }
        public string Owner { get => owner; set => owner = value; }
        public string DiasEjecucion { get => diasEjecucion; set => diasEjecucion = value; }
        public string HoraEjecucion { get => horaEjecucion; set => horaEjecucion = value; }
        public string AccionJob { get => accionJob; set => accionJob = value; }
    }
}
