using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGCharacterCreator.Models
{
    [Authorize]
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassChoice { get; set; }
        public SelectList ClassChoices { get; set; }
        public int StrengthPoints { get; set; }
        public int IntelligencePoints { get; set; }
        public int AgilityPoints { get; set; }
        public int MaxPoints { get; set; }
    }
}