using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF_IO;
using Repositories_EF_IO;

namespace Services_EF_IO
{
    public class AccountMemberService : IAccountMemberService
    {
        private readonly IAccountMemberRepository _accountMemberRepository;
        public AccountMemberService()
        {
            _accountMemberRepository = new AccountMemberRepository();
        }
        public AccountMember Login(string email, string password)
        {
            return _accountMemberRepository.Login(email, password);
        }
    }
}
