using CarAdverts.Common.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarAdverts.Models
{
    public class User : IdentityUser
    {
        private ICollection<Advert> adverts;

        public User()
        {
            this.adverts = new HashSet<Advert>();
        }

        [MinLength(ValidationConstants.UserFirstNameMinLength)]
        [MaxLength(ValidationConstants.UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(ValidationConstants.UserLastNameMinLength)]
        [MaxLength(ValidationConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Advert> Adverts
        {
            get
            {
                return this.adverts;
            }

            set
            {
                this.adverts = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
