namespace ShopTARge22.Models.RealEstates
{
    public class RealEstatesIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string BuildingType { get; set; }
        public DateTime BuiltInYear { get; set; }
        public float SizeSqrM { get; set; }
    }
}
