using System;

namespace MoreDifficultStudentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student mySudent = new Student(5, "Adam", "Ackerman", 10000);

            Console.WriteLine(mySudent);

            mySudent.MakePayment(500);
            Console.WriteLine(mySudent);

            mySudent.MakePayment(500);
            Console.WriteLine(mySudent);
            
            try
            {
                mySudent.MakePayment(-500);
                Console.WriteLine(mySudent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
