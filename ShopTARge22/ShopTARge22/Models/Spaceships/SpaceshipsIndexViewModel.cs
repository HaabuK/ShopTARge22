namespace ShopTARge22.Models.Spaceships
{
	public class SpaceshipsIndexViewModel
	{
		public Guid? Id { get; set; }

		public String Name { get; set; }

        public String Type { get; set; }

        public int Passengers { get; set; }

        public DateTime BuiltDate { get; set; }
    }
}

