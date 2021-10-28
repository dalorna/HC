using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using KWT.HC.API.Accessor;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Entity;
using KWT.HC.API.Manager;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KWT.HC.API.ComponentRegistration
{
    public static class ComponentRegistration
    {
        public static void RegisterComponents(IServiceCollection services)
        {
            services.AddTransient<IRepository<HC_User, Guid>, StandardRepository<HC_User, Guid>>();
            services.AddTransient<IMapper<HC_UserModel, HC_User, Guid>, StandardMapper<HC_UserModel, HC_User, Guid>>();            
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IUserManager, UserManager>();

            services.AddTransient<IRepository<Turbine, int>, StandardRepository<Turbine, int>>();
            services.AddTransient<IMapper<TurbineModel, Turbine, int>, StandardMapper<TurbineModel, Turbine, int>>();
            services.AddTransient<ITurbineAccessor, TurbineAccessor>();
            services.AddTransient<ITurbineManager, TurbineManager>();

            services.AddTransient<IRepository<TurbineLoad, int>, StandardRepository<TurbineLoad, int>>();
            services.AddTransient<IMapper<TurbineLoadModel, TurbineLoad, int>, StandardMapper<TurbineLoadModel, TurbineLoad, int>>();
            services.AddTransient<ITurbineLoadAccessor, TurbineLoadAccessor>();
            services.AddTransient<ITurbineLoadManager, TurbineLoadManager>();

            services.AddTransient<IRepository<Schedule, int>, StandardRepository<Schedule, int>>();
            services.AddTransient<IMapper<ScheduleModel, Schedule, int>, StandardMapper<ScheduleModel, Schedule, int>>();
            services.AddTransient<IMapper<ScheduleTurbineModel, ScheduleTurbine, int>, StandardMapper<ScheduleTurbineModel, ScheduleTurbine, int>>();
            services.AddTransient<IMapper<ScheduleDayModel, ScheduleDay, int>, StandardMapper<ScheduleDayModel, ScheduleDay, int>>();
            services.AddTransient<IMapper<TurbineTimeModel, TurbineTime, int>, StandardMapper<TurbineTimeModel, TurbineTime, int>>();
            services.AddTransient<IScheduleAccessor, ScheduleAccessor>();
            services.AddTransient<IScheduleManager, ScheduleManager>();

            services.AddTransient<IRepository<GraphOption, int>, StandardRepository<GraphOption, int>>();
            services.AddTransient<IMapper<GraphOptionModel, GraphOption, int>, StandardMapper<GraphOptionModel, GraphOption, int>>();
            services.AddTransient<IGraphOptionAccessor, GraphOptionAccessor>();
            services.AddTransient<IGraphOptionManager, GraphOptionManager>();

            services.AddTransient<IRepository<ActivityNote, int>, StandardRepository<ActivityNote, int>>();
            services.AddTransient<IMapper<ActivityNoteModel, ActivityNote, int>, StandardMapper<ActivityNoteModel, ActivityNote, int>>();
            services.AddTransient<IActivityNoteAccessor, ActivityNoteAccessor>();
            services.AddTransient<IActivityNoteManager, ActivityNoteManager>();

            services.AddTransient<IRepository<Logo, int>, StandardRepository<Logo, int>>();
            services.AddTransient<IMapper<LogoModel, Logo, int>, StandardMapper<LogoModel, Logo, int>>();
            services.AddTransient<ILogoAccessor, LogoAccessor>();
            services.AddTransient<ILogoManager, LogoManager>();
        }
    }
}
