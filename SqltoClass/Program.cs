using SqltoClass;

string conect = "Server=DESKTOP-37B5THF;Database = Note;Trusted_Connection=True;";
UserTable userTable = new UserTable(conect);
userTable.Show();
User user = new User("test_user", "111111");
userTable.Add(conect, user);
userTable = new UserTable(conect);//создание нового объекта для того что бы были видны изменения
userTable.Show();
Console.WriteLine("Enter the id to be deleted");
int num = int.Parse(Console.ReadLine());
userTable.Del(conect, num);
userTable = new UserTable(conect);
userTable.Show();



