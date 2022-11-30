using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking_2_Section_B___Bank_Accounts
{
    public class BankAccount {

        public BankAccount(string hn, string d, float b, float l) {
            account_holder_name = hn;
            account_description = d;
            account_balance = b;
            overdraft_limit = l;
        }

        public string account_holder_name {
            get;
            private set;
        }

        public string account_description {
            get;
            private set;
        }

        public float account_balance {
            get;
            private set;
        }

        public float overdraft_limit {
            get;
            private set;
        }

        public void withdraw(float amt) {

            float balance_after = account_balance-amt;

            if (balance_after < -overdraft_limit) {
                throw new Exception("Can't withdraw more than overdraft limit!");
            } else {
                account_balance = balance_after;
            }

        }

        public void deposit(float amt) {

            account_balance += amt;

        }

        public override string ToString() {

            string as_str = "Bank Account \"" + account_holder_name + "\":\n";
            as_str += "\tBalance:         " + account_balance + "\n";
            as_str += "\tDescription:     " + account_description + "\n";
            as_str += "\tOverdraft Limit: " + overdraft_limit;

            return as_str;

        }

    }
}
