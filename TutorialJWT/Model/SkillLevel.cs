using System;
using System.Collections.Generic;

#nullable disable

namespace TutorialJWT.Model
{
    public partial class SkillLevel
    {
        public SkillLevel()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillLevelId { get; set; }
        public string SkillLevelName { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
