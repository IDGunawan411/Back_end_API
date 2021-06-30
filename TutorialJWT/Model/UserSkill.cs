using System;
using System.Collections.Generic;

#nullable disable

namespace TutorialJWT.Model
{
    public partial class UserSkill
    {
        public int UserSkillId { get; set; }
        public string Username { get; set; }
        public int? SkillId { get; set; }
        public int? SkillLevelId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual SkillLevel SkillLevel { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
