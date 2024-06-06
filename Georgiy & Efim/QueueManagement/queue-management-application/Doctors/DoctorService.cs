namespace queue_management_application.Doctors;

public class DoctorService(IRepository<Doctor> repository) : IServise
{
    private IRepository<Doctor> Repository { get; init; } = repository;

    public async Task<IEnumerable<DoctorDTO>> GetDoctorAsync(CancellationToken cancellationToken = default) =>
        (await Repository.Get(cancellationToken)).Select(x => (DoctorDTO)x);

    public async Task RegisterOrUpdateDoctorAsync(IEnumerable<DoctorDTO> doctors, CancellationToken cancellationToken = default)
    {
        var newDoctor = from other in doctors
                         where other.Id is null
                         select new Doctor()
                         {
                             Name = other.Name,
                             MiddleName = other.MiddleName,
                             Surname = other.Surname,
                             PassportId = other.PassportId,
                             //Birthday = other.Birthday,
                             Gender = other.Gender,
                             JobTitle = other.JobTitle
                         };

        var repo = await Repository.Get(cancellationToken);
        var newOldDoctor = from doctor in (from doctor in doctors where doctor.Id is not null select doctor)
                                  join repDoc in repo on doctor.Id equals repDoc.Id
                                  select (doctor, repDoc);

        foreach (var (updatedDoctor, oldDoctor) in newOldDoctor)
        {
            oldDoctor.Name = updatedDoctor.Name;
            oldDoctor.MiddleName = updatedDoctor.MiddleName;
            oldDoctor.Surname = updatedDoctor.Surname;
            oldDoctor.PassportId = updatedDoctor.PassportId;
            //oldDoctor.Birthday = updatedDoctor.Birthday;
            oldDoctor.Gender = updatedDoctor.Gender;
            oldDoctor.JobTitle = updatedDoctor.JobTitle;
        }

        // todo: validation object
        await Repository.AddRange(newDoctor, cancellationToken);
        await Repository.UpdateRange(repo, cancellationToken);
    }
}
