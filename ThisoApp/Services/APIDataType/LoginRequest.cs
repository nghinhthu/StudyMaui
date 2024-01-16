namespace ThisoApp.Services.APIDataType
{
    public class LoginRequest
    {
        public LoginRequest()
        {

        }
        public string Language { get; set; }
        public string AppName { get; set; }
        public string AccountType { get; set; }
        public string UserID { get; set; }
        public string Pwd { get; set; }
    }
}
