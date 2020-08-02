using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Interface
{
    interface IAccount
    {
        Account CreateAccount(Account account);
        void DeleteAccount(int account);
        void UpdateAccount(Account account);
        String getRoleAccount(int id);
        Account getAccountByEmployeeId(int employeeId);
       // List<Account> GetAllAccounts();

        Account getAccountById(int id);

        Account userLogin(string username, string password);
        Account getAccountByUserName(string username);
    }
}
