namespace TestApp.Services.APIDataType
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            AppID = 3;
            CompanyID = 3;
            KeepLogined = true;
            UserType = "UserID";
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AppID { get; set; }
        public int CompanyID { get; set; }
        public string UserType { get; set; }
        public bool KeepLogined { get; set; }
    }
}
