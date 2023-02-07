using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Domain.Enums;

namespace Sat.Recruiment.Domain.Models
{
    /// <summary>
    /// Entity User
    /// </summary>
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public UserType UserType { get; private set; }
        public decimal Money { get; private set; }

        public static User Create(string name,
            string email, 
            string address, 
            string phone, 
            UserType userType,
            Decimal money)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = money
            };
        }
    }
}
