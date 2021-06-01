using System.ComponentModel.DataAnnotations;

namespace creditcardcreation.Models
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }

        public string CreditCardNumber { get; set; }

        public string Expiration { get; set; }

        public int SecurityCode { get; set; }

        public CreditCard(string CreditCardNumber, string Expiration, int SecurityCode)
        {
            this.CreditCardNumber = CreditCardNumber;
            this.Expiration = Expiration;
            this.SecurityCode = SecurityCode;
        }
    }
    
}