using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RPGCharacterCreator.Models
{
    public class Character
    {
        public Character()
        {
            MaxPoints = 15;
            ClassChoices = new SelectList(new string[] { "Mage", "Knight", "Rouge" });

            this.CharacterSkill = new HashSet<Character_Skill>();
        }
        
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Name")]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Class Choice")]
        public string ClassChoice { get; set; }

        public IEnumerable<SelectListItem> ClassChoices { get; set; }
        
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

        [Display(Name="Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public System.DateTime? CreationDate { get; set; }

        [HiddenInput]
        public int MaxPoints { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Character_Skill> CharacterSkill { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}