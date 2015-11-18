using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGCharacterCreator.Models
{
    [Authorize]
    public class Character
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Name")]
        [StringLength(60)]
        public string Name { get; set; }

        public string ClassChoice { get; set; }
        
        //[Required]
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

        public int MaxPoints { get; set; }

        public Character()
        {
            MaxPoints = 15;
            ClassChoices = new SelectList(new string[] { "Mage", "Knight", "Rouge" });
        }


    }
}