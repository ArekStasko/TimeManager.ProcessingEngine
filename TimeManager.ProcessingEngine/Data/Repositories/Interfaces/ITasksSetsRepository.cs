namespace TimeManager.ProcessingEngine.Data.Repositories.Interfaces;

public interface ITasksSetsRepository
{
    void Update(TaskSetRecords record);
    Task Post(TaskSetRecords record);
    Task<TaskSetRecords> Get(int id);
    Task Delete(int id);
}