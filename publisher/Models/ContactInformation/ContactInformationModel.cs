using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace publisher.Models.ContactInformation
{
	public class ContactInformationModel
	{
		
        public enum ContactInformationType
        {
            Phone,
            Email,
            Location
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public ContactInformationType Type { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage = "Content max length 100")]
        public string Content { get; set; }

        [Required]
        public Guid ContactId { get; set; }
    }
}

