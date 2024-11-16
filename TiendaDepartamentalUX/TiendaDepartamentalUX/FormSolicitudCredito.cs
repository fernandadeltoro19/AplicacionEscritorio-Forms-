using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TiendaDepartamentalUX
{
    public partial class FormSolicitudCredito : Form
    {
        public FormSolicitudCredito()
        {
            InitializeComponent(); // Esto ya se ejecuta automáticamente
            CustomizeControls(); // Método para personalizar los controles
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void CustomizeControls()
        {
            // Personalizamos el formulario
            this.Text = "Solicitud de Aumento de Crédito";
            this.BackColor = System.Drawing.Color.White; // Fondo blanco
            this.Size = new System.Drawing.Size(500, 700); // Aumentamos el tamaño del formulario para más espacio

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

            // Ruta de la imagen (actualiza con la correcta)
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
                datoscliente datos = new datoscliente("Usuario");
                datos.ShowDialog();
            };

            // Agregar el botón al formulario
            this.Controls.Add(btnVolver);

            // Asegurarse de que el botón esté por encima de otros controles
            btnVolver.BringToFront();

            // Etiqueta de "Nombre"
            lblNombre.AutoSize = true;
            lblNombre.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            lblNombre.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102); // Azul Copel
            lblNombre.Location = new System.Drawing.Point(20, 70); // Bajamos la posición
            lblNombre.Text = "Nombre Completo";
            this.Controls.Add(lblNombre);

            // Campo de texto para el nombre
            txtNombre.Location = new System.Drawing.Point(20, 100);
            txtNombre.Size = new System.Drawing.Size(440, 30);
            txtNombre.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(txtNombre);

            // Etiqueta de "Monto Solicitado"
            lblMonto.AutoSize = true;
            lblMonto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            lblMonto.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102); // Azul Copel
            lblMonto.Location = new System.Drawing.Point(20, 150); // Bajamos la posición
            lblMonto.Text = "Monto Solicitado";
            this.Controls.Add(lblMonto);

            // Campo de texto para el monto solicitado
            txtMonto.Location = new System.Drawing.Point(20, 180);
            txtMonto.Size = new System.Drawing.Size(440, 30);
            txtMonto.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(txtMonto);

            // Etiqueta de "Motivo del Aumento"
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            lblMotivo.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102); // Azul Copel
            lblMotivo.Location = new System.Drawing.Point(20, 230); // Bajamos la posición
            lblMotivo.Text = "Motivo del Aumento";
            this.Controls.Add(lblMotivo);

            // Campo de texto para el motivo
            txtMotivo.Location = new System.Drawing.Point(20, 260);
            txtMotivo.Size = new System.Drawing.Size(440, 100);
            txtMotivo.Font = new System.Drawing.Font("Arial", 10F);
            txtMotivo.Multiline = true;
            this.Controls.Add(txtMotivo);

            // Checkbox para aceptar términos y condiciones
            chkTerminos.AutoSize = true;
            chkTerminos.Font = new System.Drawing.Font("Arial", 9F);
            chkTerminos.Location = new System.Drawing.Point(20, 380); // Bajamos la posición
            chkTerminos.Text = "Acepto los términos y condiciones";
            chkTerminos.UseVisualStyleBackColor = true;
            this.Controls.Add(chkTerminos);

            // Etiqueta de "Subir Estado de Cuenta"
            lblEstadoCuenta.AutoSize = true;
            lblEstadoCuenta.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            lblEstadoCuenta.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102); // Azul Copel
            lblEstadoCuenta.Location = new System.Drawing.Point(20, 420); // Nueva sección de estado de cuenta
            lblEstadoCuenta.Text = "Subir Estado de Cuenta (PDF)";
            this.Controls.Add(lblEstadoCuenta);

            // Botón para seleccionar el archivo PDF
            btnSubirEstado.Location = new System.Drawing.Point(20, 450);
            btnSubirEstado.Size = new System.Drawing.Size(440, 40);
            btnSubirEstado.Text = "Seleccionar Archivo";
            btnSubirEstado.BackColor = System.Drawing.Color.FromArgb(0, 51, 102); // Azul Copel
            btnSubirEstado.ForeColor = System.Drawing.Color.White;
            btnSubirEstado.UseVisualStyleBackColor = false;
            btnSubirEstado.Click += BtnSubirEstado_Click; // Evento de clic
            this.Controls.Add(btnSubirEstado);

            // Botón para enviar la solicitud
            btnEnviar.Location = new System.Drawing.Point(110, 500); // Bajamos la posición
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new System.Drawing.Size(250, 40);
            btnEnviar.Text = "Enviar Solicitud";
            btnEnviar.BackColor = System.Drawing.Color.FromArgb(0, 51, 102); // Azul Copel
            btnEnviar.ForeColor = System.Drawing.Color.White; // Texto blanco
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += BtnEnviar_Click; // Evento de clic
            this.Controls.Add(btnEnviar);
        }

        // Evento de clic del botón "Subir Estado de Cuenta"
        private void BtnSubirEstado_Click(object sender, EventArgs e)
        {
            // Abrir el diálogo para seleccionar un archivo
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Selecciona tu Estado de Cuenta"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Aquí puedes agregar la lógica para cargar el archivo si es necesario
                MessageBox.Show("Estado de cuenta seleccionado: " + openFileDialog.FileName, "Archivo Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento de clic del botón "Enviar Solicitud"
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtMonto.Text == "" || txtMotivo.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos antes de enviar la solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!chkTerminos.Checked)
            {
                MessageBox.Show("Debe aceptar los términos y condiciones para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Solicitud enviada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes agregar código adicional para enviar la solicitud
            }
        }

        // Definimos los controles en el formulario
        private Label lblNombre = new Label();
        private Label lblMonto = new Label();
        private Label lblMotivo = new Label();
        private TextBox txtNombre = new TextBox();
        private TextBox txtMonto = new TextBox();
        private TextBox txtMotivo = new TextBox();
        private CheckBox chkTerminos = new CheckBox();
        private Button btnEnviar = new Button();
        private Button btnVolver = new Button();
        private Label lblEstadoCuenta = new Label(); // Etiqueta de estado de cuenta
        private Button btnSubirEstado = new Button(); // Botón para subir estado de cuenta
    }
}
