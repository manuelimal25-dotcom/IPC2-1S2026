namespace Semana_7
{
    // Formulario principal que funciona como menú
    // Permite elegir entre ver Pila o Cola
    public class FormMenu : Form
    {
        private Button btnPila;
        private Button btnCola;
        private Label lblTitulo;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Menú Principal - Pilas y Colas";
            this.Size = new System.Drawing.Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Label de título
            lblTitulo = new Label();
            lblTitulo.Text = "Seleccione una estructura de datos:";
            lblTitulo.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new Point(50, 30);
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // Botón para abrir formulario de Pila
            btnPila = new Button();
            btnPila.Text = "Gestión de Pila (Libros)";
            btnPila.Location = new Point(75, 90);
            btnPila.Size = new Size(250, 50);
            btnPila.Font = new System.Drawing.Font("Arial", 10);
            btnPila.BackColor = System.Drawing.Color.LightBlue;
            btnPila.Click += BtnPila_Click;
            this.Controls.Add(btnPila);

            // Botón para abrir formulario de Cola
            btnCola = new Button();
            btnCola.Text = "Gestión de Cola (Personas)";
            btnCola.Location = new Point(75, 160);
            btnCola.Size = new Size(250, 50);
            btnCola.Font = new System.Drawing.Font("Arial", 10);
            btnCola.BackColor = System.Drawing.Color.LightGreen;
            btnCola.Click += BtnCola_Click;
            this.Controls.Add(btnCola);
        }

        // Evento: Abrir formulario de Pila
        private void BtnPila_Click(object? sender, EventArgs e)
        {
            FormPila formPila = new FormPila();
            formPila.ShowDialog(); // Abre como modal
        }

        // Evento: Abrir formulario de Cola
        private void BtnCola_Click(object? sender, EventArgs e)
        {
            FormCola formCola = new FormCola();
            formCola.ShowDialog(); // Abre como modal
        }
    }
}