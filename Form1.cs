using System.ComponentModel;
using System.Text.Json;

namespace PersonasApp;

public partial class Form1 : Form
{
    // Los datos se guardan en este archivo junto al .exe (así no se pierden al cerrar)
    readonly string _archivo = Path.Combine(AppContext.BaseDirectory, "personas.json");
    BindingList<Persona> _lista;
    Persona _editando;   // persona seleccionada (null = registro nuevo)

    public Form1()
    {
        InitializeComponent();
        Cargar();
        dgvPersonas.DataSource = _lista;
        dgvPersonas.ClearSelection();
    }

    // ---------- Guardar / actualizar ----------
    void btnGuardar_Click(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text.Trim();

        if (nombre == "")
        {
            MessageBox.Show("Escriba el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNombre.Focus();
            return;
        }
        if (!int.TryParse(txtEdad.Text, out int edad) || edad < 0 || edad > 150)
        {
            MessageBox.Show("Escriba una edad válida (0 a 150).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEdad.Focus();
            return;
        }

        if (_editando == null)
        {
            _lista.Add(new Persona { Nombre = nombre, Edad = edad });
        }
        else
        {
            _editando.Nombre = nombre;
            _editando.Edad = edad;
            _lista.ResetItem(_lista.IndexOf(_editando));
        }

        Guardar();
        Limpiar();
    }

    // ---------- Limpiar ----------
    void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();

    void Limpiar()
    {
        _editando = null;
        txtNombre.Clear();
        txtEdad.Clear();
        dgvPersonas.ClearSelection();
        btnGuardar.Text = "Guardar";
        txtNombre.Focus();
    }

    // ---------- Eliminar ----------
    void btnEliminar_Click(object sender, EventArgs e) => Eliminar();

    void dgvPersonas_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete) { Eliminar(); e.Handled = true; }
    }

    void Eliminar()
    {
        if (dgvPersonas.CurrentRow?.DataBoundItem is not Persona p || !dgvPersonas.CurrentRow.Selected)
        {
            MessageBox.Show("Seleccione una fila de la tabla para eliminar.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show($"¿Eliminar a '{p.Nombre}'?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        _lista.Remove(p);
        Guardar();
        Limpiar();
    }

    // ---------- Al hacer clic en una fila, se carga para editarla ----------
    void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        _editando = _lista[e.RowIndex];
        txtNombre.Text = _editando.Nombre;
        txtEdad.Text = _editando.Edad.ToString();
        btnGuardar.Text = "Actualizar";
    }

    // Solo números en Edad
    void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
    }

    // ---------- Persistencia ----------
    void Cargar()
    {
        try
        {
            _lista = File.Exists(_archivo)
                ? new BindingList<Persona>(JsonSerializer.Deserialize<List<Persona>>(File.ReadAllText(_archivo)) ?? new())
                : new BindingList<Persona>();
        }
        catch
        {
            _lista = new BindingList<Persona>();
        }
    }

    void Guardar()
    {
        File.WriteAllText(_archivo, JsonSerializer.Serialize(_lista.ToList(),
            new JsonSerializerOptions { WriteIndented = true }));
    }
}
