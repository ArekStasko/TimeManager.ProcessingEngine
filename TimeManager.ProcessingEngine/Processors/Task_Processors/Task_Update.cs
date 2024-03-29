﻿using AutoMapper;
using Newtonsoft.Json;
using TimeManager.ProcessingEngine.Data;
using LanguageExt.Common;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public class Task_Update : Processor, ITask_Update
    {

        public Task_Update(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) { }

        public Result<bool> Execute(string body)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(body);
                var record = _context.TaskRecords.Single(tsk => tsk.TaskId == taskDTO.Id);
                Console.WriteLine("Updating");
                record.StartDate = taskDTO.DateAdded;
                record.Deadline = taskDTO.Deadline;
                record.Priority = taskDTO.Priority;
                Console.WriteLine("Check completed");

                if (taskDTO.Completed)
                {
                    record.EndDate = taskDTO.DateCompleted;
                    record.Completed = taskDTO.Completed;
                    record.Efficiency = record.CalculateEfficiency();
                }

                Console.WriteLine($"RECORD : {record.Efficiency} - {record.Delay()} - {record.ExecutionTime()}");
                Console.WriteLine("Updating");

                _context.SaveChanges();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION: {ex}");
                return new Result<bool>(ex);
            }
        }
    }
}
