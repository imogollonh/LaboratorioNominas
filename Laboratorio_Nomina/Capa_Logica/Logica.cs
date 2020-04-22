using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class Logica
    {
        Sentencias sn = new Sentencias();
        /*-----------------------------------------------------------------------Metodos Generales------------------------------------------------------------*/
        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }

        public OdbcDataReader modificarConcepto(string sCodigo, string sNombre, string sTipoconcepto)
        {
            return sn.modificarconcepto(sCodigo, sNombre, sTipoconcepto);
        }
        public OdbcDataReader Insertarconcepto(string sCodigo, string sNombre, string sTipoconcepto)
        {
            return sn.Insertarconcepto(sCodigo, sNombre, sTipoconcepto);

        }

        public OdbcDataReader eliminarconcepto(string sCodigo)
        {
            return sn.eliminarconcepto(sCodigo);

        }

        public OdbcDataReader consultarconcepto()
        {
            return sn.consultaconcepto();
        }


        public OdbcDataReader modificarDepartamento(string sCodigo, string sNombre)
        {
            return sn.modificarDepartamento(sCodigo, sNombre);
        }

        public OdbcDataReader InsertarDepartamento(string sCodigo, string sNombre)
        {
            return sn.InsertarDepartamento(sCodigo, sNombre);

        }

        public OdbcDataReader eliminarDepartamento(string sCodigo)
        {
            return sn.eliminarDepartamento(sCodigo);

        }
        public OdbcDataReader consultarDepartamento()
        {
            return sn.consultaDepartamento();
        }


        //----Insertar Puesto
        public OdbcDataReader InsertarPuesto(string sCodigo, string sNombre)
        {
            return sn.InsertarPuesto(sCodigo, sNombre);

        }

        //----Modificar Puesto
        public OdbcDataReader modificarPuesto(string sCodigo, string sNombre)
        {
            return sn.modificarPuesto(sCodigo, sNombre);

        }

        //----Eliminar Puesto
        public OdbcDataReader eliminarPuesto(string sCodigo)
        {
            return sn.eliminarPuesto(sCodigo);

        }

        //-----Consultar Puesto
        public OdbcDataReader consultarPuesto()
        {
            return sn.consultaPuesto();
        }

        public OdbcDataReader modificarEmpleado( string cod, string nombre, string descripcion, string departamento, string sueldo)
        {
            return sn.modificarEmpleado(cod, nombre,  descripcion, departamento, sueldo);
        }

        public OdbcDataReader consultarEmpleado()
        {
            return sn.consultaEmpleado();
        }

        //----Eliminar Puesto
        public OdbcDataReader eliminarEmpleado(string sCodigo)
        {
            return sn.eliminarEmpleado(sCodigo);

        }

        public OdbcDataReader insertarEmpleado(string cod, string nombre, string descripcion, string departamento, string sueldo)
        {
            return sn.insertarEmpleado(cod, nombre, descripcion, departamento, sueldo);
        }
    }
}
