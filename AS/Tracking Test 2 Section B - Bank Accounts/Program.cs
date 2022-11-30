using System;
using System.Collections.Generic;

namespace Tracking_2_Section_B___Bank_Accounts {
    class Program {

        public static BankAccount select_account(BankAccount[] accounts) {

            while (true) {

                Console.Write("Enter account holder: ");
                string account_holder = Console.ReadLine();

                int holder_appearances = 0;
                List<BankAccount> accounts_found = new List<BankAccount>();
                foreach (BankAccount account in accounts)
                {
                    if (account.account_holder_name == account_holder)
                    {
                        holder_appearances++;
                        accounts_found.Add(account);
                    }
                }

                switch (holder_appearances)
                {
                    case < 1:
                        Console.WriteLine("That account holder does not exist!");
                        continue;
                    case 1:
                        return accounts_found[0];
                    case > 1:
                        Console.WriteLine("There are multiple accounts under this holder, please specify by the description!");
                        int i = 1;
                        foreach (BankAccount account in accounts_found)
                        {
                            Console.WriteLine("\t" + i + ") " + account.account_description);
                            i++;
                        }
                        int idx = -1;
                        while (true)
                        {
                            try
                            {
                                idx = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("That number is not a valid choice! Please try again!");
                            }
                            if (idx >= accounts_found.Count || idx < 0) {
                                Console.WriteLine("That option is out of bounds!");
                                continue;
                            } else {
                                break;
                            }
                        }
                        return accounts_found[idx - 1];

                }

            }

        }

        static void Main(string[] args) {
            
            const uint BANK_ACCOUNTS = 3;

            BankAccount[] accounts = new BankAccount[BANK_ACCOUNTS];

            for (int i=0; i<BANK_ACCOUNTS; i++) {

                Console.WriteLine("Bank Account " + (i+1) + ":");
                Console.Write("\tAccount Name:        "); string name = Console.ReadLine();
                Console.Write("\tAccount Description: "); string description = Console.ReadLine();
                float overdraft_amt;
                while (true) {
                    Console.Write("\tAccount Overdraft:   ");
                    try {
                        overdraft_amt = (float)Convert.ChangeType(Console.ReadLine(), typeof(float));
                        break;
                    } catch {
                        Console.WriteLine("That overdraft amount is invalid, please try again! ");
                    }
                }

                accounts[i] = new BankAccount(name, description, 0.0f, overdraft_amt);

            }

            BankAccount selected = select_account(accounts);

            while (true) {

                Console.Clear();

                Console.WriteLine("What would you like to do to this account? ");

                Console.WriteLine("\t1) Make a deposit");
                Console.WriteLine("\t2) Make a withdrawal");

                int selection = int.Parse(Console.ReadLine());

                switch (selection) {

                    case 1:
                        Console.Write("How much would you like to deposit? ");
                        float deposit_amt = (float)Convert.ChangeType(Console.ReadLine(), typeof(float));
                        selected.deposit(deposit_amt);
                        break;

                    case 2:
                        while (true) {
                            Console.Write("How much would you like to withdraw? ");
                            float withdrawal_amt;
                            try {
                                withdrawal_amt = (float)Convert.ChangeType(Console.ReadLine(), typeof(float));
                            } catch {
                                Console.WriteLine("Withdrawal amount is invalid! Please try again!");
                                continue;
                            }
                            try {
                                selected.withdraw(withdrawal_amt);
                                break;
                            } catch {
                                Console.WriteLine("Withdrawal would put you past your overdraft, please try again!");
                                continue;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("That option doesn't exist, press any key to try again!");
                        Console.ReadKey();
                        continue;

                }

                Console.WriteLine("New account balance: £" + selected.account_balance);
                Console.WriteLine("The program will now exit, press any key to close the program...");
                Console.ReadKey();

                break;

            }

            

        }
    }
}
