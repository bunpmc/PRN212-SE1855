﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF_IO;

namespace Repositories_EF_IO
{
    public  interface IAccountMemberRepository
    {
        public AccountMember Login(string email, string password);
    }
}
