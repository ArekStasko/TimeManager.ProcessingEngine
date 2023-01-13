﻿using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public interface ITask_CalculateData
    {
        public Result<bool> Execute(int taskRecordId);
    }
}
