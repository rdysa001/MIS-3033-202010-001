using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P__Classes_3
{
    class Student
    {
        //Constructors for student
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }
        public Address Address { get; set; }

        //Default Constructor
        public Student()
        {
            FirstName = null;
            LastName = null;
            Major = null;
            GPA = 0;
            Address = Address;
        }

        //Constructor with overloads
        public Student(string firstName, string lastName, string major, double gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            Major = major;
            GPA = gpa;
            Address = Address;
        }

        //Lets us know what distinction the student received, if any.
        public string CalculateDistinction()
        {
            string dist = null;
            if (GPA >= 3.8)
            {
                dist = ", Summa Cum Laude";
            }
            else if (GPA >= 3.6)
            {
                dist = ", Magna Cum Laude";
            }
            else if (GPA >= 3.4)
            {
                dist = ", Cum Laude";
            }
            else
            {
                dist = "";
            }
            return dist;
        }

        //Assigns the new Address to the Student.
        public void SetAddress(int streetNumber, string streetName, string state, string city, int zipcode)
        {
            Address newAdd = new Address();

            newAdd.StreetNumber = streetNumber;
            newAdd.StreetName = streetName;
            newAdd.State = state;
            newAdd.City = city;
            newAdd.Zipcode = zipcode;

            Address = newAdd;
        }

        //Overrides .ToString() to write out our new student's info in the listbox.
        public override string ToString()
        {
            return FirstName + " " + LastName + ", " + Major + CalculateDistinction();
        }
    }
}