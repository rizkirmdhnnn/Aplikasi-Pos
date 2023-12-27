using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace Aplikasi_Pos.Model.Context
{
    public class dbContext : IDisposable
    {
        public MySqlConnection cnn;
        public MySqlConnection ConnectionOpen()
        {
            string myConnectionString = "server=localhost;database=aplikasi-pos;uid=root;pwd=";
            MySqlConnection cnn = new MySqlConnection(myConnectionString);

            cnn.Open();

            return cnn;
        }

        public void Dispose()
        {
            if (cnn != null)
            {
                try
                {
                    if (cnn.State != ConnectionState.Closed) cnn.Close();
                }
                finally
                {
                    cnn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
