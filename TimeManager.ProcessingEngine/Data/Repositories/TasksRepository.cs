using Microsoft.EntityFrameworkCore;
using TimeManager.ProcessingEngine.Data.Repositories.Interfaces;

namespace TimeManager.ProcessingEngine.Data.Repositories;

public class TasksRepositories : ITasksRepository
{
    private readonly DataContext _context;
    private readonly ILogger<TasksRepositories> _logger;

    public TasksRepositories(DataContext context, ILogger<TasksRepositories> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Delete(int id)
    {
        try
        {
            var record = await _context.TaskRecords.SingleAsync(t => t.Id == id);
            _context.TaskRecords.Remove(record);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error occured in TasksRepository delete method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<TaskRecords> Get(int id)
    {
        try
        {
            var record = await _context.TaskRecords.SingleAsync(t => t.Id == id);
            return record;
        }
        catch (Exception e)
        {
            _logger.LogError("Exception has occured in TasksRepository get method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task Post(TaskRecords record)
    {
        try
        {
            await _context.TaskRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in TasksRepository Post method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public void Update(TaskRecords record)
    {
        try
        {
            _context.TaskRecords.Attach(record);
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in TasksRepository Update method");
            _logger.LogError(e.Message);
            throw;
        }
    }
}