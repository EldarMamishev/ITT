using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface ITeacherMapper
    {
        ShowTeachersAdminView MapTeacherModelsToViewModels(List<Teacher> teachers);
        void MapAllFacultiesToViewModel(List<Faculty> faculties, RegisterNewTeacherUserDataAccountView viewModel);
        void MapAllCathedrasToViewModel(List<Cathedra> cathedras, RegisterNewTeacherUserDataAccountView viewModel);
        void MapAllSubjectsToViewModel(List<Subject> subjects, RegisterNewTeacherUserDataAccountView viewModel);
        EditTeacherDataAccountView MapEditTeacherModelsToEditViewModels(Teacher teacher, List<Faculty> faculties, List<Cathedra> cathedras, List<Subject> subjects);
    }
}