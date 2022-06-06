using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinetti.Franco._2c.TPFinal
{
    public enum Trabajo { 
        Ficha,
        Display,
        Bateria,
        Otros
    }
    public class Reparacion
    {
        private Guid id;
        private DateTime ingreso;
        private Producto producto;
        private Cliente cliente;
        private float presupuesto;
        private Trabajo trabajo;
        private bool terminado;

        public Reparacion() {
            id = Guid.NewGuid();
            this.ingreso = DateTime.UtcNow;
            this.terminado = false;
        }

        public Reparacion(Producto producto, Cliente cliente, float presupuesto,Trabajo trabajo) 
        { 
            this.producto = producto;
            this.cliente = cliente;
            this.presupuesto = presupuesto;
            this.trabajo = trabajo;   
        }


        override public string ToString() { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{producto.ToString()}");
            sb.AppendLine($"{cliente.ToString()}");
            sb.AppendLine($"Presupuesto {this.presupuesto}");
            sb.AppendLine($"Trabajo {this.trabajo}");
            sb.AppendFormat("Terminado {0}", this.terminado ? "Si" : "No"); 
            return sb.ToString();
        }

        public string Listar() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.ingreso.ToShortDateString()} |");
            sb.AppendLine($"{cliente.Nombre} | ");
            sb.AppendLine($"{producto.sProducto} |");
            sb.AppendFormat("{0}", this.terminado ? "TERMINADO ;" : "EN REPARACION ;");
            return sb.ToString();
        }


    }
}
