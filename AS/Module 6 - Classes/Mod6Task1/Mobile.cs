using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod6Task1 {
    class Mobile {

        const float CALL_COST = 0.245f;
        const float TEXT_COST = 0.078f;

        public Mobile(AccountType _account_type, string _device, long _number) {
            account_type = _account_type;
            device = _device;
            number = _number;
        }

        public enum AccountType {
            PAY_AS_YOU_GO,
            MONTHLY
        }

        public float balance {
            get;
            private set;
        }

        public string device {
            get;
            internal set;
        }

        public AccountType account_type {
            get;
            private set;
        }

        public long number
        {
            get;
            private set;
        }

        public void add_credit(float amt) {
            balance += amt;
        }

        public void make_call(int mins) {
            balance -= mins * CALL_COST;
        }

        public void sent_text(int texts) {
            balance -= texts * TEXT_COST;
        }



    }
}