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
                viewModelItem.FacultyName = group.Cathedra.Faculty.Name;
                viewModelItem.CathedraName = group.Cathedra.Name;
                viewModelItem.CountOfStudents = group.Students.Count;

                viewModel.Groups.Add(viewModelItem);
            }

            return viewModel;
        }

        public EditGroupDataAdminView MapToEditGroupDataModel(Group group, List<Faculty> faculties, List<Cathedra> cathedras)
        {
            var viewModel = new EditGroupDataAdminView();

            viewModel.Id = group.Id;
            viewModel.CreationYear = group.CreationYear.ToString("yyyy");
            viewModel.GroupNumber = group.GroupNumber;
            viewModel.CourseNumberType = (int)group.CourseNumberType;
            viewModel.FacultyId = (int)group.Cathedra.FacultyId;

            viewModel.CourseNumberTypes = Enum.GetValues(typeof(CourseNumberType))
                .Cast<int>()
                .Where(item => !item.Equals(0))
                .ToList();

            foreach (Faculty faculty in faculties)
            {
                var facultyViewItem = new FacultyEditGroupDataAdminViewItem();

                facultyViewItem.Id = faculty.Id;
                facultyViewItem.FacultyName = faculty.Name;

                viewModel.Faculties.Add(facultyViewItem);
            }

            viewModel.CathedraId = group.Cathedra.Id;
            foreach (Cathedra cathedra in cathedras)
            {
                var viewModelItem = new CathedraEditGroupDataAdminViewItem();

                viewModelItem.Id = cathedra.Id;
                viewModelItem.CathedraName = cathedra.Name;

                viewModel.Cathedras.Add(viewModelItem);
            }

            return viewModel;
        }
    }
}
