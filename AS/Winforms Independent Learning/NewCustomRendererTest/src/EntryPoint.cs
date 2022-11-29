using System;

namespace Engine {

    public class EntryPoint : System.Windows.Forms.Form {

        System.Windows.Forms.Button button1;

        public EntryPoint() {
            InitializeComponent();
        }

        void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.Text = "Test";
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.button1,
            });
        }

        [STAThread]
        public static void Main(string[] args) {
            System.Windows.Forms.Application.Run(new EntryPoint());
        }

    }
    
}