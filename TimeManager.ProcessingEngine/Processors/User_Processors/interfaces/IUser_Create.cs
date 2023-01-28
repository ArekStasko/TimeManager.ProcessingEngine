using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.UserProcessors
{
    public interface IUser_Create
    {
        public Result<bool> Execute(string body);
    }
}
