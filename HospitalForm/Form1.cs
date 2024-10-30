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
    public partial class Form1 : Form
    {
        public List<Persona> personas = new List<Persona>();
        private FormPaciente formPaciente;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Visibilidad(false, false, false, false, false);
                    dataListaPersonas.DataSource = personas;
                    break;
                case 1:
                    Visibilidad(true, true, false, false, false);
                    dataListaPersonas.DataSource = personas.OfType<Paciente>().ToList();
                    break;
                case 2:
                    Visibilidad(true, false, false , false, false); 
                    dataListaPersonas.DataSource = personas.OfType<Medico>().ToList();
                    break;
                case 3:
                    Visibilidad(true, false, false , false, false); 
                    dataListaPersonas.DataSource = personas.OfType<PersonalAdministrativo>().ToList();
                    break;
                case 4:
                    Visibilidad(false, false, false, false, false);
                    dataListaPersonas.DataSource = personas.OfType<PersonalHospital>().ToList();
                    break;
            }
        }

        private void Visibilidad(bool add, bool delete, bool buscar, bool label, bool DNI)
        {
            buttonAdd.Visible = add;
            buttonDelete.Visible = delete;
            buttonBuscar.Visible = buscar;
            label1.Visible = label;
            textDNIPaciente.Visible = DNI;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1) 
            {
                foreach (DataGridViewRow fila in dataListaPersonas.SelectedRows)
                {
                    Paciente paciente = (Paciente)fila.DataBoundItem;

                    personas.Remove(paciente);
                }

                dataListaPersonas.DataSource = null;
                dataListaPersonas.DataSource = personas.OfType<Paciente>().ToList();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    formPaciente = new FormPaciente(personas.OfType<Medico>().ToList());

                    if (formPaciente.ShowDialog() == DialogResult.OK)
                        personas.Add(formPaciente.Paciente);

                    dataListaPersonas.DataSource = null;
                    dataListaPersonas.DataSource = personas.OfType<Paciente>().ToList();
                    break;
                case 2:
                    personas.Add(new Medico());
                    dataListaPersonas.DataSource = null;
                    dataListaPersonas.DataSource = personas.OfType<Medico>().ToList();
                    break;
                case 3:
                    personas.Add(new PersonalAdministrativo());
                    dataListaPersonas.DataSource = null;
                    dataListaPersonas.DataSource = personas.OfType<PersonalAdministrativo>().ToList();
                    break;
            }
        }

    }
}
