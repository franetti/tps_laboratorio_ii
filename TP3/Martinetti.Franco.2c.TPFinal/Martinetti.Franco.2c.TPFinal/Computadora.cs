using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinetti.Franco._2c.TPFinal
{
    public enum Tipo { 
        Notebook,
        Escritorio,
        Tablet
    }
    public enum MarcasCompu { 
        Dell,
        Asus,
        Hp
    }
    public class Computadora : Producto
    {
        private Tipo tipo;
        private MarcasCompu marca;

        public Computadora(Tipo tipoComputadora, MarcasCompu marca, string modelo, string producto)
            : base(modelo, producto)
        {
            this.tipo = tipoComputadora;
            this.marca = marca;
        }

        public Tipo TipoCompu{
            get{
                return this.tipo;    
            }
        }

        public override string ToString() 
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Producto: Computadora");
            sb.AppendLine($"{this.tipo}, {this.marca} {this.modelo} ");            
            return sb.ToString();
        }
    }
}
