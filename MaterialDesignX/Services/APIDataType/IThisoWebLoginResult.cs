namespace MaterialDesignX.Services.APIDataType
{
    public class IThisoWebLoginResult
    {
        public IThisoWebLoginResult()
        {

        }
        public string SessionID { get; set; }

        public DateTime LoginDate { get; set; }

        public string MemID { get; set; }

        public string CardNo { get; set; }

        public string FullName { get; set; }

        public string UserID { get; set; }

        public string ShortAddress { get; set; }

        public bool IsSuccess { get; set; }

        public string Mobile { get; set; }
    }
}
