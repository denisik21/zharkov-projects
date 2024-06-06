using queue_management_core.Entities;

namespace queue_management_core.DTOs
{
    public class RoomDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<Client> Client { get; set; }

        public static implicit operator RoomDTO(Room other) =>
        new()
        {
            Id = other.Id,
            Name = other.Name,
            Description = other.Description,
            Doctor = (List<Doctor>) other.Doctor,
            Client = (List<Client>) other.Clients
        };
    }
}
