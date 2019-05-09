using System.Collections.Generic;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class TeacherMapper : ITeacherMapper
    {
        public void MapAllFacultiesToViewModel(List<Faculty> faculties, RegisterNewTeacherUserDataAccountView viewModel)
        {
            foreach (Faculty faculty in faculties)
            {
                var facultyViewItem = new FacultyRegisterNewTeacherUserDataAccountViewItem();

                facultyViewItem.Id = faculty.Id;
                facultyViewItem.Name = faculty.Name;

                viewModel.Faculties.Add(facultyViewItem);
            }
        }

        public void MapAllChairsToViewModel(List<Chair> chairs, RegisterNewTeacherUserDataAccountView viewModel)
        {
            foreach (Chair chair in chairs)
            {
                var chairViewItem = new ChairRegisterNewTeacherUserDataAccountViewItem();

                chairViewItem.Id = chair.Id;
                chairViewItem.Name = chair.Name;

                viewModel.Chairs.Add(chairViewItem);
            }
        }

        public void MapAllSubjectsToViewModel(List<Subject> subjects, RegisterNewTeacherUserDataAccountView viewModel)
        {
            foreach (Subject subject in subjects)
            {
                var subjectViewItem = new SubjectRegisterNewTeacherUserDataAccountViewItem();

                subjectViewItem.Id = subject.Id;
                subjectViewItem.Name = subject.Name;

                viewModel.Subjects.Add(subjectViewItem);
            }
        }
    }
}