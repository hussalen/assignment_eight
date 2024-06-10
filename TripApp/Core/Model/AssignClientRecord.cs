using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_eight.TripApp.Core.Model
{
    public record AssignClientRecord
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string Pesel { get; set; }
    }
}
