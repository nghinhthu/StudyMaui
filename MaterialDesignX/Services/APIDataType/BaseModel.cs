namespace MaterialDesignX.Services.APIDataType
{
    public class BaseModel
    {
        public BaseModel()
        {

        }
        public string MemID { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string IDNo { get; set; }
        public short Gender { get; set; }
        public DateTime DOB { get; set; }
        public string CityID { get; set; }
        public string DistrictID { get; set; }
        public string ShortAddress { get; set; }
    }
}
