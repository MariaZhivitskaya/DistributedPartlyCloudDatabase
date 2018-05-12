using DistributedPartlyCloudDatabase.BLL.Interface;
using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.BLL.Services;
using DistributedPartlyCloudDatabase.Web.Infrastructure.Mappers;
using DistributedPartlyCloudDatabase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Helpers;
using System.Web.Security;

namespace DistributedPartlyCloudDatabase.Web.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public UserService UserService
        {
            get
            {
                return (UserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(UserService));
            }
        }

        public RoleService RoleService
        {
            get
            {
                return (RoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleService));
            }
        }

        public MembershipUser CreateUser(string email, string password, string nickname, string surname, string name, DateTime birthdate)
        {
            //var membershipUser = GetUser(nickname, false);
            //var ll = GetUserNameByEmail(email);

            if (GetUser(nickname, false) != null && GetUserNameByEmail(email) != null)
            {
                return null;
            }

            var userViewModel = new UserViewModel
            {
                Email = email,
                Password = Crypto.HashPassword(password),
                Nickname = nickname,
                Surname = surname,
                Name = name,
                Birthdate = birthdate
            };

            RoleEntity userRoleEntity = RoleService.GetAllRoleEntities().FirstOrDefault(r => r.Name == "User");
            if (userRoleEntity != null)
            {
                userViewModel.RoleId = userRoleEntity.Id;
            }

            UserService.CreateUser(userViewModel.ToBllUser());

            MembershipUser membershipUser = GetUser(nickname, false);

            return membershipUser;
        }

        public override bool ValidateUser(string username, string password)
        {
            //Regex regex = new Regex(@"[A - Za - z0 - 9._ % +-] +@[A - Za - z0 - 9.-] +\.[A-Za-z]{2,4}");
            //var user = regex.IsMatch(username) 
            //    ? UserService.GetUserByEmail(username) 
            //    : UserService.GetUserByNickname(username);

           
            UserEntity userEntity = UserService.GetUserByEmail(username);

            if (userEntity != null && Crypto.VerifyHashedPassword(userEntity.Password, password))
            {
                return true;
            }
            return false;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            UserEntity userEntity = UserService.GetUserByNickname(username);
            if (userEntity == null)
            {
                return null;
            }

            var membershipUser = new MembershipUser("CustomMembershipProvider", userEntity.Nickname,
                null, null, null, null,
                false, false, DateTime.Now,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return membershipUser;
        }

        public override string GetUserNameByEmail(string email)
        {
            UserEntity userEntity = UserService.GetUserByEmail(email);

            return userEntity != null ? userEntity.Nickname : null;
        }

        #region Stabs

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }



        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}