namespace Task4API.CQRS.CommandDB.DTO
{
    public class ClientDTO
    {
        public string Sid { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool? IsActive { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
