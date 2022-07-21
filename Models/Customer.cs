using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWashSystemAPI.Models
{
    public class Customer
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [DataType("Varchar(30)")]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [DataType("Varchar(30)")]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }




        [DataType(DataType.EmailAddress, ErrorMessage = "Email Id is not valid")]
        [Required(ErrorMessage = "Please enter Email ID"), MaxLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }



        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is valid")]
        [Required(ErrorMessage = "Please enter Mobile No"), MaxLength(10)]
        [Display(Name = "Contact Number")]
        public string PhnNumber { get; set; }



        [Required(ErrorMessage = "Please enter your password"), MaxLength(15), MinLength(5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter your password"), MaxLength(15), MinLength(5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [Display(Name = "Confirm Password")]
        public string CnfPassword { get; set; }

    }
}
