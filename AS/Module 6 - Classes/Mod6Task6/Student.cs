using System;
using System.Linq;

namespace Mod6Task6 {

    class Student {

        private protected const int score_count = 3;

        public Student(string _name) {
            scores = new int[score_count];
            scores_present = new bool[score_count];
            for (int i=0; i<score_count; i++) { scores_present[i]=false; }
            name = _name;
            total_score = 0;
        }

        public string name {
            get;
            private set;
        }

        private int[] scores;
        private bool[] scores_present;

        private int scores_saved = 0; 
        public int total_score {
            get;
            private set;
        }
        public float average_score {
            get => total_score/scores_saved;
        }
        public bool score_is_set(int index) {
            return scores_present[index];
        }
        public void remove(int index) {
            scores_saved--;
            total_score -= scores[index];
            int[] tmp = new int[score_count];
            for (int i=0; i<score_count; i++) {
                if (i == index) continue;
                tmp[i] = scores[i];
            }
            scores = tmp;
            scores_present[index] = false;
        }
        public int this[int index] {
            get => scores[index];
            set {
                if (scores_present[index]) {
                    total_score -= scores[index];
                    scores[index] = value;
                    total_score += value;
                } else if (!scores_present[index]) {
                    scores_saved++;
                    total_score += value;
                    scores[index] = value;
                }
                scores_present[index] = true;
            }
        }

    }

}