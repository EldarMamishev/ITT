using System.Collections.Generic;
using System.Linq;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class TeacherMapper : ITeacherMapper
    {
        public ShowTeachersAdminView MapTeacherModelsToViewModels(List<Teacher> model)
        {
            var viewModel = new ShowTeachersAdminView();

            foreach (Teacher teacher in model)
            {
                var viewModelItem = new TeacherShowTeachersAdminViewItem();
                viewModelItem.Id = teacher.Id;
                viewModelItem.FullName = $"{teacher.LastName} {teacher.FirstName} {teacher.MiddleName}";
                viewModelItem.ChairName = teacher.Chair.Name;

                var subjectNames = string.Empty;
                var teacherSubjects = teacher.TeacherSubjects.ToList();
                var countItems = teacherSubjects.Count;

                for (int i = 0; i < countItems; i++)
                {
                    subjectNames += $"{teacherSubjects[i].Subject.Name}";

                    if (i + 1 < countItems)
                    {
                        subjectNames += ", ";
                    }
                }

                viewModelItem.SubjectName = subjectNames;

                viewModel.Teachers.Add(viewModelItem);
            }

            return viewModel;
        }

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