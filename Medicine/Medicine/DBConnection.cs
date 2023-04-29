using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Medicine
{
    class DBConnection
    {
        public MySqlConnection connection;
        public string connectionStr;

        public DBConnection()
        {

            try
            {
                connectionStr = "server=127.0.0.1;port=3306;user=root;password=13783974992; database=medicineinfo;";
                connection = new MySqlConnection(connectionStr); //新建连接
                connection.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("DBConnection Constructor:" + ex.Message);
            }
        }
    }
    
}
