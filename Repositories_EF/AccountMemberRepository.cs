using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using DataAccessLayer_EF;

namespace Repositories_EF
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        AccountMemberDAO accountMemberDAO = new AccountMemberDAO();
        // Implement methods for account member repository here
        // For example, methods to add, update, delete, and retrieve account members
        public AccountMember Login(string username, string password)
        {
            return accountMemberDAO.Login(username, password);
        }
    }

}
