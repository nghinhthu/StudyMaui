namespace ThisoApp.Services.APIDataType
{
    public class IThisoWebCustomerProfileData
    {
        public IThisoWebCustomerProfileData()
        {

        }
        public string MemID { get; set; }

        public string FullName { get; set; }

        public int DistrictID { get; set; }

        public int ProvinceID { get; set; }

        public string ShortAddress { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public short? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string IDNo { get; set; }
    }
}
