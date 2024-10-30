using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalForm
{
    public partial class FormPaciente : Form
    {
        private Paciente paciente;
        public Paciente Paciente { get { return paciente; } }
        public FormPaciente(List<Medico> medicos)
        {
            InitializeComponent();
            comboBox1.DataSource = medicos;
        }

        private void FormPaciente_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            paciente = new Paciente(textNombre.Text, (int) numericUpDown1.Value, textEnfermedad.Text, (Medico) comboBox1.SelectedItem);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
