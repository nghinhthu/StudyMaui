namespace ThisoApp.Services.APIDataType
{
    public class UpdateProfileRequest
    {
        public UpdateProfileRequest()
        {
            CustomerProfile = new CustomerProfile();
        }
        public string Language { get; set; }
        public string AppName { get; set; }
        public string SessionID { get; set; }
        public CustomerProfile CustomerProfile { get; set; }
    }
}
