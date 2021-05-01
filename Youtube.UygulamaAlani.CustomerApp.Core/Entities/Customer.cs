using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.UygulamaAlani.CustomerApp.Core.Entities
{
    public sealed class Customer : BaseClass
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreateDate { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
