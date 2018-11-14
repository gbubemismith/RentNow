using RentNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentNow.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }

    }
}