using System.Threading.Channels;

namespace task12
{
    public class Program
    {

        static void Main()
        {
            int emelliyat, Bank_secimi, qeydiyat_secimi;
            string accountNumber;int accountunsayi = 1; 
            string ad;decimal mebleg1;
            decimal depositammont;
            long withammont;
            ushort newpasword;
            bool flaq1 = true, flaq2 = true;
            Bank bank1 = new Bank("ABB");
            Bank bank2 = new Bank("Kapital Bank");
            Bank bank3 = new Bank("Elshad Bank");
            Bank[] banklar = { bank1, bank2, bank3 };
            int accounsayii = 1;
            BankAccount[] accountlar = new BankAccount[accounsayii];
            while (true)
            {
                Console.WriteLine("Salam , xos gelmisiniz ,Hansi banka ustunluk verirsiniz ?");
                Console.WriteLine("ABB-1\r\nKapital Bank-2\r\nElshad Bank-3\r\n");
                Bank_secimi = int.Parse(Console.ReadLine());
                Console.WriteLine("Bizi secdiyiniz ucun tesekurler");
                if (Bank_secimi > 0 && Bank_secimi < 5)
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Evvelki seyfeye qayitmaq ucun-1\r\nQeydiyyat ucun -2\r\nDaxil olmaq ucun-3\r\n");
                        qeydiyat_secimi = int.Parse(Console.ReadLine());
                        if (qeydiyat_secimi == 1) { break; }
                        else if (qeydiyat_secimi == 2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ilk once adinizi \"Space(bosluq)\" sonra soyadinizi daxil edin ");
                            accountNumber = $"AZ{accountunsayi++:D5}";
                            BankAccount account1 = new BankAccount(accountNumber);
                            account1.OwnerName = Console.ReadLine();
                            Console.WriteLine("Bir eded 4 reqemli shife daxil edin :");
                            account1.Password = ushort.Parse(Console.ReadLine());
                            banklar[Bank_secimi-1].Add(account1);
                            accountlar[accounsayii-1]=account1; accounsayii++;
                            Array.Resize(ref accountlar, accounsayii);
                            Console.WriteLine("qeydiyat ugurla basa catdi");
                            Console.WriteLine();
                            continue;
                        }
                        else if (qeydiyat_secimi == 3)
                        {
                            Console.WriteLine();
                            accountNumber = $"AZ{accountunsayi++:D5}";
                            BankAccount account2=new BankAccount(accountNumber);
                            Console.WriteLine("Adinizi \" space \" soyadinizi  ");
                            account2.OwnerName=Console.ReadLine();
                            if(banklar[Bank_secimi - 1].GetBankAccountByOwner(account2) == null)
                            {
                                Console.WriteLine("Bele bir istifadeci tapilmadi");
                                continue;
                            }
                            Console.WriteLine("Passwordinizi daxil edin");
                            account2.Password = ushort.Parse(Console.ReadLine());
                            if(banklar[Bank_secimi-1].GetBankAccountByOwner(account2).Password != account2.Password)
                            {
                                Console.WriteLine("password sehvdir");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine();
                                account2.Daxil_olmaq(banklar[Bank_secimi - 1].GetBankAccountByOwner(account2));
                                banklar[Bank_secimi - 1].Add(account2);
                                accountunsayi--;
                                while (flaq1)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("1.Deposit\r\n2.Withdraw\r\n3.AccountInfo");
                                    Console.WriteLine("4.Change OwnerName\r\n5.TransferFunds\r\n6.PassWordchange");
                                    Console.WriteLine("7.GetBankAccountsCount\r\n8.DeleteBankAccount\r\n9.Geri qayitmaq\r\n0.Quit Application");
                                    emelliyat = int.Parse(Console.ReadLine());
                                    switch(emelliyat)
                                    {
                                        case 1:
                                            Console.WriteLine();
                                            Console.WriteLine("Meblegi daxil et");
                                            depositammont=int.Parse(Console.ReadLine());
                                            account2.Deposit(depositammont);
                                            break;
                                        case 2:
                                            Console.WriteLine();
                                            Console.WriteLine("Meblegi daxil et");
                                            withammont = int.Parse(Console.ReadLine());
                                            account2.Withdraw(withammont);
                                            break;
                                        case 3:
                                            Console.WriteLine();
                                            Console.Write("Bank :");
                                            Console.WriteLine(banklar[Bank_secimi-1].Name);
                                            account2.DisplayAccountInfo();
                                            break;
                                        case 4:
                                            Console.WriteLine();
                                            Console.WriteLine("yeni name daxil et");
                                            account2.OwnerName = Console.ReadLine();
                                            break;
                                        case 5:
                                            Console.WriteLine();
                                            Console.WriteLine("kimin hesbina pul atirsiniz(ad \"space\" soyad : ");
                                            ad=Console.ReadLine();
                                            foreach (var t in accountlar)
                                            {
                                                if (t.OwnerName.ToLower() == ad.ToLower())
                                                {
                                                    Console.WriteLine("meblegi daxil ed");
                                                    mebleg1 = int.Parse(Console.ReadLine());
                                                    flaq2 = false;
                                                    if (banklar[Bank_secimi - 1].GetBankAccountByOwner(t) != null)
                                                    {
                                                        account2.TransferFunds(t, mebleg1, mebleg1);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        account2.TransferFunds(t, mebleg1, mebleg1 + 2);
                                                        Console.WriteLine("2 $ kosiya tutuldu");
                                                        break;
                                                    }
                                                }
                                            }
                                                if(flaq2)
                                                {
                                                    flaq1 = false;
                                                    Console.WriteLine("ele account yoxdur");
                                                }
                                            break;
                                        case 6:
                                            Console.WriteLine();
                                            Console.WriteLine("hazirdaki paswordi daxil et ;");
                                            newpasword=ushort.Parse(Console.ReadLine());
                                            if (account2.Password == newpasword)
                                            {
                                                Console.WriteLine("yeni sifreni daxil et");
                                                newpasword = ushort.Parse(Console.ReadLine());
                                                account2.Password = newpasword;
                                                Console.WriteLine("ugurla deyisdirildi");
                                                Console.WriteLine();
                                                break;
                                            }
                                            else
                                                Console.WriteLine("yeniden ceht et");
                                            break;
                                        case 7:
                                            Console.WriteLine();
                                            Console.WriteLine($"Bank {banklar[Bank_secimi-1].Name} ");
                                            banklar[Bank_secimi - 1].GetBankAccountCount();
                                            Console.WriteLine();
                                            Console.WriteLine($"umumi istifadecilerinin sayi {accountunsayi-1}");
                                            break;
                                        case 8:
                                            Console.WriteLine();
                                            Console.WriteLine($"${account2.Balance}$ buyrun ; ");
                                            banklar[Bank_secimi - 1].DeleteBankAccount(account2);
                                            DeletAccount(ref accountlar, account2, accounsayii);
                                            Console.WriteLine("ugurla silinmisdir");
                                            flaq1 = false;
                                            Console.WriteLine();
                                            break;
                                        case 9:
                                            flaq1 = false; Console.WriteLine();
                                            break;
                                        default:
                                            Console.WriteLine();
                                            return;

                                    }
                                }

                            }


                        }
                    }
                }
                else
                { Console.WriteLine("yanlish secim"); }
            }
        }
        static void DeletAccount(ref BankAccount[] accountlar , BankAccount bankAccount,int accounsayii)
        {
            for (int b = 0; b < accountlar.Length - 1; b++)
            {
                if (accountlar[b].AccountNumber == bankAccount.AccountNumber)
                {
                    for (int i = b; i < accountlar.Length - 1; i++)
                    {
                        accountlar[i] = accountlar[i + 1];
                    }
                }
            }
            Array.Resize(ref accountlar, --accounsayii);
        }
    }
}
