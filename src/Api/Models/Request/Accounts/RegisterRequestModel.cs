﻿using System.ComponentModel.DataAnnotations;
using Bit.Core.Domains;

namespace Bit.Api.Models
{
    public class RegisterRequestModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(1000)]
        public string MasterPasswordHash { get; set; }
        [StringLength(50)]
        public string MasterPasswordHint { get; set; }
        public KeysRequestModel Keys { get; set; }

        public User ToUser()
        {
            var user = new User
            {
                Name = Name,
                Email = Email,
                MasterPasswordHint = MasterPasswordHint
            };

            if(Keys != null)
            {
                Keys.ToUser(user);
            }

            return user;
        }
    }
}
