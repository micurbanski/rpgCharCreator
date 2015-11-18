using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGCharacterCreator.Models
{
    public class Character
    {
        public Character()
        {
            MaxPoints = 15;
            ClassChoices = new SelectList(new string[] { "Mage", "Knight", "Rouge" });
            ClassChoice = ClassChoices.Skip(1).First().ToString();

            this.CharacterSkill = new HashSet<CharacterSkill>();
        }
        
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Name")]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Class Choice")]
        public string ClassChoice { get; set; }
        
        public SelectList ClassChoices { get; set; }
        
        [Required]
        [Display(Name="Strength")]
        [Range(0, 10, ErrorMessage="Incorrect value")]
        public int StrengthPoints { get; set; }
        
        [Required]
        [Display(Name = "Intelligence")]
        [Range(0, 10, ErrorMessage = "Incorrect value")]
        public int IntelligencePoints { get; set; }
        
        [Required]
        [Display(Name = "Agility")]
        [Range(0, 10, ErrorMessage = "Incorrect value")]
        public int AgilityPoints { get; set; }

        [HiddenInput]
        public int MaxPoints { get; set; }


        public int UserId { get; set; }

        public virtual ICollection<CharacterSkill> CharacterSkill { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}