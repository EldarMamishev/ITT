using System.Collections.Generic;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.GroupViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class GroupMapper : IGroupMapper
    {
        public ShowGroupsAdminView MapAllGroupsToViewModel(List<Group> groups)
        {
            var viewModel = new ShowGroupsAdminView();

            foreach (Group group in groups)
            {
                var viewModelItem = new ShowGroupsAdminViewItem();

                viewModelItem.Id = group.Id;
                viewModelItem.Cipher = group.Cipher;
                viewModelItem.FacultyName = group.Chair.Faculty.Name;
                viewModelItem.ChairName = group.Chair.Name;
                viewModelItem.CountOfStudents = group.Students.Count;

                viewModel.Groups.Add(viewModelItem);
            }

            return viewModel;
        }
    }
}
