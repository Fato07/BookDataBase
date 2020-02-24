using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Display(Name="Given Name")]
        [MaxLength(128, ErrorMessage = "Max length for {0} is {1}")] 
        [MinLength(2, ErrorMessage = "Min length for {0} is {1}")] 
        public string FirstName { get; set; } = default!;
        
        [Display(Name="Family Name", Prompt="Enter the Family Name here...")]
        [MaxLength(128, ErrorMessage = "Max length for {0} is {1}")] 
        [MinLength(2, ErrorMessage = "Min length for {0} is {1}")] 
        public string LastName { get; set; } = default!;

        [Display(Name="Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public DateTime YearOfBirth { get; set; }

        public ICollection<BookAuthor>? AuthorBooks { get; set; }

        [Display(Name="Full Name")]
        public string FirstLastName => FirstName + " " + LastName;
        [Display(Name="Full Name")]
        public string LastFirstName => LastName + " " + FirstName;
    }
}