using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace BankAccountLibrary
{
    public enum BankAccountTypeEnum
    {
        Current = 1,
        Saving = 2,
        CAS = 3
    }


    interface IBankAccount
    {
        double GetBalance();
        void Deposit(double amount);
        bool Withdraw(double amount);
        bool Transfer(IBankAccount toAccount, double amount);
        BankAccountTypeEnum AccountType { get; set; }
    }
    [Serializable]
    abstract class BankAccount : IBankAccount
    {
        protected double balance = 0;
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public abstract bool Withdraw(double amount);
        public abstract bool Transfer(IBankAccount toAccount, double amount);
        public abstract double GetBalance();
        public BankAccountTypeEnum AccountType { get; set; }

        public virtual void Deposit(double amount)
        {
            balance += amount;
        }
    }
    [Serializable]
    class ICICI : BankAccount
    {
        public override bool Withdraw(double amount)
        {
            if (balance - amount >= 0)
            {
                return true;
            }
            else
                return false;
        }
        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            if (balance - amount >= 1000)
            {
                balance -= amount;
                toAccount.Deposit(amount);
                return true;
            }
            else
                return false;
        }
        public override double GetBalance()
        {
            return balance;
        }
    }
    [Serializable]
    class HSBC : BankAccount
    {
        public override bool Withdraw(double amount)
        {
            if (balance - amount >= 5000)
            {
                return true;
            }
            else
                return false;
        }
        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            if (balance - amount >= 5000)
            {
                balance -= amount;
                toAccount.Deposit(amount);
                return true;
            }
            else
                return false;
        }
        public override double GetBalance()
        {
            return balance;
        }
    }
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("ICICI ACCOUNTS : ");

        //    ICICI ObjICICI1 = new ICICI();
        //    ObjICICI1.AccountType = BankAccountTypeEnum.Saving;
        //    ObjICICI1.Deposit(50000);

        //    ICICI ObjICICI2 = new ICICI();
        //    ObjICICI2.AccountType = BankAccountTypeEnum.Current;
        //    ObjICICI2.Deposit(20000);

        //    Console.WriteLine($"Balance for account 1 of type {ObjICICI1.AccountType} is = {ObjICICI1.Balance}");
        //    Console.WriteLine($"Balance for account 2 of type {ObjICICI2.AccountType} is = {ObjICICI2.Balance}");

        //    Console.WriteLine("____________________________________________________");
        //    Console.WriteLine("After transfer from account 1(savings) to 2(current)");
        //    Console.WriteLine("____________________________________________________");

        //    ObjICICI1.Transfer(ObjICICI2, 5000);
        //    Console.WriteLine($"Balance for account 1 of type {ObjICICI1.AccountType} is = {ObjICICI1.Balance}");
        //    Console.WriteLine($"Balance for account 2 of type {ObjICICI2.AccountType} is = {ObjICICI2.Balance}");
        //    Console.WriteLine();
        //    Console.WriteLine();


        //    //Stream s = new FileStream("output.dat", FileMode.Create, FileAccess.ReadWrite);
        //    //BinaryFormatter bf = new BinaryFormatter();
        //    //bf.Serialize(s,ObjICICI1);
        //    //
        //    ICICI obj;
        //    Stream s = new FileStream("output.dat", FileMode.Open, FileAccess.Read);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    obj=(ICICI)bf.Deserialize(s);
        //    Console.WriteLine(obj.AccountType);

        //    Console.WriteLine("HSBC ACCOUNTS : ");

        //    HSBC ObjHSBC1 = new HSBC();
        //    ObjHSBC1.AccountType = BankAccountTypeEnum.Current;
        //    ObjHSBC1.Deposit(60000);

        //    HSBC ObjHSBC2 = new HSBC();
        //    ObjHSBC2.AccountType = BankAccountTypeEnum.Saving;
        //    ObjHSBC2.Deposit(20000);

        //    Console.WriteLine($"Balance for account 1 of type {ObjHSBC1.AccountType} is = {ObjHSBC1.Balance}");
        //    Console.WriteLine($"Balance for account 2 of type {ObjHSBC2.AccountType} is = {ObjHSBC2.Balance}");

        //    Console.WriteLine("____________________________________________________");
        //    Console.WriteLine("After transfer from account 1(current) to 2(savings)");
        //    Console.WriteLine("____________________________________________________");

        //    ObjHSBC1.Transfer(ObjHSBC2, 30000);
        //    Console.WriteLine($"Balance for account 1 of type {ObjHSBC1.AccountType} is = {ObjHSBC1.Balance}");
        //    Console.WriteLine($"Balance for account 2 of type {ObjHSBC2.AccountType} is = {ObjHSBC2.Balance}");

        //    Console.ReadLine();
        //}
        static void Main(string[] args)
        {
            
            
            string chu = "Jahnavi";
            string[] arrays = new string[] { "gay", "mand", "sarpegiri" };
	        foreach(string a in arrays)
	        {
		        Console.WriteLine($"{chu} is {a}");
	        }
            Console.ReadLine();
        }

}

    }






