using queue_management_core.Entities;

namespace queue_management_core.DTOs
{
    public class DoctorDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PassportId { get; set; }
        public Gender Gender { get; set; }
        public JobTitle JobTitle { get; set; }

        public static implicit operator DoctorDTO(Doctor other) =>
        new()
        {
            Id = other.Id,
            Name = other.Name,
            MiddleName = other.MiddleName,
            Surname = other.Surname,
            PassportId = other.PassportId,
            Gender = other.Gender,
            JobTitle = other.JobTitle
        };
    }
}
