using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWashSystemAPI.Models
{
    public class Address
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public Customer Customer { get; set; }


        [Required(ErrorMessage = "Enter your address")]
        [DataType("Varchar(255)")]
        [StringLength(100, ErrorMessage = "Must be between 10 and 255 characters", MinimumLength = 5)]
        [Display(Name = "Customer Address")]
        public string CustAddress { get; set; }



        [Required(ErrorMessage = "Enter the city")]
        [DataType("Varchar(10)")]
        [StringLength(100, ErrorMessage = "Must be between 3 and 10 characters", MinimumLength = 3)]
        [Display(Name = "City")]
        public string City { get; set; }



        [Required(ErrorMessage = "Enter the state")]
        [DataType("Varchar(20)")]
        [StringLength(100, ErrorMessage = "Must be between 3 and 20 characters", MinimumLength = 3)]
        [Display(Name = "State")]
        public string State { get; set; }



        [Required(ErrorMessage = "Enter the pincode")]
        [DataType("Varchar(6)")]
        [StringLength(6, ErrorMessage = "Must be of 6 digits", MinimumLength = 6)]
        [Display(Name = "Pincode")]
        public int PinCode { get; set; }

    }
}
