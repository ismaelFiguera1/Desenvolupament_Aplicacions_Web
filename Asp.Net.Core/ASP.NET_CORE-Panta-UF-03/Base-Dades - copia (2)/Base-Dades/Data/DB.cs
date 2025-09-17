
using MySql.Data.MySqlClient;


namespace Base_Dades.Data
{
    public static class DB
    {
        public static MySqlConnection ObtenirConnexio()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=127.0.0.1;uid=root;pwd=user;database=world";

            return conn;
        }

    }
}
