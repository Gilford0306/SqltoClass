
namespace SqltoClass
{
    internal class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return $"{id}) Login:  {login}  Password:  {password}\n";
        }

        private User()
        { }
        public User(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
        public User( string login, string password)
        {
            this.login = login;
            this.password = password;
        }

    }
}
