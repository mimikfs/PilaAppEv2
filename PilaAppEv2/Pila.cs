using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PilaAppEv2
{
    public partial class Pila : Form
    {
        class Empleado
        {
            string nombre = txtNombre.Text;
            string cargo = txtCargo.Text;
            string salario = txtSalario.Text;

            public override string ToString()
            {
                return $"{NombreCompleto} - {Cargo} - ${Salario}";
            }
        }

        Stack<Empleado> pilaEmpleados = new Stack<Empleado>();
        public Pila()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nombre == "" || cargo == "" || salario == "")
            {
                lblMensaje.Text = "Por favor, llena todos los campos.";
                return;
            }

            string empleado = nombre + " - " + cargo + " - $" + salario;

            pila.Push(empleado);

            lblMensaje.Text = "Empleado agregado.";
            ActualizarLista();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (pila.Count > 0)
            {
                pila.Pop();
                lblMensaje.Text = "Último elemento eliminado.";
                ActualizarLista();
            }
            else
            {
                lblMensaje.Text = "La pila está vacía.";
            }
        }

        private void btnVerTope_Click(object sender, EventArgs e)
        {
            if (pila.Count > 0)
            {
                string tope = pila.Peek();
                lblMensaje.Text = "Tope: " + tope;
            }
            else
            {
                lblMensaje.Text = "La pila está vacía.";
            }
        }

        private void ActualizarLista()
        {
            listBoxPila.Items.Clear();

            // Mostramos todos los elementos que hay en la pila
            foreach (string elemento in pila)
            {
                listBoxPila.Items.Add(elemento);
            }
        }
}
