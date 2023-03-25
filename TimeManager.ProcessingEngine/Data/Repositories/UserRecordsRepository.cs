using Microsoft.EntityFrameworkCore;
using TimeManager.ProcessingEngine.Data.Repositories.Interfaces;

namespace TimeManager.ProcessingEngine.Data.Repositories;

public class UserRecordsRepository : IUserRecordsRepository
{
    private readonly DataContext _context;
    private readonly ILogger<IUserRecordsRepository> _logger;

    public UserRecordsRepository(DataContext context, ILogger<IUserRecordsRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void Update(UserRecords user)
    {
        try
        {
            _context.UserRecords.Attach(user);
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in UserRecordsRepository in Update method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task Post(UserRecords user)
    {
        try
        {
            await _context.UserRecords.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in UserRecordsRepository in Post method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var user = await _context.UserRecords.SingleAsync(u => u.Id == id);
            _context.UserRecords.Remove(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in UserRecordsRepository in Delete method");
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<UserRecords> Get(int id)
    {
        try
        {
            var user = await _context.UserRecords.SingleAsync(u => u.Id == id);
            return user;
        }
        catch (Exception e)
        {
            _logger.LogError("Error has occured in UserRecordsRepository in Update method");
            _logger.LogError(e.Message);
            throw;
        }
    }
}