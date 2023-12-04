using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Doctor
	{
		[Key]
		public int Id { get; set; }
        public string UserId { get; set; }
        public Gender Gender { get; set; }
		[ForeignKey(nameof(UserId))]
		[JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public virtual List<Diagonse>? Diagonses { get; set; }
		[JsonIgnore]
		public virtual List<DoctorsViewHistory>? DoctorsViewHistories { get; set; }
    }
}
