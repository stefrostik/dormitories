using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
                    UserName = registerUserModel.Name,
                    FacultyId = null,
                    CategoryId = null
                };
            }
            else
            {
                usr = new Administrator()
                {
                    UserName = registerUserModel.Name,
                    DormitoryId = null
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

        #region External

        //public async Task<IdentityResult> RegisterExternalAsync(ExternalLoginData data)
        //{
        //    using (var context = provider.Context)
        //    {
        //        var manager = provider.GetUserManager(context);
        //        data.Email = GetExternalEmail(data.ExternalAccessToken);
        //        var user = await manager.FindByEmailAsync(data.Email);
        //        if (user != null)
        //        {
        //            return await manager.AddLoginAsync(user.Id, new UserLoginInfo(data.LoginProvider, data.ProviderKey));
        //        }

        //        user = mapper.Map<ExternalLoginData, User>(data);
        //        var result = await CreateAsync(user);

        //        if (result.Succeeded)
        //        {
        //            result = await manager.AddLoginAsync(user.Id, new UserLoginInfo(data.LoginProvider, data.ProviderKey));
        //        }

        //        if (result.Succeeded)
        //        {
        //            result = await manager.AddToRolesAsync(user.Id, LvivCyclingConsts.DefaultRole);
        //        }

        //        return result;
        //    }
        //}

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

        //public ExternalLoginData GetExternalDataFromIdentity(ClaimsIdentity identity)
        //{
        //    if (identity == null)
        //    {
        //        return null;
        //    }

        //    Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

        //    if (providerKeyClaim == null
        //        || string.IsNullOrEmpty(providerKeyClaim.Issuer)
        //        || string.IsNullOrEmpty(providerKeyClaim.Value)
        //        || providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
        //    {
        //        return null;
        //    }

        //    return new ExternalLoginData
        //    {
        //        LoginProvider = providerKeyClaim.Issuer,
        //        ProviderKey = providerKeyClaim.Value,
        //        UserName = identity.FindFirstValue(ClaimTypes.Name),
        //        ExternalAccessToken = identity.FindFirstValue(LvivCyclingConsts.ExternalAccessToken)
        //    };
        //}

        #endregion

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

        //private string GetExternalEmail(string accessToken)
        //{
        //    var fb = new FacebookClient(accessToken);
        //    dynamic myInfo = fb.Get(LvivCyclingConsts.FacebookEmailPath);
        //    var email = myInfo.email;

        //    return email;
        //}

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
