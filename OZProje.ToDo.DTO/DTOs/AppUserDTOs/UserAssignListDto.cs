using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DTO.DTOs.AppUserDTOs
{
    public class UserAssignListDto
    {
        public AppUserListDto AppUser { get; set; }
        public TaskListDto Task { get; set; }
    }
}
