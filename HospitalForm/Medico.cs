﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalForm
{    
    /// <summary>
     /// Enum que define las especialidades que puede tener un medico
     /// </summary>
    public enum eEspecialidad
    {
        Cardiologia = 1,
        Pediatria = 2,
        Dermatologia = 3,
        Geriatria = 4,
        Urologia = 5
    }

    /// <summary>
    /// Clase publica que gestiona la informacion de un medico
    /// </summary>
    public class Medico : PersonalHospital
    {
        public List<Paciente> Pacientes { get; set; }
        public eEspecialidad Especialidad { get; set; }

        public Medico() : base()
        {
            Pacientes = new List<Paciente>();
            Especialidad = eEspecialidad.Pediatria;
        }
        public Medico(string nombre, int edad, int sueldo, eEspecialidad especialidad) : base(nombre, edad, sueldo)
        {
            Pacientes = new List<Paciente>();
            Especialidad = especialidad;
        }

        /// <summary>
        /// Metodo que añade un paciente
        /// </summary>
        public void AñadirPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        /// <summary>
        /// Metodo que elimina un paciente
        /// </summary>
        public void EliminarPaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

        /// <summary>
        /// Metodo que muestra los pacientes de este medico
        /// </summary>
        public void MostrarMisPacientes()
        {
            foreach (Paciente p in Pacientes)
                Console.WriteLine(p.ToString());
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
