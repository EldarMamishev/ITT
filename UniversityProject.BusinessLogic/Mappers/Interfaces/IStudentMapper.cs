using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.StudentViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface IStudentMapper
    {
        ShowStudentsAdminView MapStudentModelsToViewModels(List<Student> teachers);
        EditStudentDataAccountView MapEditStudentModelsToEditViewModels(Student teacher);
    }
}
