﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF_IO;

namespace DataAccessLayer_EF_IO
{
    public class AccountMemberDAO
    {
        MyStoreContext context = new MyStoreContext();
        public AccountMember Login(string email, string password)
        {
            return context.AccountMembers
                .FirstOrDefault(m => m.EmailAddress == email && m.MemberPassword == password);
        }
    }
}
