using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace TiendaDepartamentalUX
{
    public partial class PagarCredito : Form
    {
        public PagarCredito()
        {
            InitializeComponent();
            CustomizeControls();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void CustomizeControls()
        {
            // Título del formulario
            this.Text = "Pagar Crédito";
            this.BackColor = Color.White;
            this.Size = new Size(600, 500); // Aumentamos el tamaño del formulario

            // Crear el botón para volver
            Button btnVolver = new Button
            {
                Text = "",
                Size = new Size(40, 40),
                Location = new Point(20, 10),
                BackColor = ColorTranslator.FromHtml("#FFFFFF"),
                FlatStyle = FlatStyle.Flat,
                ImageAlign = ContentAlignment.MiddleCenter, // Centrar la imagen
                FlatAppearance = { BorderSize = 0 }
            };

            // Ruta de la imagen
            string imagePath = @"C:\Users\Fernanda Del Toro\Downloads\flechaprueba.png";

            // Verificar si la imagen existe antes de cargarla
            if (File.Exists(imagePath))
            {
                // Cargar la imagen desde la ruta
                Image img = Image.FromFile(imagePath);

                // Ajustar la imagen al tamaño del botón
                img = new Bitmap(img, new Size(40, 40)); // Escalar la imagen al tamaño del botón

                btnVolver.Image = img;
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Manejar el evento de clic del botón
            btnVolver.Click += (s, e) =>
            {
                this.Hide();
                datoscliente form = new datoscliente("Usuario");
                form.ShowDialog();
            };

            // Agregar el botón al formulario
            this.Controls.Add(btnVolver);

            // Asegurarse de que el botón esté por encima de otros controles
            btnVolver.BringToFront();

            // Mostrar imagen de la licuadora a la izquierda
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(@"C:\Users\Fernanda Del Toro\Downloads\licuadora.jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;  // Ajustar imagen
            pictureBox.Location = new Point(20, 60);  // Ubicación de la imagen a la izquierda
            pictureBox.Size = new Size(150, 150);  // Tamaño de la imagen
            this.Controls.Add(pictureBox);

            // Mostrar nombre de la licuadora
            Label lblNombre = new Label();
            lblNombre.Text = "Licuadora 500W";
            lblNombre.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblNombre.Location = new Point(180, 60); // Colocar nombre de la licuadora al lado de la imagen
            this.Controls.Add(lblNombre);

            // Mostrar descripción breve de la licuadora
            Label lblDescripcion = new Label();
            lblDescripcion.Text = "Licuadora de 500W con 3 velocidades y función de pulso.";
            lblDescripcion.Font = new Font("Arial", 10F);
            lblDescripcion.Location = new Point(180, 90); // Colocar descripción debajo del nombre
            lblDescripcion.Size = new Size(300, 50);  // Ajustar el tamaño para la descripción
            this.Controls.Add(lblDescripcion);

            // Mostrar monto pendiente
            Label lblMontoPendiente = new Label();
            lblMontoPendiente.Text = "Monto Pendiente: $500.00";
            lblMontoPendiente.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblMontoPendiente.Location = new Point(180, 220); // Mover abajo para que no se sobreponga
            this.Controls.Add(lblMontoPendiente);

            // Etiqueta para ingresar el monto de pago
            Label lblMontoPago = new Label();
            lblMontoPago.Text = "Monto: 500";
            lblMontoPago.Location = new Point(180, 260); // Mover abajo para no sobreponerse
            this.Controls.Add(lblMontoPago);

            // Campo de texto para ingresar el monto de pago
            TextBox txtMontoPago = new TextBox();
            txtMontoPago.Location = new Point(180, 290);
            txtMontoPago.Size = new Size(200, 30);
            txtMontoPago.Font = new Font("Arial", 10F);
            this.Controls.Add(txtMontoPago);

            // Botón para realizar el pago
            Button btnPagar = new Button();
            btnPagar.Text = "Pagar";
            btnPagar.Location = new Point(180, 340); // Mover el botón más abajo
            btnPagar.Size = new Size(200, 40);
            btnPagar.BackColor = Color.FromArgb(0, 51, 102); // Color de Copel
            btnPagar.ForeColor = Color.White;
            btnPagar.Click += (sender, e) =>
            {
                decimal montoPago;
                if (decimal.TryParse(txtMontoPago.Text, out montoPago))
                {
                    if (montoPago == 500)
                    {
                        MessageBox.Show("Pago realizado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (montoPago < 500)
                    {
                        MessageBox.Show("El monto ingresado es menor al monto pendiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("El monto ingresado excede el monto pendiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            this.Controls.Add(btnPagar);
        }
    }
}
