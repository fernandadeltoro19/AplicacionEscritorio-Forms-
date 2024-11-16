using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TiendaDepartamentalUX
{
    public partial class datoscliente : Form
    {
        private string nombreUsuario;

        public datoscliente(string nombre)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            SetupDatosClienteUI();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void SetupDatosClienteUI()
        {
            // Configuración general del formulario
            this.Text = "Información del Cliente - Crédito y Compras";
            this.Size = new Size(700, 800); // Ajuste de tamaño
            this.BackColor = Color.White;

            // Título del formulario
            Label lblTitulo = new Label
            {
                Text = "Estado de Cuenta del Cliente",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 153),
                Size = new Size(600, 40),
                Location = new Point(50, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitulo);

            // Etiqueta de bienvenida con el nombre del usuario
            Label lblBienvenida = new Label
            {
                Text = $"Bienvenido, {nombreUsuario}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(600, 30),
                Location = new Point(50, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblBienvenida);

            // Saldo restante a pagar, debajo de la bienvenida
            Label lblSaldoRestante = new Label
            {
                Text = "Saldo Restante a Pagar: $500.00",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Red,
                Size = new Size(600, 50),
                Location = new Point(50, 130),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblSaldoRestante);

            // Fecha de corte
            Label lblFechaCorte = new Label
            {
                Text = "Fecha de Corte: 10/11/2024",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(600, 30),
                Location = new Point(50, 180),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblFechaCorte);

            // Contenedor para la información de crédito y pagos
            Panel infoPanel = new Panel
            {
                Size = new Size(600, 180), // Ajuste del tamaño
                Location = new Point(50, 220),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(infoPanel);

            // Configuración del texto en infoPanel con distintas tipografías
            Font panelFont = new Font("Segoe UI", 12, FontStyle.Regular);
            Font panelFontBold = new Font("Segoe UI", 14, FontStyle.Bold);

            Label lblCreditoInicial = new Label
            {
                Text = "Crédito Inicial: $3000.00",
                Font = panelFontBold,
                ForeColor = Color.Black,
                Location = new Point(20, 20),
                AutoSize = true
            };
            infoPanel.Controls.Add(lblCreditoInicial);

            Label lblCreditoDisponible = new Label
            {
                Text = "Crédito Disponible: $2500.00",
                Font = panelFontBold,
                ForeColor = Color.Black,
                Location = new Point(20, 70),
                AutoSize = true
            };
            infoPanel.Controls.Add(lblCreditoDisponible);

            Label lblProximoPago = new Label
            {
                Text = "Próximo Pago: $500.00 - Fecha: 15/12/2024",
                Font = panelFontBold,
                ForeColor = Color.Black,
                Location = new Point(20, 120),
                AutoSize = true
            };
            infoPanel.Controls.Add(lblProximoPago);

            // Historial de compras
            Label lblHistorialCompras = new Label
            {
                Text = "Historial de Compras",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 204, 0),
                Size = new Size(600, 30),
                Location = new Point(50, 400) // Subir el label más cerca de la parte superior
            };
            this.Controls.Add(lblHistorialCompras);

            // Tabla de compras con ajuste en las fuentes y más grande
            DataGridView dgvCompras = new DataGridView
            {
                Location = new Point(50, 430),  // Ajustar la posición de inicio
                Size = new Size(600, 250),      // Tamaño inicial
                ColumnCount = 4,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                EnableHeadersVisualStyles = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom // Asegura que se ajuste a los bordes
            };
            dgvCompras.Columns[0].Name = "Fecha";
            dgvCompras.Columns[1].Name = "Descripción";
            dgvCompras.Columns[2].Name = "Monto";
            dgvCompras.Columns[3].Name = "Estado";

            // Estilo de encabezado de DataGridView
            dgvCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 153);
            dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Estilo para el cuerpo de DataGridView
            dgvCompras.DefaultCellStyle.Font = new Font("Segoe UI", 14); // Cambié a una fuente más grande
            dgvCompras.Rows.Add("05/11/2024", "Celular", "$1000.00", "Pagado");
            dgvCompras.Rows.Add("10/11/2024", "Lavadora", "$500.00", "Pagado");
            dgvCompras.Rows.Add("12/11/2024", "Licuadora", "$500.00", "Pendiente");
            this.Controls.Add(dgvCompras);

            dgvCompras.DefaultCellStyle.Font = new Font("Segoe UI", 14); // Cambié a una fuente más grande
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Las columnas llenan el espacio disponible


            // Botón de Pagar ahora debajo del saldo a pagar
            Button btnPagar = new Button
            {
                Text = "Pagar Ahora",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point(100, 700),
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnPagar.FlatAppearance.BorderSize = 0;
            btnPagar.Click += (s, e) =>
            {
                this.Hide();
                PagarCredito pagarCredito = new PagarCredito();
                pagarCredito.ShowDialog();
            };
            this.Controls.Add(btnPagar);

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
                Form1 form = new Form1();
                form.ShowDialog();
            };

            // Agregar el botón al formulario
            this.Controls.Add(btnVolver);

            // Asegurarse de que el botón esté por encima de otros controles
            btnVolver.BringToFront();

            Button btnSolicitarCredito = new Button
            {
                Text = "Solicitar Crédito",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point(350, 700),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSolicitarCredito.Click += (s, e) =>
            {
                this.Hide();
                FormSolicitudCredito solicitudForm = new FormSolicitudCredito();
                solicitudForm.ShowDialog();
            };
            this.Controls.Add(btnSolicitarCredito);

            // Crear el botón "Ver Productos" con imagen y colocarlo a la derecha
            Button btnVerProductos = new Button
            {
                Text = "", // No necesitamos texto, solo imagen
                Size = new Size(40, 40),
                Location = new Point(this.ClientSize.Width - 60, 10), // Colocado a la derecha, con un margen de 20px
                BackColor = ColorTranslator.FromHtml("#FFFFFF"),
                FlatStyle = FlatStyle.Flat,
                ImageAlign = ContentAlignment.MiddleCenter, // Centrar la imagen
                FlatAppearance = { BorderSize = 0 }
            };

            // Ruta de la imagen (actualiza con la correcta)
            string imagePathProductos = @"C:\Users\Fernanda Del Toro\Downloads\productos.jpg"; // Cambia el nombre y la ruta de la imagen

            // Verificar si la imagen existe antes de cargarla
            if (File.Exists(imagePathProductos))
            {
                // Cargar la imagen desde la ruta
                Image imgProductos = Image.FromFile(imagePathProductos);

                // Ajustar la imagen al tamaño del botón
                imgProductos = new Bitmap(imgProductos, new Size(40, 40)); // Escalar la imagen al tamaño del botón

                btnVerProductos.Image = imgProductos;
            }
            else
            {
                MessageBox.Show("La imagen de productos no se encuentra en la ruta especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Manejar el evento de clic del botón "Ver Productos"
            btnVerProductos.Click += (s, e) =>
            {
                this.Hide();
                ProductosDisponibles productosDisponibles = new ProductosDisponibles();


                productosDisponibles.ShowDialog();
            };

            // Agregar el botón al formulario
            this.Controls.Add(btnVerProductos);

            // Asegurarse de que el botón esté por encima de otros controles
            btnVerProductos.BringToFront();



        }


    }
}
