namespace Tennis4u_API.Models
{
    public class Surface
    {
        public Surface()
        {
            TennisCourts = new HashSet<TennisCourt>();
        }
        public int IdSurface { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TennisCourt> TennisCourts { get; set; }
    }
}
