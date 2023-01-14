using Grpc.Core;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Services.container;

namespace TimeManager.ProcessingEngine.Protos
{
    public class GreeterService : Greeter.GreeterBase
    {
        private IProcessors _processors;
        public GreeterService(IProcessors processors) => _processors = processors;  

        public override async Task StreamTaskStats(TaskRequest request, IServerStreamWriter<TaskStats> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var result = _processors.task_CalculateData.Execute(request.TaskRecordId);
                var taskRecordStats = new TaskStats();
                bool succ = result.Match<bool>(taskRecord =>
                {

                    taskRecordStats.StartDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(taskRecord.StartDate);
                    taskRecordStats.EndDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(taskRecord.EndDate);
                    taskRecordStats.Deadline = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(taskRecord.Deadline);
                    taskRecordStats.Priority = taskRecord.Priority;
                    taskRecordStats.Efficiency = taskRecord.Efficiency;
                    taskRecordStats.ExecutionTime = Google.Protobuf.WellKnownTypes.Duration.FromTimeSpan(taskRecord.ExecutionTime);

                        return true;
                }, exception =>
                {
                    return false;
                });
                
            
                await responseStream.WriteAsync(taskRecordStats);
            }
        }
    }
}
