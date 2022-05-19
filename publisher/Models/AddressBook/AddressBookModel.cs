using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using publisher.Models.ContactInformation;

namespace publisher.Models.AddressBook
{
	public class AddressBookModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage="Name max length is 50")]
		public string Name { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Last Name max length is 50")]
		public string LastName { get; set; }


		[MaxLength(50, ErrorMessage = "Firm max length is 50")]
		public string? Firm { get; set; }

		
		public List<ContactInformationModel>? ContactInformation {get; set;}
	}
}

