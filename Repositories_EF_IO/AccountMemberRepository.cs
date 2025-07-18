using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF_IO;
using DataAccessLayer_EF_IO;

namespace Repositories_EF_IO
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        AccountMemberDAO mad = new AccountMemberDAO();

        public AccountMember Login(string email, string password)
        {
            return mad.Login(email, password);
        }
    }
}
