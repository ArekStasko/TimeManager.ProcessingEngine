﻿using Autofac;
using AutoMapper;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Processors;
using TimeManager.ProcessingEngine.Processors.TaskProcessors;
using TimeManager.ProcessingEngine.Processors.TaskSetProcessors;
using TimeManager.ProcessingEngine.Processors.UserProcessors;


namespace TimeManager.ProcessingEngine.Services.container
{
    public class Processors : IProcessors
    {
        public Processors(DataContext context, ILogger<Processor> logger, IMapper mapper) => _container  = ContainerConfig.CreateProcessorsContainer(context, logger, mapper);

        private IContainer _container { get; } 

        public ITask_Delete task_Delete { get => _container.Resolve<ITask_Delete>(); }
        public ITask_Post task_Post { get => _container.Resolve<ITask_Post>(); }
        public ITask_Update task_Update { get => _container.Resolve<ITask_Update>(); }
        public ITask_CalculateData task_CalculateData { get => _container.Resolve<ITask_CalculateData>(); }
        public ITask_Get task_Get { get => _container.Resolve<ITask_Get>(); }

        public ITaskSet_Delete taskSet_Delete { get => _container.Resolve<ITaskSet_Delete>(); }
        public ITaskSet_Post taskSet_Post { get => _container.Resolve<ITaskSet_Post>(); }
        public ITaskSet_Update taskSet_Update { get => _container.Resolve<ITaskSet_Update>(); }
        public ITaskSet_CalculateData taskSet_CalculateData { get => _container.Resolve<ITaskSet_CalculateData>(); }
        public ITaskSet_Get taskSet_Get { get => _container.Resolve<ITaskSet_Get>(); }

        public IUser_Create user_Create { get => _container.Resolve<IUser_Create>(); }
        public IUser_GetStats user_GetStats { get => _container.Resolve<IUser_GetStats>(); }
    }
}
