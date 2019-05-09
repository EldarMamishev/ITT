using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface ITeacherMapper
    {
        void MapAllFacultiesToViewModel(List<Faculty> faculties, RegisterNewTeacherUserDataAccountView viewModel);
        void MapAllChairsToViewModel(List<Chair> chairs, RegisterNewTeacherUserDataAccountView viewModel);
        void MapAllSubjectsToViewModel(List<Subject> subjects, RegisterNewTeacherUserDataAccountView viewModel);
    }
}