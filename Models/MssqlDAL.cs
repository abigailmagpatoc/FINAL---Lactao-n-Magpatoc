﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Student.BusinessLogic;
using Student.Account.BusinessLogic;

namespace Layer.DataAccess
{
    class MssqlDAL
    {
        private const string ConnectionString = @"Server=198.38.83.33;" 
            + "Database=eisensy_csbintepro;UID=eisensy_student;PWD=Benilde@2020";

        private SqlConnection cn = new SqlConnection(ConnectionString);

        private SqlCommand cmd;

        public void Open()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }

        public void Close()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        public void SetSql(string Command)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = Command;
        }

        public void AddParameter(string ParamName, object ParamValue)
        {
            cmd.Parameters.AddWithValue(ParamName, ParamValue);
        }

        public void ClearParameters()
        {
            cmd.Parameters.Clear();
        }

        public void Execute() //Execute non query (add, edit, delete)
        {
            cmd.ExecuteNonQuery();
        }

        public DataTable GetData()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public SqlDataReader GetReader()
        {
            return cmd.ExecuteReader();
        }
    }
}
