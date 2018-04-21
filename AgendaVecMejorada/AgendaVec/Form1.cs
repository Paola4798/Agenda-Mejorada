using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaVec
{
    public partial class Form1 : Form
    {
        Contactos contactos = new Contactos();
        //int[] Contacto = new int[15];
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtFecha.Text == "")
                MessageBox.Show("Completar los espacios!!");
            else
            {
                if (contactos._posicionActual < contactos.vec.Length)
                {
                    Int32 vecCodigo = Convert.ToInt32(txtCodigo.Text);
                   string vecNombre = Convert.ToString( txtNombre.Text);
                   string vecTelefono = Convert.ToString (txtTelefono.Text);
                   string vecCorreo =Convert.ToString( txtCorreo.Text);
                    string vecFecha = Convert.ToString(txtFecha.Text);
                    contactos.agregar(new Persona(vecCodigo, vecNombre, vecTelefono, vecCorreo, vecFecha));
                }
                else
                {
                    MessageBox.Show("No hay mas espacio en la agenda!");
                }

                limpiarTxt();
                //Contacto(persona);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if(contactos.listar() == "")
            {
                MessageBox.Show("Vacio!");
            }
            else
            {
                txtShow.Text = contactos.listar();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtFecha.Text == "")
                MessageBox.Show("Completar los espacios!!");
            else
            {
                if (contactos._posicionActual < contactos.vec.Length)
                {
                    Int32 vecCodigo = Convert.ToInt32(txtCodigo.Text);
                    string vecNombre = Convert.ToString(txtNombre.Text);
                    string vecTelefono = Convert.ToString(txtTelefono.Text);
                    string vecCorreo = Convert.ToString(txtCorreo.Text);
                    string vecFecha = Convert.ToString(txtFecha.Text);

                    contactos.insertar(new Persona(vecCodigo, vecNombre, vecTelefono, vecCorreo, vecFecha), Convert.ToInt16(txtPosicion.Text));
                }
                else
                {
                    MessageBox.Show("No hay mas espacio en la agenda!");
                }

                limpiarTxt();
                //Contacto(persona);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
                MessageBox.Show("Favor de escribir el nombre de la persona para eliminar");
            else
            {
                if (contactos.buscar(Convert.ToString(txtNombre.Text)) == null)
                    MessageBox.Show("El contacto no existe.");
                
                else
                {
                    contactos.eliminar(txtNombre.Text);
                    MessageBox.Show("El contacto se ha eliminado.");
                    txtShow.Text = contactos.listar();
                }
            }
        }

        private void limpiarTxt()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtFecha.Text = "";
            txtPosicion.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
                MessageBox.Show("Favor de escribir el nombre de el contacto a buscar");
            else
                           if (contactos.buscar(Convert.ToString(txtNombre.Text)) == null)
                MessageBox.Show("El contacto no existe.");
            else
                txtShow.Text = contactos.buscar(Convert.ToString(txtNombre.Text)).ToString();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            contactos.eliminar(txtNombre.Text);
            MessageBox.Show("Contacto Eliminado Correctamente", "Aviso", MessageBoxButtons.OK);
            limpiarTxt();
        }
    }
    
}
