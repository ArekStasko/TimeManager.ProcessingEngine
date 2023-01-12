using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors
{
    public class User_Create : Processor, IUser_Create
    {
        public User_Create(DataContext context, ILogger<Processor> logger) : base(context, logger) { }
        public Result<bool> Execute(string body)
        {
            return new Result<bool>(false);
        }
    }
}
