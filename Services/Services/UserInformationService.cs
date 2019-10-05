using Core;
using Entity.Models;
using Entity.ViewModel;
using Repositories.Repositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Services.Services
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IGenericRepository<UserInformation> _genericUserInformationRepository;

        public UserInformationService(IGenericRepository<UserInformation> genericRepository)
        {
            _genericUserInformationRepository = genericRepository;
        }

        public void AddUserInformation(UserInformation userInformation)
        {
            userInformation.Token = Guid.NewGuid().ToString("N");
            _genericUserInformationRepository.Create(userInformation);
            _genericUserInformationRepository.Save();

            SentEmailForConfirmation(userInformation);
        }

        public bool GetCheckEmailConfirmation(string activationCode)
        {
            UserInformation user = _genericUserInformationRepository.GetFirst(v => v.Token == activationCode && v.isConfirm == false);
            if (user!=null)
            {
                user.isConfirm = true;
                _genericUserInformationRepository.Update(user);
                _genericUserInformationRepository.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetPasswordRecovery(PasswordRecovery passwordRecovery)
        {
            bool IsExist = _genericUserInformationRepository.GetExists(v=>v.UserName==passwordRecovery.UserName && v.SecurityQuestion.ToLower()==passwordRecovery.SecurityQuestion&&v.Answer==passwordRecovery.SecurityAnswer);
            return IsExist;
        }

        public bool GetUserNameRecovery(string userName)
        {
            bool IsExist = _genericUserInformationRepository.GetExists(v => v.UserName ==userName );
            return IsExist;
        }

        public bool GetUsertNameExist(string userName)
        {
            return _genericUserInformationRepository.GetExists(v=>v.UserName==userName);
        }

        public UserInformation Login(Login login)
        {
            return _genericUserInformationRepository.GetFirst(v => v.UserName == login.UserName&&v.Password==login.Password);
        }

        public void UpdatePasswor(string userName, string newPassword)
        {
            UserInformation user = _genericUserInformationRepository.GetFirst(v => v.UserName == userName);
            user.Password = newPassword;
            _genericUserInformationRepository.Update(user);
            _genericUserInformationRepository.Save();
        }

        private void SentEmailForConfirmation(UserInformation user)
        {
            var fromAddress = new MailAddress(Constants.from_email_address, "From Name");
            var toAddress = new MailAddress(user.UserName, "To Name");
            const string fromPassword = Constants.from_email_password;
            const string subject = "Email confirmation";
            string body = "Hello " + user.FirstName+" "+user.LastName + ",\n\r";
            body += "Please click the following link to activate your account \n\r";
            body += Constants.absolute_url + "Home/EmailConfirmation?activationCode=" + user.Token + "\n\r";
            body += "Thanks";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials=true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
