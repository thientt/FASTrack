using FASTrack.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class UserViewModel : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegistedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MSTDepartmentDto> Departments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SitesDto> Sites { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SYSRolesDto> Roles { get; set; }
    }
}