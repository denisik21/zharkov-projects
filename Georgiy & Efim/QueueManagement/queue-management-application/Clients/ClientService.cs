namespace queue_management_application.Clients;
public class ClientService(IRepository<Client> repository) : IServise
{
    private IRepository<Client> Repository { get; init; } = repository;

    public async Task<IEnumerable<ClientDTO>> GetClientsAsync(CancellationToken cancellationToken = default) =>
        (await Repository.Get(cancellationToken)).Select(x => (ClientDTO)x);

    public async Task RegisterOrUpdateClientsAsync(IEnumerable<ClientDTO> clients, CancellationToken cancellationToken = default)
    {
        var newClients = from other in clients
                         where other.Id is null
                         select new Client()
                         {
                             Name = other.Name,
                             MiddleName = other.MiddleName,
                             Surname = other.Surname,
                             PassportId = other.PassportId,
                             Birthday = other.Birthday,
                             Gender = other.Gender,
                             InRoom = other.InRoom
                         };

        var repo = await Repository.Get(cancellationToken);
        var newOldClient = from client in (from client in clients where client.Id is not null select client)
                           join repClient in repo on client.Id equals repClient.Id
                           select (client, repClient);

        foreach (var (updatedClient, oldClient) in newOldClient)
        {
            oldClient.Name = updatedClient.Name;
            oldClient.MiddleName = updatedClient.MiddleName;
            oldClient.Surname = updatedClient.Surname;
        }

        // todo: validation object
        await Repository.AddRange(newClients, cancellationToken);
        await Repository.UpdateRange(repo, cancellationToken);
    }
}
