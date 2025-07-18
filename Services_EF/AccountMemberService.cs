using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using Repositories_EF;

namespace Services_EF
{
    public class AccountMemberService : IAccountMemberService
    {
        private readonly IAccountMemberRepository _accountMemberRepository;

        public AccountMemberService()
        {
            _accountMemberRepository = new AccountMemberRepository();
        }
        public AccountMember Login(string username, string password)
        {
            return _accountMemberRepository.Login(username, password);
        }
    }
}
