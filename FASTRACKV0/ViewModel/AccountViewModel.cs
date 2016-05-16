using FASTrack.Model.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    public class AccountViewModel : BaseDto
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "FirstName is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The length of Firstname in range 1 to 50 chars!")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Lastname is required!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The length of LastName in range 1 to 50 chars!")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Site Location")]
        [Required]
        public int SiteId { get; set; }
        [Display(Name = "Site")]
        public IEnumerable<SitesDto> Site { get; set; }

        [Display(Name = "Role")]
        [Required]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<SYSRolesDto> Role { get; set; }

        [Display(Name = "Register Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}