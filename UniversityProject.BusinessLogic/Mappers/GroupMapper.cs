using System;
using System.Collections.Generic;
using System.Linq;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.Entities.Enums;
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

        public EditGroupDataAdminView MapToEditGroupDataModel(Group group, List<Chair> chairs)
        {
            var viewModel = new EditGroupDataAdminView();

            viewModel.Id = group.Id;
            viewModel.CreationYear = group.CreationYear.ToString("yyyy");
            viewModel.GroupNumber = group.GroupNumber;
            viewModel.CourseNumberType = (int)group.CourseNumberType;
            viewModel.PrevoiusCipher = group.Cipher;

            viewModel.CourseNumberTypes = Enum.GetValues(typeof(CourseNumberType))
                .Cast<int>()
                .Where(item => !item.Equals(0))
                .ToList();

            viewModel.ChairId = group.Chair.Id;
            foreach (Chair chair in chairs)
            {
                var viewModelItem = new EditGroupDataAdminViewItem();

                viewModelItem.Id = chair.Id;
                viewModelItem.ChairName = chair.Name;

                viewModel.Chairs.Add(viewModelItem);
            }

            return viewModel;
        }
    }
}
