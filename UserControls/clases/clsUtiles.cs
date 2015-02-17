using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data; 
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM.appUtils;

namespace clsUtiles
{ 
    class clsUtiles
    {
        static string mstrCmd = "";

        //public static System.Data.DataSet mImportarExcel(string pstrFile, string pstrCampos, string pstrCondicion, string pstrTabla)
        //{
        //    OleDbConnection con = null;
        //    DataSet myDataSet = new DataSet();
        //    try
        //    {
        //        string strConn;

        //        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
        //            "Data Source=" + pstrFile +
        //            ";Extended Properties=Excel 8.0;";

        //        con = new OleDbConnection(strConn);
        //        con.Open();
        //        object[] objArrRestrict;
        //        objArrRestrict = new object[] { null, null, null, null };
        //        DataTable tbl;
        //        tbl = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);

        //        string comm = "";
        //        if (pstrTabla != "")
        //            comm = "SELECT " + pstrCampos + " FROM [" + pstrTabla + "$] " + pstrCondicion;
        //        else
        //            comm = "SELECT " + pstrCampos + " FROM [" + tbl.Rows[0]["TABLE_NAME"] + "$] " + pstrCondicion;

        //        OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(comm, con);

        //        myCommand.Fill(myDataSet, "ExcelInfo");
        //        con.Close();
        //        return myDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        if (con != null)
        //            con.Close();
        //        throw (ex);
        //    }
        //}
        //public static System.Data.DataSet mImportarDBF(string pstrArch, string pstrCampos, string pstrCondicion, string pstrPath)
        //{
        //    OleDbConnection con = null;
        //    DataSet myDataSet = new DataSet();
        //    try
        //    {
        //        string strConn;

        //        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
        //            "Data Source=" + pstrPath + 
        //            ";Extended Properties=dBase IV;";

        //        con = new OleDbConnection(strConn);
        //        con.Open();
        //        object[] objArrRestrict;
        //        objArrRestrict = new object[] { null, null, null, null };
        //        DataTable tbl;
        //        tbl = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);

        //        string comm = "SELECT " + pstrCampos + " FROM " + pstrArch + " " + pstrCondicion;

        //        OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(comm, con);

        //        myCommand.Fill(myDataSet);
        //        con.Close();
        //        return myDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        if (con != null)
        //            con.Close();
        //        throw (ex);
        //    }
        //}
                
        public static bool gValidarDecimal(string pstrNro, System.Windows.Forms.TextBox pobjFoco)
        {
            if (!FormatUtils.IsDecimal(pstrNro))
            {
                MessageBox.Show("El valor ingresado es inválido, por favor ingrese un número entero o decimal.", "Error");
                if (pobjFoco != null)
                {
                    pobjFoco.Focus();
                    pobjFoco.SelectAll();
                }
                return (false);
            }
            else
                return (true);
        }
        
        public static bool gValidarNumero(string pstrNro, System.Windows.Forms.TextBox pobjFoco)
        {
            if (!FormatUtils.IsNumber(pstrNro))
            {
                MessageBox.Show("El valor ingresado es inválido, por favor ingrese un número entero.", "Error");
                if (pobjFoco != null)
                {
                    pobjFoco.Focus();
                    pobjFoco.SelectAll();
                }
                return (false);
            }
            else
                return (true);
        }

        public static void gCargarCombo(System.Windows.Forms.ComboBox pCombo, string pstrComboCodi, string pstrComboDesc, string pstrSql)
        {
            System.Data.DataSet dsCombo = new DataSet();
            //TODO
            //dsCombo = clsAccess.gExecuteQuery(mstrConn, pstrSql);
            DataGridViewComboBoxColumn colCombo = new DataGridViewComboBoxColumn();
            pCombo.DataSource = dsCombo.Tables["Table"];
            pCombo.DisplayMember = pstrComboDesc;
            pCombo.ValueMember = pstrComboCodi;
            pCombo.SelectedIndex = -1;
        }

        public static bool gValidarFecha(string pstrFecha, System.Windows.Forms.MaskedTextBox pobjFoco)
        {
            if (gFechaMascara(pstrFecha) == "")
                return (true);
            if (!FormatUtils.IsDate(pstrFecha))
            {
                MessageBox.Show("Fecha inválida, por favor ingrese el formato dd/mm/yyyy", "Error");
                if (pobjFoco != null)
                    pobjFoco.Focus();
                return (false);
            }
            else
                return (true);
        }

        public static string gFormatearFecha(object pstrFecha)
        {
            string lstrFecha = "";
            if (pstrFecha == null || pstrFecha.ToString() == "")
            {
                lstrFecha = "";
            }
            else
            {
                if (pstrFecha.ToString().IndexOf(" ") != -1)
                    pstrFecha = pstrFecha.ToString().Substring(0,pstrFecha.ToString().IndexOf(" ")).Trim();
                if (pstrFecha.ToString().Length == 8)
                {
                    lstrFecha = lstrFecha + pstrFecha.ToString().Substring(0, 2) + "/";
                    lstrFecha = lstrFecha + pstrFecha.ToString().Substring(2, 2) + "/";
                    lstrFecha = lstrFecha + pstrFecha.ToString().Substring(4, 4);
                }
                else
                {
                    lstrFecha = pstrFecha.ToString();
                }
            }
            return(lstrFecha);
        }
        
        public static bool gValidarFecha(string pstrFecha)
        {
            if (!FormatUtils.IsDate(pstrFecha))
            {
                MessageBox.Show("Fecha inválida, por favor ingrese el formato dd/mm/yyyy", "Error");
                return (false);
            }
            else
                return (true);
        }

        public static bool gValidarFecha(string pstrFecha, System.Windows.Forms.TextBox pobjFoco)
        {
            if (!FormatUtils.IsDate(pstrFecha))
            {
                MessageBox.Show("Fecha inválida, por favor ingrese el formato dd/mm/yyyy", "Error");
                if (pobjFoco != null)
                    pobjFoco.Focus();
                return (false);
            }
            else
                return (true);
        }
                
        public static string gFechaMascara (string pstrFecha)
        {
            if (pstrFecha.Trim() == "/  /") 
                return("");
            else
                return (pstrFecha);
        }        
    }
}
