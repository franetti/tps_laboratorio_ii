using System;
using System.Collections.Generic;

namespace Martinetti.Franco._2c.TPFinal
{
    public class ServicioTecnico
    {
        private List<Reparacion> listaReparaciones;

        public List<Reparacion> Reparaciones{
            get{
                return this.listaReparaciones;
            }    
        }

        public ServicioTecnico() { 
            listaReparaciones = new List<Reparacion>();
        }

        static public bool operator +( ServicioTecnico st, Reparacion nuevaReparacion) {

            if (st is not null && nuevaReparacion is not null)
            {
                st.listaReparaciones.Add(nuevaReparacion);
                return true;
            }
            else {
                return false;
            }            
        }

    }
}
