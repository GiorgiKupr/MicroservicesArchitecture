namespace CardManagement.Application.DTOs
{
    public class CardCreated
    {
        public Guid CardId { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
    }

}
