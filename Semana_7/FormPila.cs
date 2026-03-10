namespace Semana_7
{
    // Formulario para gestionar la Pila de Libros
    // Permite realizar operaciones: Push, Pop, Peek
    public class FormPila : Form
    {
        // Estructura de datos
        private PilaLibros pilaLibros;

        // Controles del formulario
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private Button btnPush;
        private Button btnPop;
        private Button btnPeek;
        private RichTextBox txtResultado;
        private Label lblTitulo;
        private Label lblAutor;
        private Label lblResultado;

        public FormPila()
        {
            pilaLibros = new PilaLibros();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Gestión de Pila - Libros";
            this.Size = new System.Drawing.Size(500, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Label - Título del libro
            lblTitulo = new Label();
            lblTitulo.Text = "Título del libro:";
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.AutoSize = true;
            this.Controls.Add(lblTitulo);

            // TextBox - Título del libro
            txtTitulo = new TextBox();
            txtTitulo.Location = new Point(30, 55);
            txtTitulo.Size = new Size(420, 25);
            this.Controls.Add(txtTitulo);

            // Label - Autor del libro
            lblAutor = new Label();
            lblAutor.Text = "Autor:";
            lblAutor.Location = new Point(30, 90);
            lblAutor.AutoSize = true;
            this.Controls.Add(lblAutor);

            // TextBox - Autor del libro
            txtAutor = new TextBox();
            txtAutor.Location = new Point(30, 115);
            txtAutor.Size = new Size(420, 25);
            this.Controls.Add(txtAutor);

            // Botón PUSH (agregar libro al tope)
            btnPush = new Button();
            btnPush.Text = "PUSH (Agregar)";
            btnPush.Location = new Point(30, 160);
            btnPush.Size = new Size(130, 40);
            btnPush.BackColor = System.Drawing.Color.LightGreen;
            btnPush.Click += BtnPush_Click;
            this.Controls.Add(btnPush);

            // Botón POP (eliminar libro del tope)
            btnPop = new Button();
            btnPop.Text = "POP (Eliminar)";
            btnPop.Location = new Point(175, 160);
            btnPop.Size = new Size(130, 40);
            btnPop.BackColor = System.Drawing.Color.LightCoral;
            btnPop.Click += BtnPop_Click;
            this.Controls.Add(btnPop);

            // Botón PEEK (ver libro del tope sin eliminar)
            btnPeek = new Button();
            btnPeek.Text = "PEEK (Ver tope)";
            btnPeek.Location = new Point(320, 160);
            btnPeek.Size = new Size(130, 40);
            btnPeek.BackColor = System.Drawing.Color.LightBlue;
            btnPeek.Click += BtnPeek_Click;
            this.Controls.Add(btnPeek);

            // Label - Resultado
            lblResultado = new Label();
            lblResultado.Text = "Contenido de la Pila:";
            lblResultado.Location = new Point(30, 220);
            lblResultado.AutoSize = true;
            this.Controls.Add(lblResultado);

            // RichTextBox - Mostrar contenido de la pila 
            txtResultado = new RichTextBox();  
            txtResultado.Location = new Point(30, 245);
            txtResultado.Size = new Size(420, 220);
            txtResultado.ReadOnly = true;
            txtResultado.Font = new System.Drawing.Font("Consolas", 10);
            txtResultado.BackColor = System.Drawing.Color.White;
            txtResultado.BorderStyle = BorderStyle.FixedSingle;
            txtResultado.WordWrap = false;  
            txtResultado.ScrollBars = RichTextBoxScrollBars.Vertical; 
            this.Controls.Add(txtResultado);
        }

        // Evento PUSH: Agregar un libro al tope de la pila
        private void BtnPush_Click(object? sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("Por favor ingrese título y autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el libro y agregarlo a la pila
            Libro nuevoLibro = new Libro(txtTitulo.Text, txtAutor.Text);
            pilaLibros.Push(nuevoLibro);

            Console.WriteLine($"PUSH realizado: {nuevoLibro.ToString()}");

            // Limpiar campos
            txtTitulo.Clear();
            txtAutor.Clear();
            txtTitulo.Focus();

            // Actualizar visualización
            ActualizarVista();

            MessageBox.Show("Libro agregado al tope de la pila.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento POP: Eliminar el libro del tope de la pila
        private void BtnPop_Click(object? sender, EventArgs e)
        {
            Libro? libroEliminado = pilaLibros.Pop();

            // Verificar si la pila estaba vacía
            if (libroEliminado == null)
            {
                Console.WriteLine("La pila está vacía. No se puede hacer POP.");
                MessageBox.Show("La pila está vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine($"POP realizado: {libroEliminado.ToString()}");

            // Actualizar visualización
            ActualizarVista();

            MessageBox.Show($"Libro eliminado:\n{libroEliminado.ToString()}", "Libro Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento PEEK: Ver el libro del tope sin eliminarlo
        private void BtnPeek_Click(object? sender, EventArgs e)
        {
            Libro? libroTope = pilaLibros.Peek();

            // Verificar si la pila está vacía
            if (libroTope == null)
            {
                Console.WriteLine("La pila está vacía. No se puede hacer PEEK.");
                MessageBox.Show("La pila está vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine($"PEEK realizado: {libroTope.ToString()}");

            MessageBox.Show($"Libro en el tope:\n{libroTope.ToString()}", "Tope de la Pila", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Método auxiliar: Actualizar la vista del contenido de la pila
        private void ActualizarVista()
        {
            txtResultado.Text = pilaLibros.ObtenerLibros();
        }
    }
}