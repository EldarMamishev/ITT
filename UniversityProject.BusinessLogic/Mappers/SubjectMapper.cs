using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.BusinessLogic.Mappers.Interfaces;
using UniversityProject.Entities.Entities;
using UniversityProject.ViewModels.AdminViewModels.SubjectsViewModels;

namespace UniversityProject.BusinessLogic.Mappers
{
    public class SubjectMapper : ISubjectMapper
    {
        public ShowSubjectsAdminView MapAllSubjectsToViewModel(List<Subject> subjects)
        {
            var viewModel = new ShowSubjectsAdminView();

            foreach (Subject subject in subjects)
            {
                var viewModelItem = new ShowSubjectsAdminViewItem();

                viewModelItem.Id = subject.Id;
                viewModelItem.Name = subject.Name;

                viewModel.Subjects.Add(viewModelItem);
            }

            return viewModel;
        }
    }
}