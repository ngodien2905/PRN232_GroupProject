using Domain.Enum;

namespace Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int TeacherId { get; set; }           // FK to teachers (Auth DB)
        public decimal Amount { get; set; }          // decimal(10,2)
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    }
}
