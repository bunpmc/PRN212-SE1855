﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace Repositories_EF
{
    public interface IAccountMemberRepository
    {
        public AccountMember Login (string username, string password);
    }
}
