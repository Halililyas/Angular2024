﻿using Core.Enitities;

namespace Enitites.Dtos
{
    public class UserForRegisterDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
