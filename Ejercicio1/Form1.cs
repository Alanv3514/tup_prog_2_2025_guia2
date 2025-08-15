using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio1.Modelos;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Servicio servicio = new Servicio();
        public Form1()
        {
            InitializeComponent();
        }

        private void fetchLista()
        {

            lbLista.Items.Clear();
            for (int i = 0; i < servicio.CantidadPersonas(); i++)
            {
                Persona persona = servicio.VerPersona(i);
                lbLista.Items.Add(persona.Describir());
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            fetchLista();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos vnt = new Datos();
            if (vnt.ShowDialog() == DialogResult.OK) 
            {
                int dni = Convert.ToInt32(vnt.tbDNI.Text);

                string nombre = vnt.tbNombre.Text;

                Persona nuevaPersona = new Persona(dni, nombre);

                servicio.AgregarPersona(nuevaPersona);

                btnListar.Enabled = true;

                fetchLista();
            }

            vnt.Dispose();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {

            VerPersona vnt = new VerPersona();
            int indice = lbLista.SelectedIndex;
            if (indice!=-1)
            {
                Persona p = servicio.VerPersona(indice);
                vnt.tbVerPersona.Text = p.Describir();
                vnt.ShowDialog();
            }
            vnt.Dispose();

        }

        private void lbLista_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnVer.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {


            Datos vnt = new Datos();
            int indice = lbLista.SelectedIndex;
            if (indice != -1)
            {
                Persona p = servicio.VerPersona(indice);
                vnt.tbDNI.Text = Convert.ToString(p.Dni);
                vnt.tbNombre.Text = Convert.ToString(p.Nombre);
                if (vnt.ShowDialog() == DialogResult.OK) {
                    servicio.ModificarPersona(indice, new Persona(Convert.ToInt32(vnt.tbDNI.Text), Convert.ToString(vnt.tbNombre.Text)));

                    fetchLista();
                }
            }
            vnt.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = lbLista.SelectedIndex;
            if (indice != -1)
            {

                Persona p = servicio.VerPersona(indice);
                servicio.EliminarPersona(p);

                fetchLista();
            }
        }
    }
}
