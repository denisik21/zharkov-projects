using queue_management_core.Entities;

namespace queue_management_core.DTOs
{
    public class ClientDTO 
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PassportId { get; set; }
        public DateTime Birthday { get; set; }
        public string Snils { get; set; }
        public bool InRoom { get; set; }
        public Gender Gender { get; set; }

        public static implicit operator ClientDTO(Client other) =>
        new()
        {
            Id = other.Id,
            Name = other.Name,
            MiddleName = other.MiddleName,
            Surname = other.Surname,
            PassportId = other.PassportId,
            Birthday = other.Birthday,
            Gender = other.Gender,
            InRoom = other.InRoom
        };
    }
}
