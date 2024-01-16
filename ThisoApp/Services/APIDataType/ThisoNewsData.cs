namespace ThisoApp.Services.APIDataType
{
    public class ThisoNewsData
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string CatNumber { get; set; }
        public string Subject { get; set; }
        public string UrlAlias { get; set; }
        public string NewsContent { get; set; }
        public string Description { get; set; }

        public string EnSubject { get; set; }

        public string EnNewsContent { get; set; }

        public string EnDescription { get; set; }

        public string Tag { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string ApprovedBy { get; set; }
        public int? Approved { get; set; }
        public int? FloorId { get; set; }
        public string ApprovalNotes { get; set; }
        public string FloorName { get; set; }

        public string FloorName_EN { get; set; }

        public string FloorNumber { get; set; }

        public string Lot { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string OpenTime { get; set; }

        public string CloseTime { get; set; }

        public string Tel { get; set; }

        public string Website { get; set; }

        public int? Priority { get; set; }

        public int? ScopeId { get; set; }

        public bool? FangePage { get; set; }

        public string FangePageId { get; set; }

        public bool? IsShared { get; set; }

        public bool? IsComment { get; set; }

        public bool? IsLike { get; set; }

        public string Notes { get; set; }

        public bool? MobileApp { get; set; }

        public bool? IsMemberNews { get; set; }

        public string OutletName_EN { get; set; }

        public int? BrandId { get; set; }

        public bool? IsEventSchedule { get; set; }

        public string BrandList { get; set; }

        public int? OutletId { get; set; }

        public string OutletName { get; set; }

        public string FloorPosition { get; set; }

        public string TypeNumber { get; set; }

        public string ShareContent { get; set; }

        public string ShareLink { get; set; }

        public string RefLink { get; set; }

        public string Smscontent { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Images { get; set; }
        public string Videos { get; set; }
        public bool? ShowHome { get; set; }
        public bool? ShowBanner { get; set; }
        public string LangCode { get; set; }
        public int? BusinessCatID { get; set; }
        public List<string> ImageURLs { get; set; }
        public List<ThisoNewsData> RelatedNewsData { get; set; }
        public string ThumbImage { get; set; }
        public string DetailImage { get; set; }
        public string Link { get; set; }
        public List<string> VideosURLs { get; set; }
        public string LinkVideo { get; set; }
        public bool? IsDeleted { get; set; }
        public string VideoURL { get; set; }
        public bool? DelStatus { get; set; }
        public string URL { get; set; }
        public DateTime PublishDate { get; set; }

        public ThisoNewsData()
        {
            RelatedNewsData = new List<ThisoNewsData>();
        }
    }
}
