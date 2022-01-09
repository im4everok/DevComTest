namespace DAL.Entities
{
    public class Pet : BaseEntity
    { 
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual Person Person { get; set; }
    }
}
