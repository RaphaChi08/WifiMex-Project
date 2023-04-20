using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Contrato
    {
        public string idContrato { get; set; }
        public double precioServicio { get; set; }
        public string inicioContrato { get; set; }
        public string finContrato { get; set; }
        public string idCliente { get; set; }
        public String Estatus { get; set; }

        public Contrato(string idContrato, double precioServicio, string inicioContrato, string finContrato, string idCliente, string estatus)
        {
            this.idContrato = idContrato;
            this.precioServicio = precioServicio;
            this.inicioContrato = inicioContrato;
            this.finContrato = finContrato;
            this.idCliente = idCliente;
            Estatus = estatus;
        }

        public Contrato() { }
    }
}
