using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaDepartamentalUX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupLoginUI();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void SetupLoginUI()
        {
            // Configuración del formulario
            this.Text = "Inicio de Sesión - Tienda Departamental";
            this.Size = new Size(400, 350);
            this.BackColor = Color.White;

            // Logo o encabezado
            Label lblLogo = new Label();
            lblLogo.Text = "Inicio De Sesión";
            lblLogo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(0, 51, 153); // Azul Coppel
            lblLogo.AutoSize = true;
            lblLogo.Location = new Point(80, 20);
            this.Controls.Add(lblLogo);

            // Label de correo
            Label lblCorreo = new Label();
            lblCorreo.Text = "Usuario";
            lblCorreo.Font = new Font("Segoe UI", 10);
            lblCorreo.ForeColor = Color.Black;
            lblCorreo.Location = new Point(50, 80);
            this.Controls.Add(lblCorreo);

            // TextBox de correo
            TextBox txtCorreo = new TextBox();
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(250, 25);
            txtCorreo.Location = new Point(50, 105);
            this.Controls.Add(txtCorreo);

            // Label de contraseña
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña";
            lblContraseña.Font = new Font("Segoe UI", 10);
            lblContraseña.ForeColor = Color.Black;
            lblContraseña.Location = new Point(50, 140);
            this.Controls.Add(lblContraseña);

            // TextBox de contraseña
            TextBox txtContraseña = new TextBox();
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(250, 25);
            txtContraseña.Location = new Point(50, 165);
            txtContraseña.UseSystemPasswordChar = true;
            this.Controls.Add(txtContraseña);

            // Label de mensaje de error
            Label lblError = new Label();
            lblError.Name = "lblError";
            lblError.Text = "";
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(50, 200);
            lblError.Size = new Size(250, 20);
            lblError.Visible = false; // Oculto por defecto
            this.Controls.Add(lblError);

            // Botón de iniciar sesión
            Button btnIniciarSesion = new Button();
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnIniciarSesion.BackColor = Color.FromArgb(255, 209, 0); // Amarillo Coppel
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Size = new Size(250, 30);
            btnIniciarSesion.Location = new Point(50, 230);
            btnIniciarSesion.Click += (s, e) => IniciarSesion(txtCorreo, txtContraseña, lblError);
            this.Controls.Add(btnIniciarSesion);

            // Link para registrarse
            LinkLabel lblRegistrarse = new LinkLabel();
            lblRegistrarse.Text = "¿No tienes cuenta? Regístrate aquí";
            lblRegistrarse.Location = new Point(90, 270);
            lblRegistrarse.AutoSize = true;
            lblRegistrarse.LinkColor = Color.FromArgb(0, 51, 153);
            lblRegistrarse.Click += (s, e) => AbrirFormularioRegistro();
            this.Controls.Add(lblRegistrarse);


        }

        private void IniciarSesion(TextBox txtCorreo, TextBox txtContraseña, Label lblError)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                lblError.Text = "Por favor, completa todos los campos.";
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
                MessageBox.Show($"Bienvenido, {txtCorreo.Text}"); // Mostrar el nombre de usuario
                this.Hide();

                // Pasar el nombre del usuario (puedes usar txtCorreo.Text o lo que quieras mostrar como nombre)
                datoscliente datosClienteForm = new datoscliente(txtCorreo.Text);
                datosClienteForm.ShowDialog();
            }
        }

        private void AbrirFormularioRegistro()
        {
            this.Hide();
            Form formularioRegistro = new formularioRegistro(); // Suponiendo que tienes un formulario de registro
            formularioRegistro.Show();
        }


        private void btniniciarsesion_Click(object sender, EventArgs e)
        {

        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblcorreo_Click(object sender, EventArgs e)
        {

        }

        private void lblcontraseña_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
