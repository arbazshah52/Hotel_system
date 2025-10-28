namespace App;

class User
{
    public string Username;
    public string _password;
    public User(string username, string password)
    {
        Username = username;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return Username == username && _password == password;
    }
      public string ToSaveString()
    {
        return $"{Username},{_password}";
    }
}