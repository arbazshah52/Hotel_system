namespace App;
// user class represt user like admin
//login and manage hotel room
class User
{
    public string Username; // store the username of user
    public string _password; //store the user password
    //it sets the username and password for that user
    public User(string username, string password)
    {
        Username = username;
        _password = password;
    }
    // this method check login details
    // return true if both match otherwise false
    public bool TryLogin(string username, string password)
    {
        return Username == username && _password == password;
    }
    //saved to a text file user.save and reloaded
    public string ToSaveString()// thsi method convert to single string
    {
        return $"{Username},{_password}";
    }
}