namespace queue_management_core.Entities
{
    public class Doctor : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PassportId { get; set; }
        public Gender Gender { get; set; }
        public JobTitle JobTitle { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
