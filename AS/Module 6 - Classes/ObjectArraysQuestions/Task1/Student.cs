using System;

namespace ObjectArraysTask1 {

    public class Student {

        public Student(string _name, int __score) {
            name = _name;
            score = __score;
        }

        public string name {
            get;
            init;
        }

        private int _score;
        public int score {
            get { return _score; }
            set {
                if (value > 100 || value < 0) {
                    throw new Exception();
                }
                _score = value;
            }
        }

    }

}