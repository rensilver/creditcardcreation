using System;
using System.ComponentModel.DataAnnotations;

namespace creditcardcreation.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public int CreditCardId { get; set; }

        public CreditCard CreditCard { get; set; }

         public Client() 
         {
         
         }

        public Client(string email) 
         {
             this.Email = email;
         }

     }

    

}