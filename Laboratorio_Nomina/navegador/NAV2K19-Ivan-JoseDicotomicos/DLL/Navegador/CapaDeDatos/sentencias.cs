﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class sentencias
    {

        conexion cn = new conexion();

        public OdbcDataAdapter llenaTbl(string tabla)// metodo  que obtinene el contenio de una tabla
        {
          
            string sql = "SELECT * FROM " + tabla + ";";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.probarConexion());
            return dataTable;
        }




        public string modRuta(string idindice)// metodo  que obtinene el contenio de una tabla
        {


            string indice2 = " ";
            OdbcCommand command = new OdbcCommand("SELECT * FROM ayuda WHERE id_ayuda = " + idindice + ";", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                indice2 = reader.GetValue(1).ToString();

            }
            return indice2;// devuelve un arrgeglo con los campos


        }
        public string modIndice(string idindice)// metodo  que obtinene el contenio de una tabla
        {


            string indice = " ";
            OdbcCommand command = new OdbcCommand("SELECT * FROM ayuda WHERE id_ayuda = " + idindice + ";", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                indice = reader.GetValue(2).ToString();
            }


            return indice;// devuelve un arrgeglo con los campos


        }




        public string[] obtenerCampos(string tabla)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            string[] Campos = new string[30];
            int i = 0;
            OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               Campos[i] = reader.GetValue(0).ToString();
                i++;

            }

            return Campos;// devuelve un arrgeglo con los campos
        }

        public string[] obtenerTipo(string tabla)//metodo que obtiene la lista de los tipos de campos que requiere una tabla
        {
            string[] Campos = new string[30];
            int i = 0;
            OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Campos[i] = limpiarTipo(reader.GetValue(1).ToString());
                i++;

            }

            return Campos;// devuelve un arreglo con los tipos
        }
        public string[] obtenerLLave(string tabla)//metodo que obtiene la lista de los tipos de campos que requiere una tabla
        {
            string[] Campos = new string[30];
            int i = 0;
            OdbcCommand command = new OdbcCommand("DESCRIBE " + tabla + "", cn.probarConexion());
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Campos[i] = reader.GetValue(3).ToString();
                i++;

            }

            return Campos;// devuelve un arreglo con los tipos
        }
        public string[] obtenerItems(string tabla, string campo)//metodo que obtiene la lista de los tipos de campos que requiere una tabla
        {
            string[] items = new string[300];
            int i = 0;


            try {

                OdbcCommand command = new OdbcCommand("select  " + campo + " FROM " + tabla, cn.probarConexion());
                OdbcDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        items[i] = reader.GetValue(0).ToString();
                        i++;

                    }
                } catch (Exception ex) { Console.WriteLine(ex.Message.ToString()+" \nError en asignarCombo, revise los parametros \n -"+tabla+"\n -"+campo ); }
            

            return items;// devuelve un arreglo con los tipos
        }
        string limpiarTipo(string cadena)// elimina los parentesis y tama;o de campo del tipo de campo
        {
            bool dim = false;
            string nuevaCadena = "";
            for (int j = 0; j < cadena.Length; j++)
            {
                if (cadena[j] == '(') { dim = true; }
            }

            if (dim == true)
            {
                int i = 0;

                int tam = cadena.Length;

                while (cadena[i] != '(')
                {
                    nuevaCadena += cadena[i];
                    i++;
                }

            }
            else
            {
                return cadena;
            }

            return nuevaCadena;// devuelve la cadena unicamente con el tipo
        }

        public void ejecutarQuery(string query)// ejecuta un query en la BD
        {
            try
            {
                OdbcCommand consulta = new OdbcCommand(query, cn.probarConexion());
                consulta.ExecuteNonQuery();
            }
            catch (OdbcException ex) { Console.WriteLine(ex.ToString()); }
           
        }
    }
}
