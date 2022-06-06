using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinetti.Franco._2c.TPFinal
{
    public class Cliente
    {
        private string nombre;
        private string telefono;

        public string Nombre { 
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        public Cliente(string nombre, string telefono) {
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public override string ToString()
        {
            return $"Cliente: {this.Nombre} \n Telefono: {this.Telefono}";
        }
    }
}
