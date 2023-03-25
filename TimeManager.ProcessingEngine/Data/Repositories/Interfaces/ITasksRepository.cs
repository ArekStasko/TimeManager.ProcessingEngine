namespace TimeManager.ProcessingEngine.Data.Repositories.Interfaces;

public interface ITasksRepository
{
    Task Delete(int id);
    Task<TaskRecords> Get(int id);
    Task Post(TaskRecords record);
    void Update(TaskRecords record);
}