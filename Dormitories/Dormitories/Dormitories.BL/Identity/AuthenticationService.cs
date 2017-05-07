using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dormitories.BL.DTO_s;
using Dormitories.BL.Interfaces;
using Dormitories.DAL.Identity;
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
                    FullName = registerUserModel.Name,
                    FacultyId = registerUserModel.FacultyId,
                    GroupId = registerUserModel.GroupId,
                    PhoneNumber = registerUserModel.PhoneNumber,
                    RoomId = registerUserModel.RoomId,
                    StudyYear = registerUserModel.StudyYear ?? 0,
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
                    FullName = registerUserModel.Name,
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
                    throw ex;
                }

                if (result.Succeeded)
                {
                    result = await manager.AddToRolesAsync(usr.Id, registerUserModel.RoleName);
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
                ExpiresUtc = DateTime.UtcNow.AddDays(14)
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

        public ICollection<RoleDTO> GetAllRoles()
        {
            using (var context = provider.Context)
            {
                return context.Roles
                    .Select(r=> new RoleDTO()
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();
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
