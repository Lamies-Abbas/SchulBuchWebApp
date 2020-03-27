using Dapper;
using SchulBuchWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace SchulBuchWebApp.DataAccess
{
    public static class MDBDataAccess
    {
        public static string GetConnectionString(string connectionName = "SchulBuchWebAppConnectionString")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new OleDbConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }
        internal static int DeleteData(string sql)
        {
            using (IDbConnection cnn = new OleDbConnection(GetConnectionString()))
            {
                return cnn.Execute(sql);
            }
        }

    }
}