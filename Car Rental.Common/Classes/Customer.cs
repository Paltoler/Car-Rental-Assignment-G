using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public int SSN { get; set; }
        public string LastName { get; set ; }
        public string FirstName { get; set ; }

        public Customer(int id, int ssn, string lastName, string firstName) => (Id, SSN , LastName, FirstName) = (id, ssn, lastName, firstName);
        public Customer()    { }           
        
    }
}
