namespace NiksDoughnuts.Web.Models
{
    public class Doughnut
    {
        public int Id { get; set; }
        public int? DoughnutsMade { get; set; } = 0;

        public DateTime CreatedAt { get; set; }

        public int CreatorId { get; set; }

        public Employee? Creator { get; set; }
    }
}
