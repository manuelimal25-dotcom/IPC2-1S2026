namespace Semana_7
{
    // Formulario para gestionar la Cola de Personas
    // Permite realizar operaciones: Enqueue, Dequeue, Peek
    public class FormCola : Form
    {
        // Estructura de datos
        private ColaPersonas colaPersonas;

        // Controles del formulario
        private TextBox txtNombre;
        private TextBox txtEdad;
        private Button btnEnqueue;
        private Button btnDequeue;
        private Button btnPeek;
        private RichTextBox txtResultado;
        private Label lblNombre;
        private Label lblEdad;
        private Label lblResultado;

        public FormCola()
        {
            colaPersonas = new ColaPersonas();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Gestión de Cola - Personas";
            this.Size = new System.Drawing.Size(500, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Label - Nombre de la persona
            lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(30, 30);
            lblNombre.AutoSize = true;
            this.Controls.Add(lblNombre);

            // TextBox - Nombre de la persona
            txtNombre = new TextBox();
            txtNombre.Location = new Point(30, 55);
            txtNombre.Size = new Size(420, 25);
            this.Controls.Add(txtNombre);

            // Label - Edad de la persona
            lblEdad = new Label();
            lblEdad.Text = "Edad:";
            lblEdad.Location = new Point(30, 90);
            lblEdad.AutoSize = true;
            this.Controls.Add(lblEdad);

            // TextBox - Edad de la persona
            txtEdad = new TextBox();
            txtEdad.Location = new Point(30, 115);
            txtEdad.Size = new Size(420, 25);
            this.Controls.Add(txtEdad);

            // Botón ENQUEUE (agregar persona al final)
            btnEnqueue = new Button();
            btnEnqueue.Text = "ENQUEUE (Agregar)";
            btnEnqueue.Location = new Point(30, 160);
            btnEnqueue.Size = new Size(130, 40);
            btnEnqueue.BackColor = System.Drawing.Color.LightGreen;
            btnEnqueue.Click += BtnEnqueue_Click;
            this.Controls.Add(btnEnqueue);

            // Botón DEQUEUE (eliminar persona del frente)
            btnDequeue = new Button();
            btnDequeue.Text = "DEQUEUE (Atender)";
            btnDequeue.Location = new Point(175, 160);
            btnDequeue.Size = new Size(130, 40);
            btnDequeue.BackColor = System.Drawing.Color.LightCoral;
            btnDequeue.Click += BtnDequeue_Click;
            this.Controls.Add(btnDequeue);

            // Botón PEEK (ver persona del frente sin eliminar)
            btnPeek = new Button();
            btnPeek.Text = "PEEK (Ver frente)";
            btnPeek.Location = new Point(320, 160);
            btnPeek.Size = new Size(130, 40);
            btnPeek.BackColor = System.Drawing.Color.LightBlue;
            btnPeek.Click += BtnPeek_Click;
            this.Controls.Add(btnPeek);

            // Label - Resultado
            lblResultado = new Label();
            lblResultado.Text = "Personas en la Cola:";
            lblResultado.Location = new Point(30, 220);
            lblResultado.AutoSize = true;
            this.Controls.Add(lblResultado);

            // RichTextBox - Mostrar contenido de la cola
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

        // Evento ENQUEUE: Agregar una persona al final de la cola
        private void BtnEnqueue_Click(object? sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor ingrese nombre y edad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la edad sea un número
            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear la persona y agregarla a la cola
            Persona nuevaPersona = new Persona(txtNombre.Text, edad);
            colaPersonas.Enqueue(nuevaPersona);

            Console.WriteLine($"ENQUEUE realizado: {nuevaPersona.ToString()}");

            // Limpiar campos
            txtNombre.Clear();
            txtEdad.Clear();
            txtNombre.Focus();

            // Actualizar visualización
            ActualizarVista();

            MessageBox.Show("Persona agregada al final de la cola.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento DEQUEUE: Eliminar (atender) la persona del frente de la cola
        private void BtnDequeue_Click(object? sender, EventArgs e)
        {
            Persona? personaAtendida = colaPersonas.Dequeue();

            // Verificar si la cola estaba vacía
            if (personaAtendida == null)
            {
                Console.WriteLine("La cola está vacía. No se puede hacer DEQUEUE.");
                MessageBox.Show("La cola está vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine($"DEQUEUE realizado: {personaAtendida.ToString()}");

            // Actualizar visualización
            ActualizarVista();

            MessageBox.Show($"Persona atendida:\n{personaAtendida.ToString()}", "Persona Atendida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento PEEK: Ver la persona del frente sin eliminarla
        private void BtnPeek_Click(object? sender, EventArgs e)
        {
            Persona? personaFrente = colaPersonas.Peek();

            // Verificar si la cola está vacía
            if (personaFrente == null)
            {
                Console.WriteLine("La cola está vacía. No se puede hacer PEEK.");
                MessageBox.Show("La cola está vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine($"PEEK realizado: {personaFrente.ToString()}");

            MessageBox.Show($"Siguiente persona en ser atendida:\n{personaFrente.ToString()}", "Frente de la Cola", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Método auxiliar: Actualizar la vista del contenido de la cola
        private void ActualizarVista()
        {
            txtResultado.Text = colaPersonas.ObtenerPersonas();
        }
    }
}