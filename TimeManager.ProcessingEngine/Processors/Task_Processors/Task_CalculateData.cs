using AutoMapper;
using LanguageExt.Common;
using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Processors.TaskProcessors
{
    public class Task_CalculateData : Processor, ITask_CalculateData
    {
        public Task_CalculateData(DataContext context, ILogger<Processor> logger, IMapper mapper) : base(context, logger, mapper) { }

        private double CalculateEfficiency(TimeSpan? delay, TimeSpan? executionTime, int Priority)
        {
            TimeSpan delayValue = delay.Value;
            double delayCount = delayValue.Hours * Priority + delayValue.Minutes * (Priority * 0.1) + delayValue.Seconds  * (Priority * 0.01);

            TimeSpan executionValue = executionTime.Value;
            double executionCount = executionValue.Hours * Priority + executionValue.Minutes * (Priority * 0.1) + executionValue.Seconds * (Priority * 0.01);

            return (delayCount + executionCount / 100);
        }
        public Result<ITaskRecords> Execute(int taskSetRecordId)
        {
            var taskRecord = _context.TaskRecords.FirstOrDefault(x => x.Id == taskSetRecordId);
            if (taskRecord == null) return new Result<ITaskRecords>(new NullReferenceException());

            if(taskRecord.EndDate != null)
            {
                taskRecord.ExecutionTime = taskRecord.EndDate - taskRecord.StartDate;

                if(taskRecord.Deadline.CompareTo(taskRecord.EndDate) < 0)
                {
                    taskRecord.Delay = taskRecord.EndDate - taskRecord.Deadline;
                }

                taskRecord.Efficiency = CalculateEfficiency(taskRecord.Delay, taskRecord.ExecutionTime, taskRecord.Priority);
                _context.SaveChanges();
            }

            return new Result<ITaskRecords>(taskRecord);
        }

    }
}
