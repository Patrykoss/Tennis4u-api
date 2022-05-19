namespace Tennis4u_API.Models
{
    public class Role
    {
        public Role()
        {
            Workers = new HashSet<Worker>();
        }
        public int IdRole { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
