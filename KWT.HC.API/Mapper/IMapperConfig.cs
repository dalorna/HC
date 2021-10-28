using AutoMapper;
using KWT.HC.API.Entity;
using KWT.HC.API.Model;

namespace KWT.HC.API.Mapper
{
    public class IMapperConfig : Profile
    {
        public IMapperConfig()
        {
            CreateMap<HC_UserModel, HC_User>();
            CreateMap<HC_User, HC_UserModel>();
            CreateMap<TurbineModel, Turbine>()
                .ForMember(dest => dest.LoadIncrements, opt =>
                {
                    opt.PreCondition(src => src.Type == "Gas");
                    opt.MapFrom(src => src.LoadIncrements);
                });
            CreateMap<Turbine, TurbineModel>();
            CreateMap<TurbineLoadModel, TurbineLoad>();
            CreateMap<TurbineLoad, TurbineLoadModel>();
            CreateMap<Schedule, ScheduleModel>();
            CreateMap<ScheduleModel, Schedule>();
            CreateMap<ScheduleTurbineModel, ScheduleTurbine>();
            CreateMap<ScheduleTurbine, ScheduleTurbineModel>();
            CreateMap<ScheduleDayModel, ScheduleDay>();
            CreateMap<ScheduleDay, ScheduleDayModel>();
            CreateMap<TurbineTimeModel, TurbineTime>();
            CreateMap<TurbineTime, TurbineTimeModel>();
            CreateMap<GraphOptionModel, GraphOption>();
            CreateMap<GraphOption, GraphOptionModel>();
            CreateMap<ActivityNoteModel, ActivityNote>();
            CreateMap<ActivityNote, ActivityNoteModel>();
            CreateMap<LogoModel, Logo>();
            CreateMap<Logo, LogoModel>();
        }
    }
}
