using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.ConnectWithNodejs.Model
{
    class MongoAccount
    {
        public string AccountId;
        public string UserName;
        public string Password;
        public string Role;

        public MongoAccount()
        {

        }

        public MongoAccount(string AccountId, string UserName, string Password, string Role)
        {
            this.AccountId = AccountId;
            this.UserName = UserName;
            this.Password = Password;
            this.Role = Role;
        }
    }
}
