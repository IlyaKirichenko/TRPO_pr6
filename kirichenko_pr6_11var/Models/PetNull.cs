namespace kirichenko_pr6_11var.Models
{
    public partial class PetNull 
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Species { get; set; }

        public int? Age { get; set; }

        public decimal? Weight { get; set; }

        public bool? IsAdopted { get; set; }
    }
}
