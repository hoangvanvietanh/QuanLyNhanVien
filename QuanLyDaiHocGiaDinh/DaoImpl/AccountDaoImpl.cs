using QuanLyDaiHocGiaDinh.Interface;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Dao
{
    class AccountDaoImpl : IAccount
    {
        private LinQDataContext db;
        private List<Account> accounts;

        //Lấy database từ cơ sở dữ liệu
        public AccountDaoImpl()
        {
            db = new LinQDataContext();
            using (db)
            {
                var account = from x in db.Accounts select x;
                accounts =  account.ToList();
            }
        }

        //Tạo tài khoản
        public void CreateAccount(Account account)
        {
            db = new LinQDataContext();
            Account ac = new Account();
            ac = account;
            db.Accounts.InsertOnSubmit(ac);
            db.SubmitChanges();
        }

        //Xóa tài khoản
        public void DeleteAccount(Account account)
        {
            db = new LinQDataContext();
            Account ac = new Account();
            ac = db.Accounts.Single(x => x.AccountId == account.AccountId);
            db.Accounts.DeleteOnSubmit(ac);
            db.SubmitChanges();
        }

        //Cập nhật tài khoản
        public void UpdateAccount(Account account)
        {
            db = new LinQDataContext();
            Account ac = new Account();
            ac = db.Accounts.Single(x => x.AccountId == account.AccountId);
            setAccountUpdate(ac, account);
            db.SubmitChanges();
        }

        //Lấy danh sách accounts
        public List<Account> GetAllAccounts()
        {
            return accounts;
        }

        //Lấy account bằng employeeId
        public Account getAccountByEmployeeId(int employeeId)
        {
            Account account = new Account();
            accounts.ForEach(ac =>
            {
                if (ac.EmployeeId == employeeId)
                {
                    account = ac;
                }
            });

            return account;
        }

        //Ánh xạ account update qua account trên linq để update
        public Account setAccountUpdate(Account accountDB, Account accountUpdate)
        {
            accountDB.Password = accountUpdate.Password;
            accountDB.Role = accountUpdate.Role;
            return accountUpdate;
        }
    }
}
