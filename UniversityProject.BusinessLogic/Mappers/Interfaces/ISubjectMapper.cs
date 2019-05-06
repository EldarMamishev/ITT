using System.Collections.Generic;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;

namespace UniversityProject.BusinessLogic.Mappers.Interfaces
{
    public interface ISubjectMapper
    {
        ShowSubjectsAdminView MapAllSubjectsToViewModel(List<Subject> subjects);
    }
}