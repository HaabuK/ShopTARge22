namespace ShopTARge22.Models.Spaceships
{
    public class ImageViewModel
    {
        public Guid ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public string FilePath { get; set; }
        public Guid SpaceshipId { get; set; }
    }
}
