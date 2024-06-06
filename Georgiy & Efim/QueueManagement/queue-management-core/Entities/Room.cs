namespace queue_management_core.Entities
{
    public class Room : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }

    }
}
