using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGCharacterCreator.Models
{
    public class Character_Skill
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int CharacterId { get; set; }

        public virtual Character Characters { get; set; }
        public virtual Skill Skills { get; set; }
    }
}
