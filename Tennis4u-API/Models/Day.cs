namespace Tennis4u_API.Models
{
    public class Day
    {
        public Day()
        {
            WorkDays = new HashSet<WorkDay>();
        }
        public int IdDay { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkDay> WorkDays { get; set; }
    }
}
