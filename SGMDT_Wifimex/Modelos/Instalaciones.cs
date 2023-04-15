using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Instalaciones
    {
        public string IdInstalacion { get; set; }
        public string fechaInstalacin { get; set; }
        public string idEmpelado { get; set; }

        public string idContratos { get; set; }
        public bool Estatus { get; set; }

        public Instalaciones() { }

        public Instalaciones(string idInstalacion, string fechaInstalacin, string idEmpelado, string idContratos, bool estatus)
        {
            IdInstalacion = idInstalacion;
            this.fechaInstalacin = fechaInstalacin;
            this.idEmpelado = idEmpelado;
            this.idContratos = idContratos;
            Estatus = estatus;
        }
    }
}
