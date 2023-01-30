using TimeManager.ProcessingEngine.Data;

namespace TimeManager.ProcessingEngine.Services.Calculations;

public class CalculateData
{
    public static double Efficiency(double efficiency, TimeSpan? delay, TimeSpan? executionTime, int Priority)
    {
        TimeSpan delayValue = delay.Value;
        double delayCount = delayValue.Hours * Priority + delayValue.Minutes * (Priority * 0.1) + delayValue.Seconds  * (Priority * 0.01);

        TimeSpan executionValue = executionTime.Value;
        double executionCount = executionValue.Hours * Priority + executionValue.Minutes * (Priority * 0.1) + executionValue.Seconds * (Priority * 0.01);

        return efficiency - (delayCount + executionCount / 100);
    }

    public static TimeSpan Delay(ITaskRecords taskRecord) => taskRecord.EndDate - taskRecord.Deadline;
    
    public static TimeSpan ExecutionTime(ITaskRecords taskRecord) => taskRecord.EndDate - taskRecord.StartDate;
    
}