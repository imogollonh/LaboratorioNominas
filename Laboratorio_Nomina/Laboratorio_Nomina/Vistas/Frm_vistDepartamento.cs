﻿using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_Nomina.Vistas
{
    public partial class Frm_vistDepartamento : Form
    {
        Logica logic = new Logica();
        public Frm_vistDepartamento()
        {
            InitializeComponent();
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }


        //-----------------------------------------------------------------------------------para mostrar en DGV------------------------------------------------------------------------------
        public void MostrarConsulta()
        {
            OdbcDataReader mostrar = logic.consultarDepartamento();
            try
            {
                while (mostrar.Read())
                {
                    Dgv_consulta.Rows.Add(mostrar.GetString(0), mostrar.GetString(1));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void Frm_vistDepartamento_Load(object sender, EventArgs e)
        {
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (Dgv_consulta.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
