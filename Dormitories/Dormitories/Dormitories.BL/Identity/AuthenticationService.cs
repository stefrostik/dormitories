using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;

namespace Dormitories.BL.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDormitoriesIdentityProvider provider;

        public AuthenticationService()
        {
            this.provider = new DormitoriesIdentityProvider();
        }

        #region Local

        public async Task<IdentityResult> CreateAsync(User user)
        {
            using (var context = provider.Context)
            {
                IUserManager userManager =
                    provider.GetUserManager(context);
                var result = await userManager.CreateAsync(user);

                return result;
            }
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDTO registerUserModel)
        {
            User usr = null;

            if (registerUserModel.RoleName == "Student")
            {
                usr = new Student()
                {
                    UserName = registerUserModel.StudentCardId,
                    CategoryId = registerUserModel.CategoryId,
                    Email = registerUserModel.Email,
                    FacultyId = registerUserModel.FacultyId,
                    GroupId = registerUserModel.GroupId,
                    PhoneNumber = registerUserModel.PhoneNumber,
                    RoomId = registerUserModel.RoomId,
                    StudyYear = registerUserModel.StudyYear,
                    StudentCardId = registerUserModel.StudentCardId,
                };
            }
            else
            {
                usr = new Administrator()
                {
                    UserName = registerUserModel.Email,
                    DormitoryId = registerUserModel.DormitoryId,
                    PhoneNumber = registerUserModel.PhoneNumber,
                    Email = registerUserModel.Email,
                    FacultyId = registerUserModel.FacultyId
                };
            }

            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                IdentityResult result = null;
                try
                {
                    result = await manager.CreateAsync(usr, registerUserModel.Password);
                }
                catch (Exception ex)
                {
                    throw;
                }

                if (result.Succeeded)
                {
                    await manager.AddToRolesAsync(usr.Id, registerUserModel.RoleName/*LvivCyclingConsts.DefaultRole*/);
                }

                return result;
            }
        }

        public async Task<User> FindUser(string userName, string password)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                User user = await manager.FindAsync(userName, password);

                return user;
            }
        }

        public async Task<ClaimsIdentity> CreateIdentity(User user, string authenticationType)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);

                return userIdentity;
            }
        }

        #endregion

        public async Task<bool> HasRegistered(UserLoginInfo info)
        {
            var user = await FindAsync(info);

            return user != null;
        }

        public async Task<User> FindAsync(UserLoginInfo login)
        {
            using (var context = provider.Context)
            {
                IUserManager manager = provider.GetUserManager(context);
                var userIdentity = await manager.FindAsync(login);

                return userIdentity;
            }
        }

        public string GenerateLocalAccessTokenResponse(User user, OAuthAuthorizationServerOptions options)
        {
            ClaimsIdentity identity = CreateExternalIdentity(user, options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                //ExpiresUtc = DateTime.UtcNow.Add(LvivCyclingConsts.DefaultTokenExpirationTime)
            };

            var ticket = new AuthenticationTicket(identity, props);
            var accessToken = options.AccessTokenFormat.Protect(ticket);

            return accessToken;
        }

        public async Task<string> GetAllRolesJson(long userId)
        {
            using (var context = provider.Context)
            {
                var manager = provider.GetUserManager(context);
                var listRoles = await manager.GetRolesAsync(userId);
                var rolesString = JsonConvert.SerializeObject(listRoles);

                return rolesString;
            }
        }

        private ClaimsIdentity CreateExternalIdentity(User user, string authentiationType)
        {
            using (var context = provider.Context)
            {
                var manager = provider.GetUserManager(context);

                return manager.CreateExternalIdentity(user, authentiationType);
            }
        }
    }
}
