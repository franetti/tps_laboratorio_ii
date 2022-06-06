using Martinetti.Franco._2c.TPFinal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;


namespace Vista
{
    public partial class vistaIndex : Form
    {   
        public static ServicioTecnico servicioTecnico;
        public vistaIndex()
        {
            InitializeComponent();            
        }
        static vistaIndex() {
            servicioTecnico = new ServicioTecnico();
        }

        private void Index_Load(object sender, EventArgs e)
        {
         

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            formAlta nuevaAlta = new formAlta();
            nuevaAlta.ShowDialog();
            foreach (Reparacion item in servicioTecnico.Reparaciones) 
            {
                lstReparaciones.Items.Add(item.Listar());
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (servicioTecnico.Reparaciones.Count > 0)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (Reparacion item in servicioTecnico.Reparaciones)
                    {
                        sb.AppendLine($"{item.ToString()}");
                    }

                    Archivos.ExportarListaTxt(sb.ToString());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("La lista de reparaciones esta vacia, igual que tu corazon");
            }            
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string response;
            try
            {
                response = Archivos.ImportarListaTxt();
            }
            catch (Exception ex)
            {
                throw;
            }

            string[] arrList = response.Split(";");

            foreach(string line in arrList)
            {
                lstReparaciones.Items.Add(line);
            }
        }
    }
}
