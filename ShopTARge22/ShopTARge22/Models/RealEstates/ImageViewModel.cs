namespace ShopTARge22.Models.RealEstates
{
    public class ImageViewModel
    {
        public Guid ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public string FilePath { get; set; }
        public Guid RealEstateId { get; set; }
    }
}
