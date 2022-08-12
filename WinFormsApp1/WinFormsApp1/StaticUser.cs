using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace WinFormsApp1
{
    public class StaticUser
    {
        public static int quantityUsers = 100;                  // количество пользователей в системе
        public static int counterUsers = 0;                     // счётчик пользователей
        public static User[] users = new User[quantityUsers];
        
    }
}
