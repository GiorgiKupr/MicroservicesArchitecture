namespace CardManagement.Domain
{
    public class Card
    {
        public Guid CardId { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
    }

}
