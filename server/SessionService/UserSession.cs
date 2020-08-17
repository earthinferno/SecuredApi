using DataServices;
using SessionService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionService
{
    public class UserSession : IUserSession
    {
        private readonly IUserData _userData;

        public UserSession(IUserData userData)
        {
            _userData = userData;
        }

        public SessionProfile GetSessionProfile()
        {
            var userData = _userData.GetUserData();

            //TODO: replace with factory OR mapper library
            var UserSession = new SessionProfile
            {
                Name = userData.Name,
                Organization = userData.Organization,
                Email = userData.Email
            };

            return UserSession;
        }
    }
}
