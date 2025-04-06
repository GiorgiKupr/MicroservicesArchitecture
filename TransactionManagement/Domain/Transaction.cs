using System.Transactions;

namespace Domain
{
    public class Transaction
    {
        public Guid TransactionId { get;  set; }  // Unique identifier for the transaction
        public Guid CardId { get;  set; }  // Card ID associated with this transaction
        public decimal Amount { get;  set; }  // Transaction amount
        public string Type { get;  set; }  // Debit or Credit transaction
        public string Status { get;  set; }  // Status of the transaction - processed, failed, pending.
        public DateTime Timestamp { get;  set; }  // Time when the transaction occurred
        public string Description { get;  set; }  // Description for the transaction (e.g., purchase, deposit)
        public string FailureReason { get;  set; }  // Reason for failure (if any)

    }
}