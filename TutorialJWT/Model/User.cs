using System;
using System.Collections.Generic;

#nullable disable

namespace TutorialJWT.Model
{
    public partial class User
    {
        public User()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
