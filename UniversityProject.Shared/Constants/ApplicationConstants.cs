namespace UniversityProject.Shared.Constants
{
    public class ApplicationConstants
    {
        public static string LOCALHOST_CONNECTION_STRING_NAME = "Localhost";

        public static string APPLICATION_COOKIE_NAME = "UniversityProjectCookie";

        public static string ADMIN_ROLE = "Admin";
        public static string USER_ROLE = "User";
        public static string TEACHER_ROLE = "Teacher";

        public const string CONFIRMATION_EMAIL_SUBJECT = "confirm email address";
        public const string PATH_TO_CONFIRMATION_EMAIL_TEMPLATE = "\\UniversityProject.BusinessLogic\\Templates\\ConfirmationEmailTemplate.html";
        public const string FORGET_PASSWORD_EMAIL_SUBJECT = "forget password";
        public const string PATH_TO_FORGET_PASSWORD_EMAIL_TEMPLATE = "\\UniversityProject.BusinessLogic\\Templates\\ForgetPasswordEmailTemplate.html";
    }
}