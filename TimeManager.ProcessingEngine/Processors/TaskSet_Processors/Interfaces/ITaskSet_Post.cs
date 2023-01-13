﻿using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskSetProcessors
{
    public interface ITaskSet_Post
    {
        public Result<bool> Execute(string body);
    }
}
