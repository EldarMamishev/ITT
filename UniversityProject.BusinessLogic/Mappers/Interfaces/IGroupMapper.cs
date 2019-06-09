using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface IGroupMapper
    {
        ShowGroupsAdminView MapAllGroupsToViewModel(List<Group> groups);
        EditGroupDataAdminView MapToEditGroupDataModel(Group group, List<Faculty> faculties, List<Chair> chairs);
    }
}