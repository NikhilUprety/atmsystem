using System;
using System.Collections.Generic;

public class cardholder
{
    string cardnum;
    public string firstname;
    public string lastname;
    int pin;
    double balance;

    public cardholder(string cardnum, string firstname, string lastname, int pin, double balance)
    {
        this.cardnum = cardnum;
        this.firstname = firstname;
        this.lastname = lastname;
        this.pin = pin;
        this.balance = balance;
    }

    public string getcardnum()
    {
        return cardnum;
    }

    public string getfirstname()
    {
        return firstname;
    }

    public string getlastname()
    {
        return lastname;
    }

    public double getbalance()
    {
        return balance;
    }

    public int getpin()
    {
        return pin;
    }

    public void setnum(string newcardnum)
    {
        cardnum = newcardnum;
    }

    public void setpin(int newpin)
    {
        pin = newpin;
    }

    public void setfirstname(string newfirstname)
    {
        firstname = newfirstname;
    }

    public void setlastname(string newlastname)
    {
        lastname = newlastname;
    }

    public void setbalance(double newbalance)
    {
        balance = newbalance;
    }
}

class Program
{
    static void Main(string[] args)
    {
        void printoptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardholder currentuser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine() ?? "0");
            currentuser.setbalance(currentuser.getbalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your balance is: " + currentuser.getbalance());
        }

        void withdraw(cardholder currentuser)
        {
            Console.WriteLine("How much money would you like to withdraw:");
            double withdrawal = double.Parse(Console.ReadLine() ?? "0");
            if (currentuser.getbalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                currentuser.setbalance(currentuser.getbalance() - withdrawal);
                Console.WriteLine("Withdrawal successful.");
            }
        }

        void showBalance(cardholder currentuser)
        {
            Console.WriteLine("Current balance: " + currentuser.getbalance());
        }

        List<cardholder> cardholders = new List<cardholder>();
        cardholders.Add(new cardholder("16565626", "niraj", "uprety", 1234, 159.31));
        cardholders.Add(new cardholder("16565627", "nikhil", "uprety", 1233, 158.31));
        cardholders.Add(new cardholder("16565628", "rajan", "khanal", 1236, 150.31));
        cardholders.Add(new cardholder("16565636", "prakrity", "uprety", 1234, 155.31));
        cardholders.Add(new cardholder("16565629", "uttam", "rai", 1238, 110.31));


        Console.WriteLine("Welcome to Simple ATM");
        Console.WriteLine("Please insert your debit card:");
        string debitcardnum = "";
        cardholder currentuser = null; 

        while (true)
        {
            try
            {
                debitcardnum = Console.ReadLine() ?? "";
                currentuser = cardholders.Find(a => a.getcardnum() == debitcardnum);
                if (currentuser != null) { break; }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin:");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine() ?? "0");

                if (currentuser != null && currentuser.getpin() == userPin) { break; } // Check pin
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentuser.getfirstname() + ":)");

        int option = 0;

        do
        {
            printoptions();
            try
            {
                option = int.Parse(Console.ReadLine() ?? "0");

                switch (option)
                {
                    case 1:
                        deposit(currentuser);
                        break;
                    case 2:
                        withdraw(currentuser);
                        break;
                    case 3:
                        showBalance(currentuser);
                        break;
                    case 4:
                        Console.WriteLine("Thank you! Have a great day.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
                option = 0;
            }
        }
        while (option != 4);
    }
}
