namespace queue_management_application.Rooms;

public class DeviceService(IRepository<Room> repository) : IServise
{
    private IRepository<Room> Repository { get; init; } = repository;

    public async Task<IEnumerable<RoomDTO>> GetRoomAsync(CancellationToken cancellationToken = default) =>
        (await Repository.Get(cancellationToken)).Select(x => (RoomDTO)x);

    public async Task RegisterOrUpdateRoomsAsync(IEnumerable<RoomDTO> rooms, CancellationToken cancellationToken = default)
    {
        var newRooms = from other in rooms
                         where other.Id is null
                         select new Room()
                         {
                             Name = other.Name,
                             Description = other.Description,
                             Doctor = (List<Doctor>)other.Doctor,
                             Client = (List<Client>)other.Client
                         };

        var repo = await Repository.Get(cancellationToken);
        var newOldRooms = from room in (from room in rooms where room.Id is not null select room)
                                  join repRoom in repo on room.Id equals repRoom.Id
                                  select (room, repRoom);

        foreach (var (updatedRoom, oldRoom) in newOldRooms)
        {
           oldRoom.Name = updatedRoom.Name;
           oldRoom.Description = updatedRoom.Description;
           oldRoom.Doctor = updatedRoom.Doctor;
           oldRoom.Client = updatedRoom.Client;
        }

        // todo: validation object
        await Repository.AddRange(newRooms, cancellationToken);
        await Repository.UpdateRange(repo, cancellationToken);
    }
}
