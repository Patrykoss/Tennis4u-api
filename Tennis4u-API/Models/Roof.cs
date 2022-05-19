namespace Tennis4u_API.Models
{
    public class Roof
    {
        public Roof()
        {
            TennisCourts = new HashSet<TennisCourt>();
        }
        public int IdRoof { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TennisCourt> TennisCourts { get; set; }
    }
}
