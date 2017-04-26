using System;
using System.ComponentModel.DataAnnotations;
using OrangeBricks.Framework.Enumerations;

namespace OrangeBricks.DataAccess.Models
{
	public class Offer
	{
		[Key]
		public int Id { get; set; }

		public int Amount { get; set; }

		public OfferStatus Status { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }
	}
}