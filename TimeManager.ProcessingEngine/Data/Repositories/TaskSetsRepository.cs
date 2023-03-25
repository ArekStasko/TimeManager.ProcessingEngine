using Microsoft.EntityFrameworkCore;
using TimeManager.ProcessingEngine.Data.Repositories.Interfaces;

namespace TimeManager.ProcessingEngine.Data.Repositories;

public class TaskSetsRepositories : ITasksSetsRepository
{
    private readonly DataContext _context;
    private readonly ILogger<ITasksSetsRepository> _logger;

    public TaskSetsRepositories(DataContext context, ILogger<ITasksSetsRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public void Update(TaskSetRecords record)
    {
        try
        {
            _context.TaskSetRecords.Attach(record);
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in TaskSetsRepository Update method");
            _logger.LogError(e.Message);
        }
    }

    public async Task Post(TaskSetRecords record)
    {
        try
        {
            await _context.TaskSetRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in TaskSetsRepository Post method");
            _logger.LogError(e.Message);
        }
    }

    public async Task<TaskSetRecords> Get(int id)
    {
        try
        {
            var record = await _context.TaskSetRecords.SingleAsync(t => t.Id == id);
            await _context.SaveChangesAsync();
            return record;
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in TaskSetsRepository Get method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var record = await _context.TaskSetRecords.SingleAsync(t => t.Id == id);
            _context.TaskSetRecords.Remove(record);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in TaskSetsRepository Delete method");
            throw;
        }
    }
}