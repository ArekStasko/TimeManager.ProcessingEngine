﻿using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors
{
    public class Task_Post : Processor, ITask_Post
    {
        public Task_Post(DataContext context, ILogger<Processor> logger) : base(context, logger) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(body);

                TaskRecord taskRecord = new TaskRecord()
                {
                    TaskId = taskDTO.Id,
                    UserId = taskDTO.UserId,
                    StartDate = taskDTO.DateAdded
                };
                _context.TaskRecords.Add(taskRecord);
                _context.SaveChanges();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Result<bool>(ex);
            }
        }
    }
}
