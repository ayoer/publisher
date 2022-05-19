using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using publisher.Models.ContactInformation;

namespace publisher.Models.AddressBook
{
	public class AddressBookModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage="Name max length is 50")]
		public int Name { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Last Name max length is 50")]
		public int LastName { get; set; }


		[MaxLength(50, ErrorMessage = "Firm max length is 50")]
		public int Firm { get; set; }

		
		public List<ContactInformationModel>? ContactInformation {get; set;}
	}
}

