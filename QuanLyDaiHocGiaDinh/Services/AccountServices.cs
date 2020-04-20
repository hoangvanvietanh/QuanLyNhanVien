using QuanLyDaiHocGiaDinh.Dao;
using QuanLyDaiHocGiaDinh.Interface;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Services
{
    class AccountServices
    {
        IAccount accountDao = new AccountDaoImpl();

        //Lấy tất cả account
        public List<Account> GetAllAccounts()
        {
            return accountDao.GetAllAccounts();
        }

        //Lấy account bằng employeeId
        public Account getAccountByEmployeeId(int employeeId)
        {
            return accountDao.getAccountByEmployeeId(employeeId);
        }

        //Tạo tài khoản
        public Account createAccount(Account account)
        {
            return accountDao.CreateAccount(account);
        }

        //Cập nhật tài khoản
        public void updateAccount(Account account)
        {
            accountDao.UpdateAccount(account);
        }

        //Xóa tài khoản
        public void deleteAccount(int account)
        {
            accountDao.DeleteAccount(account);
        }

        public String getRoleByAccountId(int accountId)
        {
            return accountDao.getRoleAccount(accountId);
        }

        
    }
}
