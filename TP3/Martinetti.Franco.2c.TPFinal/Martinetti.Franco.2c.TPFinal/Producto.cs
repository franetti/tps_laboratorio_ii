using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinetti.Franco._2c.TPFinal
{    
    abstract public class Producto
    {
        protected string modelo;
        protected string producto;

        public string sProducto
        {
            get { return this.producto; }
        }

        public Producto(string modelo, string producto) {
            this.modelo = modelo;
            this.producto = producto;   
        }
    }   

}
