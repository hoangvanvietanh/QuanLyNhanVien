using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Controller
{
    class HomeController
    {
        //Nếu mấy ông không biết đổ qua controller thì khỏi dùng nha, gọi service qua form rồi làm là được rồi

        //Gọi services vào đây để xử lý
        private AccountServices accountServices = new AccountServices();
        private Account account = new Account();


        //Những hàm xử lý logic thì để bên này nhé
        public String Login(string user, string password)
        {
            string accountRole = "";
            bool isCorrect = false;
            accountServices.GetAllAccounts().ForEach(x =>
            {
                if (String.Compare(x.UserName.Trim(), user.Trim(), true) == 0)
                {
                    if (String.Compare(x.Password.Trim(), password.Trim(), true) == 0)
                    {
                        isCorrect = true;
                        accountRole = x.Role;
                        account = x;
                    }
                }
            });
            if (isCorrect == true)
            {
                return accountRole;
            }
            return accountRole;
        }

        //Lấy account đang login
        public Account getAccountLoggedIn()
        {
            return account;
        }
    }
}
