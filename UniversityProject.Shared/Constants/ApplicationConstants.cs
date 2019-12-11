namespace UniversityProject.Shared.Constants
{
    public class ApplicationConstants
    {
        public const string LOCALHOST_CONNECTION_STRING_NAME = "Localhost";

        public const string APPLICATION_COOKIE_NAME = "UniversityProjectCookie";

        public const string ADMIN_ROLE = "Admin";
        public const string USER_ROLE = "User";
        public const string TEACHER_ROLE = "Teacher";
        public const string LOCAL_ADMIN_ROLE = "LocalAdmin";

        public const string CONFIRMATION_EMAIL_SUBJECT = "confirm email address";
        public const string PATH_TO_CONFIRMATION_EMAIL_TEMPLATE = "\\wwwroot\\emailTemplates\\ConfirmationEmailTemplate.html";
        public const string FORGET_PASSWORD_EMAIL_SUBJECT = "forget password";
        public const string PATH_TO_FORGET_PASSWORD_EMAIL_TEMPLATE = "\\wwwroot\\emailTemplates\\ForgetPasswordEmailTemplate.html";

        // TODO: change.
        public static int CurrentCompanyId = 1;
    }
}