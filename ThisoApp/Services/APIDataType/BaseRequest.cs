namespace ThisoApp.Services.APIDataType
{
    public class BaseRequest
    {
        public string Language { get; set; }

        public string AppName { get; set; }

        public BaseRequest()
        {
            Language = "Vn";
            AppName = "ThisoWeb";
        }
    }
}
