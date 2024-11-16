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
    public partial class formularioRegistro : Form
    {
        public formularioRegistro()
        {
            InitializeComponent();
            SetupRegistroUI();
        }
        private void SetupRegistroUI()
        {
            // Configuración del formulario
            this.Text = "Registro de Usuario - Tienda Departamental";
            this.Size = new Size(400, 500);
            this.BackColor = Color.White;

            // Label de encabezado
            Label lblTitulo = new Label();
            lblTitulo.Text = "Registro de Usuario";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 51, 153); // Azul Coppel
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(100, 20);
            this.Controls.Add(lblTitulo);

            // Campo de Nombre
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre Completo";
            lblNombre.Font = new Font("Segoe UI", 10);
            lblNombre.Location = new Point(50, 70);
            this.Controls.Add(lblNombre);

            TextBox txtNombre = new TextBox();
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 25);
            txtNombre.Location = new Point(50, 95);
            this.Controls.Add(txtNombre);

            // Campo de Correo Electrónico
            Label lblCorreo = new Label();
            lblCorreo.Text = "Correo Electrónico";
            lblCorreo.Font = new Font("Segoe UI", 10);
            lblCorreo.Location = new Point(50, 130);
            this.Controls.Add(lblCorreo);

            TextBox txtCorreo = new TextBox();
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(250, 25);
            txtCorreo.Location = new Point(50, 155);
            this.Controls.Add(txtCorreo);

            // Campo de Contraseña
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña";
            lblContraseña.Font = new Font("Segoe UI", 10);
            lblContraseña.Location = new Point(50, 190);
            this.Controls.Add(lblContraseña);

            TextBox txtContraseña = new TextBox();
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(250, 25);
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.Location = new Point(50, 215);
            this.Controls.Add(txtContraseña);

            // Botón para adjuntar comprobante de domicilio (PDF)
            Label lblComprobante = new Label();
            lblComprobante.Text = "Comprobante de Domicilio (PDF)";
            lblComprobante.Font = new Font("Segoe UI", 10);
            lblComprobante.Location = new Point(50, 250);
            this.Controls.Add(lblComprobante);

            Button btnComprobante = new Button();
            btnComprobante.Text = "Adjuntar Comprobante de Domicilio";
            btnComprobante.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnComprobante.BackColor = Color.FromArgb(255, 209, 0); // Amarillo Coppel
            btnComprobante.ForeColor = Color.White;
            btnComprobante.Size = new Size(200, 50);
            btnComprobante.Location = new Point(50, 275);
            btnComprobante.Click += (s, e) => SeleccionarArchivo(lblComprobante, "PDF files|*.pdf");
            this.Controls.Add(btnComprobante);

            // Botón para adjuntar fotografía del INE (PNG)
            Label lblINE = new Label();
            lblINE.Text = "Fotografía del INE (PNG)";
            lblINE.Font = new Font("Segoe UI", 10);
            lblINE.Location = new Point(50, 330);
            this.Controls.Add(lblINE);

            Button btnINE = new Button();
            btnINE.Text = "Adjuntar INE";
            btnINE.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnINE.BackColor = Color.FromArgb(255, 209, 0);
            btnINE.ForeColor = Color.White;
            btnINE.Size = new Size(200, 50);
            btnINE.Location = new Point(50, 360);
            btnINE.Click += (s, e) => SeleccionarArchivo(lblINE, "PNG files|*.png");
            this.Controls.Add(btnINE);

            // Botón de registro
            Button btnRegistrar = new Button();
            btnRegistrar.Text = "Registrar Cuenta";
            btnRegistrar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRegistrar.BackColor = Color.FromArgb(0, 51, 153); // Azul Coppel
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Size = new Size(250, 35);
            btnRegistrar.Location = new Point(50, 420);
            btnRegistrar.Click += (s, e) => RegistrarCuenta(txtNombre, txtCorreo, txtContraseña, lblComprobante, lblINE);
            this.Controls.Add(btnRegistrar);


        }

        private void SeleccionarArchivo(Label label, string filtro)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filtro;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label.Text = $"Archivo seleccionado: {System.IO.Path.GetFileName(ofd.FileName)}";
            }
        }

        private void RegistrarCuenta(TextBox txtNombre, TextBox txtCorreo, TextBox txtContraseña, Label lblComprobante, Label lblINE)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                !lblComprobante.Text.Contains("Archivo seleccionado:") ||
                !lblINE.Text.Contains("Archivo seleccionado:"))
            {
                MessageBox.Show("Por favor, completa todos los campos y selecciona los archivos requeridos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Simulación de registro exitoso
                MessageBox.Show("Registro exitoso. Tu cuenta ha sido creada.", "Registro Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); // Cierra el formulario de registro
                Form1 INICIO = new Form1(); 
                INICIO.Show();
            }


        }




    }
}
