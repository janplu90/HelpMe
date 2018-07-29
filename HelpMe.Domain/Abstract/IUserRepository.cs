﻿using HelpMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void AddUser();
        void DeleteUser();
        void UpdateUser();
        bool CheckIfUserExists(string login);
        bool CheckPassword(string login, string password);
    }
}
