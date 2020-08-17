using DataServices.Model;
using System;

namespace DataServices
{
    public class UserData : IUserData
    {
        public User GetUserData()
        {
            return new User
            {
                Name = "nameStub",
                Organization = "OrganizationStub",
                Email = "EmailStub"
            };
        }

    }
}
