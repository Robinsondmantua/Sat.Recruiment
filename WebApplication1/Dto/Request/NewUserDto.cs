using Sat.Recruiment.Api.Enums;

namespace Sat.Recruiment.Api.Dto.Request
{
    public class NewUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }
    }
}
