using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace pc_02.Models
{

    [Table("accounts")]
    public class Account
    {

        public enum ACCOUNT_TYPES
        {
            SAVING,
            MMA,
            CD
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public int CurrentBlance { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string AccountOwner { get; set; }

        [Required]
        public required ACCOUNT_TYPES AccountType { get; set; } = ACCOUNT_TYPES.SAVING;
    }
}