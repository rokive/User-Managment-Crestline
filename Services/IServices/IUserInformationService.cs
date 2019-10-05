using Entity.Models;
using Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IUserInformationService
    {
        void AddUserInformation(UserInformation userInformation);

        bool GetPasswordRecovery(PasswordRecovery passwordRecovery);

        bool GetUserNameRecovery(string userName);

        UserInformation Login(Login login);

        bool GetCheckEmailConfirmation(string activationCode);

        bool GetUsertNameExist(string userName);

        void UpdatePasswor(string userName, string newPassword);
    }
}
