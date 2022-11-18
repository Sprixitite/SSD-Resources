using System;

namespace Mod6Task1
{
    class Program
    {
        static void Main(string[] args) {
            Mobile my_funky_phone = new Mobile(Mobile.AccountType.PAY_AS_YOU_GO, "FunnyPhone", 69420);
            Console.WriteLine("Account type: " + my_funky_phone.account_type + "\nDevice: " + my_funky_phone.device + "\nNumber: " + my_funky_phone.number);

            my_funky_phone.add_credit(10);

            Console.WriteLine("Credit sucessful\n\nMobile Number: " + my_funky_phone.number + "\nBalance: " + my_funky_phone.balance);
            my_funky_phone.make_call(15);
            Console.WriteLine("Call made\n\nMobile number: " + my_funky_phone.number + "\nBalance: " + my_funky_phone.balance);
            my_funky_phone.sent_text(2);

            Console.WriteLine("Text sent\n\nMobile number: " + my_funky_phone.number + "\nBalance: " + my_funky_phone.balance);

            Console.ReadKey();
        
        }
    }
}
