using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.TeacherViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface ITeacherMapper
    {
        ShowTeachersAdminView MapTeacherModelsToViewModels(List<Teacher> teachers);
        void MapAllCathedrasToViewModel(List<Company> cathedras, RegisterNewTeacherUserDataAccountView viewModel);
        EditTeacherDataAccountView MapEditTeacherModelsToEditViewModels(Teacher teacher);
    }
}