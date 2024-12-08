namespace API.Models
{
    /*
     Relationships
        User ↔ Expense: One user has many expenses.
        User ↔ Category: One user has many categories (if user-specific categories are allowed).
        Category ↔ Expense: One category has many expenses.
        User ↔ Budget: One user has multiple budgets.
        User ↔ Income: One user has multiple income records.
     */
    public class Income
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; } // income source
        public DateTime DateReceived { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
