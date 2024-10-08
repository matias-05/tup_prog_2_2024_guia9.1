using Guia9._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia9._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FiscalizadorVTV miFiscalia = new FiscalizadorVTV();


        private void btIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                int dni = Convert.ToInt32(tbDni.Text);
                string apellidoYnombre = tbNombre.Text;
                string email = tbCorreo.Text;

                DateTime fecha = DateTime.Now;
                string patente = tbPatente.Text;

                Propietario nuevo = new Propietario(dni, apellidoYnombre, email);

                miFiscalia.AgregarVTV(patente, nuevo, fecha);
            }
            catch (DniNoValidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (EmailNoValidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (PatenteNoValidaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
