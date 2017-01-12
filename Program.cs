using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Person
    {
        private string _firstname;

        public string Firstname
        {
            get{return _firstname;}
            set{_firstname = value;}
        }

       private string _surname;

       public string Surname
       {
           get{return _surname;}
           set{ _surname = value;}
       }

       private DateTime _dob;

       public DateTime Dob
       {
           get{return _dob;}
           set{_dob = value;}
       }

       public int Age
       {
           get
           {
               // Save today's date
               var today = DateTime.Today;
               // Calculate the age
               var age = today.Year - this.Dob.Year;
               if (this.Dob > today.AddYears(-age))
               {
                   age--;
               }
               return age;
           }
       }
    }    
class Program
    {
        static List<Person> people;
        
        static void Main(string[] args)
        {
            if (people == null)
            {
                people = new List<Person>();
            }

            createTestUsers();
            printListOfUsers();
            waitForKeypress();
        }

        static void createTestUsers()
        {
            // Create a person
            Person p1 = new Person();
            // Access and assign the new person's Firstname property to a string
            p1.Firstname = "Joseph";
            p1.Surname = "Barrett-Mead";
            // Create a string that is what we expect the date to be
            string p1dob = "16/07/1999";
            // Create a datetime variable and store the converted string
            DateTime dt1 = Convert.ToDateTime(p1dob);
            // Assign the DateTime variable to the p1 instance of the Person object
            p1.Dob = dt1;
            // Add the person to the list
            people.Add(p1);

            Person p2 = new Person();
            p2.Firstname = "Summer";
            p2.Surname = "Venning";
            DateTime dt2 = Convert.ToDateTime("03/08/2002");
            p2.Dob = dt2;
            people.Add(p2);
        }

        static void printListOfUsers()
        {
            // Interates through the people list and prints their details
            foreach (var person in people)
            {
               Console.WriteLine(String.Format("{0} {1} date of birth is {2} and they are {3}",
                   person.Firstname, person.Surname,
                   person.Dob.ToString("dd/MM/yyyy"), person.Age));
            }
        }

        static void waitForKeypress()
        {
            Console.WriteLine("Press a key to continue ... ");
            Console.ReadKey();
        }
    }
}
