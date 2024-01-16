namespace ThisoApp.Services.APIDataType
{
    public class CustomerProfile
    {
        public CustomerProfile()
        {

        }
        public string MemID { get; set; }
        public string FullName { get; set; }
        public int DistrictID { get; set; }
        public int ProvinceID { get; set; }
        public string ShortAddress { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime Dob { get; set; }
        public string IdNo { get; set; }
    }
}
