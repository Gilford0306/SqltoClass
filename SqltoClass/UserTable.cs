using System.Data.SqlClient;
namespace SqltoClass
{
    class UserTable
    {
        User[] arr = new User[0];
        public UserTable(string connet)
        {
            using (SqlConnection conn = new SqlConnection(connet))

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT * FROM[Note].[dbo].[user] ", conn))

                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = user;
                    }

                }
            }
        }
        public void Show()
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void Add(string connet, User user)
        {

            string sqlText = String.Format(@"INSERT INTO[dbo].[user]([login],[password]) VALUES('{0}','{1}');", user.login, user.password);
            using (SqlConnection conn = new SqlConnection(connet))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlText, conn))
                {
                    if (command.ExecuteNonQuery() > 0)
                        Console.WriteLine("Rows added!");

                }
                Console.WriteLine("");
            }
        }
        public void Del(string connet, int num)
        {
            string sqlText = String.Format(@"DELETE FROM [dbo].[user] WHERE id = {0};", num);
            using (SqlConnection conn = new SqlConnection(connet))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlText, conn))
                {
                    if (command.ExecuteNonQuery() > 0)
                        Console.WriteLine("Rows deleted!");
                }
                Console.WriteLine("");
            }

        }

    }
}






