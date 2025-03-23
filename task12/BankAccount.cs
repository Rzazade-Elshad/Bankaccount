using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace task12
{
    public class BankAccount
    {
        private string ownerPattern = @"^[A-ZƏÖĞÜÇŞİa-zəöğüçşi]{3,}\s[A-ZƏÖĞÜÇŞİa-zəöğüçşi]{3,}$";
        private ushort _Password;
        public ushort Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (value < 10000)
                {
                    _Password = value;
                }
                else
                {
                    Console.WriteLine("Zehmet olamasa duzgun daxil edin ");
                    return;
                }
            }
        }
        private decimal _Balance;
        public decimal Balance
        {
            get { return _Balance; }
        }
        private string _AccountNumber;
        public string AccountNumber
        {
            get { return _AccountNumber; }
        }
        private string _OwnerName;
        public string OwnerName
        {
            get { return _OwnerName; }
            set
            {
                if (Regex.IsMatch(value, ownerPattern))
                {
                    _OwnerName = value;
                }
                else
                {
                    Console.WriteLine("yazilish sehvdi");
                    Console.WriteLine("bundan sonra yazdiqlariniz qeyde alinmir zehmetolamsa yeniden qeyd edin");
                }
            }
        }
        public BankAccount(string _AccountNumber)
        {
            this._AccountNumber = _AccountNumber;
        }
        public void Deposit(decimal amount)
        {
            if (amount >0)
            {
                _Balance += amount;
                Console.WriteLine("Emeliyyat ugurla tamamlandi  ");
            }
            else
            {
                Console.WriteLine("Zehmet olamasa duzgun daxil edin ");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= _Balance && amount>0)
            {
                _Balance -= amount;
                Console.WriteLine("Emeliyyat ugurla tamamlandi  ");
            }
            else if (amount > _Balance)
            {
                Console.WriteLine("balance kifayet deyil");
            }
            else
            {
                Console.WriteLine("Zehmet olamasa duzgun daxil edin ");
            }
        }
        public void DisplayAccountInfo()
        {
            Console.Write($"_OwnerName {_OwnerName}         ");
            Console.WriteLine($" _AccountNumber {_AccountNumber} ");
            Console.Write($" _Balance {_Balance}            ");
            Console.WriteLine($"_Password {_Password}");
        }
        public void TransferFunds(BankAccount recipient, decimal amount, decimal amount1)
        {
            if(amount > 0 && amount1 > 0 && amount <= _Balance-2)
            {
                recipient._Balance+=amount;
                _Balance -= amount1;
                Console.WriteLine(" Emeliyyat ugurla tamamlandi ");
            }
            else if (amount > _Balance)
            {
                Console.WriteLine("balance kifayet deyil");
            }
            else
            {
                Console.WriteLine("Zehmet olamasa duzgun daxil edin ");
            }
        }
        public void Daxil_olmaq(BankAccount recipient)
        {
            _Balance = recipient.Balance;
            _AccountNumber = recipient.AccountNumber;
        }
    }
}
