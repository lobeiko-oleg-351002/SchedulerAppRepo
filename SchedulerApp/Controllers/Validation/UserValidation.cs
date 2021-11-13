using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers.Validation
{
    public static class UserValidation
    {
        private const int MinFieldLength = 3;
        public static void ValidateUser(StudentViewModel student, ModelStateDictionary modelState)
        {
            ValidateNameAndPassword(student.Name, student.Password, modelState);
            if (string.IsNullOrEmpty(student.Email) || IsEmailValid(student.Email))
            {
                modelState.AddModelError("User.Email", "Invaild email");
            }
            if (student.Role == null)
            {
                modelState.AddModelError("User.Role", "Role is not set");
            }
        }

        public static void ValidateNameAndPassword(string name, string password, ModelStateDictionary modelState)
        {
            if (string.IsNullOrEmpty(name) || (name.Length < MinFieldLength))
            {
                modelState.AddModelError("User.Name", $"Name must contain at least {MinFieldLength} letters");
            }
            if (string.IsNullOrEmpty(password) || (password.Length < MinFieldLength))
            {
                modelState.AddModelError("User.Password", $"Password must contain at least {MinFieldLength} letters");
            }
        }

            private static bool IsEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
