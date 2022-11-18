using System;

namespace PropertiesExample {

    public class Person {

        public Person() {
            name = "";
        }

        public string name {
            get;
            set;
        }

        private int _age;
        public int age {
            get;
            set {
                if (value >= 21) {
                    _age = value;
                } else {
                    throw new Exception();
                }
            }
        }

        public enum Gender {
            MALE,
            FEMALE,
            NB
        }

        public Gender gender {
            get;
            set;
        }

    }

}