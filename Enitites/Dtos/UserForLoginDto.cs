using Core.Enitities;

namespace Enitites.Dtos
{
    public class UserForLoginDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
