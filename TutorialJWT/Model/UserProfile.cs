using System;
using System.Collections.Generic;

#nullable disable

namespace TutorialJWT.Model
{
    public partial class UserProfile
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Bod { get; set; }
        public string Email { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
