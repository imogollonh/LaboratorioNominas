using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorio_Nomina.Vistas;
using Laboratorio_Nomina.Consultas;
using System.Data.Odbc;

namespace Laboratorio_Nomina.Mantenimientos
{
    public partial class Frm_MantenimientoEmpleado : Form
    {
        Logica logic = new Logica();
        string scampo;
        public Frm_MantenimientoEmpleado()
        {
            InitializeComponent();
        }

        public void bloqueartxt()
        {
            /*------------------------*/
            Btn_guardar.Enabled = false;
            Btn_editar.Enabled = false;
            Btn_borrar.Enabled = false;
            /*------------------------*/
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = false;
            txt_sueldo.Enabled = false;
        }

        public void desbloqueartxt()
        {
            /*------------------------*/
            Btn_guardar.Enabled = true;
            Btn_editar.Enabled = true;
            Btn_borrar.Enabled = true;
            /*------------------------*/
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = true;
            txt_sueldo.Enabled = true;
        }

        public void limpiar()
        {
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = false;
            Txt_Cod.Text = "";
            Txt_nombre.Text = "";
            txt_departamento.Text = "";
            txt_sueldo.Text = "";
            txt_descripcion.Text = "";

            scampo = logic.siguiente("empleado", "codigo_empleado");
            Txt_Cod.Text = scampo;
        }

        private void Frm_MantenimientoEmpleado_Load(object sender, EventArgs e)
        {
            scampo = logic.siguiente("empleado", "codigo_empleado");
            bloqueartxt();
            Txt_Cod.Text = scampo;
            Txt_nombre.Enabled = false;
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            desbloqueartxt();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta_Puesto puesto = new Consulta_Puesto();
            puesto.ShowDialog();

            if (puesto.DialogResult == DialogResult.OK)
            {
                txt_descripcion.Text = puesto.Dgv_consulta.Rows[puesto.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_vistDepartamento dep = new Frm_vistDepartamento();
            dep.ShowDialog();

            if (dep.DialogResult == DialogResult.OK)
            {
                txt_departamento.Text = dep.Dgv_consulta.Rows[dep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            OdbcDataReader ejectuar = logic.modificarEmpleado(Txt_Cod.Text, Txt_nombre.Text, txt_descripcion.Text, txt_departamento.Text, txt_sueldo.Text);
            MessageBox.Show("Datos modificados correctamente.");
            limpiar();
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            Frm_vistaEmpleado concep = new Frm_vistaEmpleado();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                Txt_Cod.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
                txt_descripcion.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                     Cells[2].Value.ToString();
                txt_departamento.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                     Cells[3].Value.ToString();
                txt_sueldo.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                     Cells[4].Value.ToString();
            }
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.eliminarEmpleado(Txt_Cod.Text);
            MessageBox.Show("Eliminado Correctamentee.");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.insertarEmpleado(Txt_Cod.Text, Txt_nombre.Text, txt_descripcion.Text, txt_departamento.Text, txt_sueldo.Text);
            MessageBox.Show("Datos registrados.");
            limpiar();
        }
    }
}
