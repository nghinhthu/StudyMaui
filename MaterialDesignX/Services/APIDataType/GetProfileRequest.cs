namespace MaterialDesignX.Services.APIDataType
{
    public class GetProfileRequest
    {
        public GetProfileRequest()
        {

        }
        public string Language { get; set; }
        public string AppName { get; set; }
        public string SessionID { get; set; }
        public string MemID { get; set; }
    }
}
