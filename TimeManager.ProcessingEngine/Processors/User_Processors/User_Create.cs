using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Data.DTO;

namespace TimeManager.ProcessingEngine.Processors.UserProcessors
{
    public class User_Create : Processor, IUser_Create
    {
        public User_Create(DataContext context, ILogger<Processor> logger) : base(context, logger) { }
        public Result<bool> Execute(string body)
        {
            try
            {
                UserDTO userRecods = JsonConvert.DeserializeObject<UserDTO>(body);

                var userRecords = new UserRecords()
                {
                    UserId = userRecods.Id,
                    UserName = userRecods.UserName
                };

                _context.UserRecords.Add(userRecords);
                _context.SaveChanges();
                
                _logger.LogInformation("User successfully created");
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error has occured: {ex}");
                return new Result<bool>(ex);
            }
        }
    }
}
