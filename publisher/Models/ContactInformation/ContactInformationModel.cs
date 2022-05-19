using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using publisher.Models.AddressBook;
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
        [JsonIgnore]
        public AddressBookModel AddressBook { get; set; }

        public Guid AddressBookId { get; set; }

    }
}

