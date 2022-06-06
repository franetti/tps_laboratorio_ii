using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinetti.Franco._2c.TPFinal
{
    public enum MarcasCelu
    {
        Apple,
        Samsung,
        Motorola,
    }
    public class Celular : Producto
    {
        private MarcasCelu marca;

        public Celular(MarcasCelu marca, string modelo, string producto)
            : base(modelo, producto)
        {
            this.marca = marca;
        }

        public MarcasCelu TipoCompu
        {
            get
            {
                return this.marca;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Producto: Celular");
            sb.AppendLine($"{this.marca}, {this.modelo}");            
            return sb.ToString();
        }
    }
}
