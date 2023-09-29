﻿namespace ShopTARge22.Models.RealEstates
{
    public class RealEstateImageViewModel
    {
        public Guid ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? RealEstateId { get; set; }
    }
}
