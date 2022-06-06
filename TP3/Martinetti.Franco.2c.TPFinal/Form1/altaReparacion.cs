using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Martinetti.Franco._2c.TPFinal;


namespace Vista
{
    public partial class formAlta : Form
    {
        public formAlta()
        {
            InitializeComponent();            
        }

        private void formAlta_Load(object sender, EventArgs e)
        {
            cmbProducto.Items.Add("Computadora");
            cmbProducto.Items.Add("Celular");
            cmbProducto.SelectedIndex = 0;                                    
            cmbArreglo.Items.AddRange(Enum.GetNames(typeof(Trabajo)));
        }

        private void btnConfirmarAlta_Click(object sender, EventArgs e)
        {   

            string? producto = cmbProducto.SelectedItem.ToString();
            int tipo = cmbTipo.SelectedIndex;
            int marca = cmbMarca.SelectedIndex;
            int trabajo = cmbArreglo.SelectedIndex;
            string modelo = txtModelo.Text;
            string presupuesto = txtPresupuesto.Text;

            Cliente cliente = new Cliente(txtNombre.Text, txtTel.Text);


            /*MessageBox.Show($"{producto},{tipo},{marca}, {trabajo}, {modelo} \n " +
                            $"{cliente}");*/
            if (
                producto is not null &&
                modelo is not null &&
                presupuesto != "" &&
                modelo != "" &&
                txtNombre.Text != "" &&
                txtTel.Text != ""
            )
            {
                if (producto == "Computadora")
                {
                    try
                    {
                        Computadora compu = new Computadora((Tipo)tipo, (MarcasCompu)marca, modelo, "Computadora");
                        if (compu is not null)
                        {
                            Reparacion reparacion = new Reparacion(compu, cliente, float.Parse(presupuesto), (Trabajo)trabajo);
                            vistaIndex.servicioTecnico.Reparaciones.Add(reparacion);
                            MessageBox.Show("Se agrego la nueva reparacion");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        throw;
                    }

                }
                else
                {
                    try
                    {
                        Celular celu = new Celular((MarcasCelu)marca, modelo, "Celular");
                        if (celu is not null)
                        {
                            Reparacion reparacion = new Reparacion(celu, cliente, float.Parse(presupuesto), (Trabajo)trabajo);
                            vistaIndex.servicioTecnico.Reparaciones.Add(reparacion);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }                       
        }

        private void btnCancelarAlta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string prod = cmbProducto.SelectedItem.ToString();
            if (prod is not null && prod == "Computadora")
            {
                cmbTipo.Items.AddRange(Enum.GetNames(typeof(Tipo)));
                cmbTipo.Enabled = true;
                cmbTipo.SelectedIndex = 0;
                cmbMarca.Items.Clear();
                cmbMarca.Items.AddRange(Enum.GetNames(typeof(MarcasCompu)));
                cmbMarca.SelectedIndex = 0;

            }
            else 
            {
                cmbMarca.Items.Clear();
                cmbMarca.Items.AddRange(Enum.GetNames(typeof(MarcasCelu)));
                cmbMarca.SelectedIndex = 0;
                cmbTipo.SelectedIndex = -1;
                cmbTipo.Items.Clear();
                cmbTipo.Enabled = false;
            }
            
        }
    }
}
