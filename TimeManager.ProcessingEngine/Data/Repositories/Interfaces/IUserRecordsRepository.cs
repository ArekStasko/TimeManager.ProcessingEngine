namespace TimeManager.ProcessingEngine.Data.Repositories.Interfaces;

public interface IUserRecordsRepository
{
    void Update(UserRecords user);
    Task Post(UserRecords user);
    Task Delete(int id);
    Task<UserRecords> Get(int id);
}