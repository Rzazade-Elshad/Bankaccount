using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    public class Bank
    {
        private BankAccount[] _accounts;
        public BankAccount[] accounts
        {
            get { return _accounts; }
        }
        public int _count=0;
        public string Name;

        public Bank(string name)
        {
            Name = name;
            BankAccount[] _accounts = new BankAccount[_count];
        }

        public void Add(BankAccount account)
        {
            bool flaq=true;
            for (int i=0;i< _count;i++)
            {
                if (_accounts[i].AccountNumber == account.AccountNumber)
                {
                    _accounts[i] = account;
                    flaq = false;
                    break;
                }
            }
            if (flaq)
            {
                Array.Resize(ref _accounts, ++_count);
                _accounts[_count - 1] = account;
            }
        }
        public BankAccount GetBankAccountByOwner(BankAccount account)
        {
            if (_count <= 0)
            {
                Console.WriteLine("hecbir accoun yoxdur");
                return default;
            }
            foreach (BankAccount b in _accounts)
            {
                if (b.OwnerName.ToLower() == account.OwnerName.ToLower())
                {
                    return b;
                }
            }
            Console.WriteLine("Account tapilmadi");
            return null;
        }
        public int GetBankAccountCount()
        {
            Console.WriteLine($"Hal hazirda {_accounts.Length} eded istifadecui var");
            return default;
        }
        public void DeleteBankAccount(BankAccount bankAccount)
        {
            for(int b=0;b<_accounts.Length-1;b++)
            {
                if (_accounts[b].AccountNumber == bankAccount.AccountNumber)
                {
                    for(int i = b; i < _accounts.Length-1; i++)
                    {
                        _accounts[i] = _accounts[i+1];
                    }
                    break;
                }
            }
            Array.Resize(ref _accounts,--_count);
        }
    }
}

