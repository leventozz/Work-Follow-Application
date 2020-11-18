using AutoMapper;
using OZProje.ToDo.DTO.DTOs.AppUserDTOs;
using OZProje.ToDo.DTO.DTOs.NotificationDTOs;
using OZProje.ToDo.DTO.DTOs.PriorityDTOs;
using OZProje.ToDo.DTO.DTOs.ReportDTOs;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region PriortyMapping
            CreateMap<PriorityAddDto, Priority>();
            CreateMap<Priority, PriorityAddDto>();
            CreateMap<PriorityListDto, Priority>();
            CreateMap<Priority, PriorityListDto>();
            CreateMap<PriorityUpdateDto, Priority>();
            CreateMap<Priority, PriorityUpdateDto>();
            #endregion

            #region AppUserMapping
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region NotificationMapping
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region TaskMapping
            CreateMap<TaskAddDto, Task>();
            CreateMap<Task, TaskAddDto>();
            CreateMap<TaskListDto, Task>();
            CreateMap<Task, TaskListDto>();
            CreateMap<TaskUpdateDto, Task>();
            CreateMap<Task, TaskUpdateDto>();
            CreateMap<TaskListAllDto, Task>();
            CreateMap<Task,TaskListAllDto>();
            #endregion

            #region ReportMapping
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>(); 
            #endregion
        }
    }
}
