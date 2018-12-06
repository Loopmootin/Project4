using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Project4
{
    public class Utility
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlDataAdapter da = null;
        private DataSet ds = null;
        private DataTable dt = null;

        public Utility()
        {
            //conn = new SqlConnection(@"data source = DESKTOP-6CQP77U; integrated security = true; database = MovieDatabase");
            conn = new SqlConnection(@"data source = LAPTOP-A8BTI830; integrated security = true; database = MovieDatabase");
            cmd = null;
            rdr = null;
            conn.Open();
        }

        ~Utility() {

          conn.Close();
        }

        public void mysql(string sqlsel, string sqlupd)
        {
            string Sqlsel = sqlsel;
            string Sqlupd = sqlupd;
        }

        public void createCommand(string text, CommandType type)
        {
            conn.CreateCommand();

            cmd = conn.CreateCommand();
            cmd.CommandText = text;
            cmd.CommandType = type;
            
        }

        public SqlCommand Selectcommand(string sqlstring, SqlConnection conn)
        {
            return new SqlCommand(sqlstring, conn);
        }

        public SqlParameter AddParameter(string parameterName, SqlDbType type)
        {
            return cmd.Parameters.Add(parameterName, type);
        }

        public SqlDataReader executeCmd()
        {
            return cmd.ExecuteReader();
        }

    }
}