using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTDD.domain.Entities;

namespace DesafioTDD.application.Helpers
{
    public class CardNumberHelper
    {
        public string GenerateCardNumber(string prefix)
        {
            Random random = new Random();

            string cardNumber = "";

            var prefixes = prefix.Split("-");
            var FirstPart = prefixes[random.Next(0, prefix.Count())];
            cardNumber.Concat(FirstPart);

            var SecondPart = GenerateFourRandom();
            cardNumber.Concat(SecondPart);

            var thirdPart = GenerateFourRandom();
            cardNumber.Concat(thirdPart);

            var LastPart = GenerateFourRandom();
            cardNumber.Concat(LastPart);

            return cardNumber;
        }

        private string GenerateFourRandom()
        {
            Random random = new Random();

            var randomFourDigits = random.Next(0, 9).ToString();
            randomFourDigits.Concat(random.Next(0, 9).ToString());
            randomFourDigits.Concat(random.Next(0, 9).ToString());
            randomFourDigits.Concat(random.Next(0, 9).ToString());

            return randomFourDigits;
        }
    }
}