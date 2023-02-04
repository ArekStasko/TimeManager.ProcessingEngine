using AutoMapper;
using TimeManager.ProcessingEngine.Data;
using TimeManager.ProcessingEngine.Data.DTO;

namespace TimeManager.ProcessingEngine.Services.Automapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<TaskDTO, TaskRecords>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.TaskId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.StartDate, opt => opt.MapFrom(src => src.DateAdded))
            .ForMember(x => x.EndDate, opt => opt.MapFrom(src => src.DateCompleted))
            .ForMember(x => x.Efficiency, opt => opt.Ignore())
            .ForSourceMember(x => x.Name, opt => opt.DoNotValidate())
            .ForSourceMember(x => x.Type, opt => opt.DoNotValidate())
            .ForSourceMember(x => x.Description, opt => opt.DoNotValidate());

        CreateMap<TaskSetDTO, TaskSetRecords>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.TaskSetId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.TaskId, opt => opt.MapFrom(src => src.TaskId));

        CreateMap<UserDTO, UserRecords>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Id, opt => opt.Ignore());
    }
}