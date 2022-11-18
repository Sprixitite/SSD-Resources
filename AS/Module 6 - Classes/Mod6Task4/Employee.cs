using System;

namespace Mod6Task4 {
    class Employee {

        public Employee(string _name, float _salary) {
            name = _name;
            salary_untaxed = _salary;
        }

        public string name {
            get;
            private set;
        }

        public float salary_untaxed {
            get;
            protected set;
        }

        public void set_salary(float _salary) {
            salary_untaxed = new_s;
        }

        public float salary_taxed {
            get => salary_untaxed - tax;
        }

        public float tax {
            get {
                switch (salary_untaxed) {
                    case <= 9000:
                        return 0;
                    default:
                        return salary_untaxed*0.15f;
                    case > 20000:
                        return (11000*0.15f)+(salary_untaxed-20000)*0.25f;
                }
            }
        }

    }
}