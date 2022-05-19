using System;
using System.ComponentModel.DataAnnotations;

namespace publisher.Models.Report
{
	public class ReportModel
	{
		[Key]
		public int Id { get; set; }
		public DateTime Date { get; set; }
		[Required]
		public string? Report { get; set; }
	}
}

