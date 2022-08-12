using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class User
    {
        int uniqueNumber;       // уникальный номер
        string firstName;       // имя пользователя
        string fullName;        // фамилия пользователя
        string login;
        string password;        // пароль
        string email;           // e-mail
        string numberPhone;     // номер телефона
        string dataRegistration;
        int levelAccess;        // уровень допуступа
        public User()
        {

        }

        public int UniqueNumber
        {
            get { return uniqueNumber; }   // возвращаем значение свойства

            set { uniqueNumber = value; }
        }

        public int LevelAccess
        {
            get { return levelAccess; }   // возвращаем значение свойства

            set { levelAccess = value; }
        }

        public string FirstName
        {
            get { return firstName; }   // возвращаем значение свойства

            set { firstName = value; }   // устанавливаем новое значение свойства
        }

        public string FullName
        {
            get { return fullName; }   // возвращаем значение свойства

            set { fullName = value; }   // устанавливаем новое значение свойства
        }

        public string Email
        {
            get { return email; }   // возвращаем значение свойства

            set { email = value; }   // устанавливаем новое значение свойства
        }

        public string Password
        {
            get { return password; }   // возвращаем значение свойства

            set { password = value; }   // устанавливаем новое значение свойства
        }

        public string Login
        {
            get { return login; }   // возвращаем значение свойства

            set { login = value; }   // устанавливаем новое значение свойства
        }

        public string NumberPhone
        {
            get { return numberPhone; }   // возвращаем значение свойства

            set { numberPhone = value; }   // устанавливаем новое значение свойства
        }


        public string DataRegistration
        {
            get { return dataRegistration; }   // возвращаем значение свойства

            set { dataRegistration = value; }   // устанавливаем новое значение свойства
        }

        public void DisplayFullInformation()
        {
            Console.WriteLine("Номер: {0} Имя: {1} Фамилия: {2} Пароль: {3} E-mail: {4} Конктный телефон: {5} Дата регистрации: {6} ",
                UniqueNumber, FirstName, FullName, Password, Email, NumberPhone, DataRegistration);
        }

        public void DisplayPublicInformation()
        {
            Console.WriteLine("Имя: {1} Фамилия: {2} E-mail: {4} Конктный телефон: {5}",
               FirstName, FullName, Email, NumberPhone);
        }
    }
}
