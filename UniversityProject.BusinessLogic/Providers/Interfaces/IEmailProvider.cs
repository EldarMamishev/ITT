using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityProject.BusinessLogic.Providers.Interfaces
{
    public interface IEmailProvider
    {
        Task SendMessage(IEnumerable<string> recipientEmailList, string subject, string message);
        Task SendMessage(string recipientEmail, string subject, string message);
    }
}