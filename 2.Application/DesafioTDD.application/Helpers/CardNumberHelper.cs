using System;

namespace DesafioTDD.application.Helpers
{
    public class CardNumberHelper
    {
        public string GenerateCardNumber(string prefix)
        {
            Random random = new Random();

            string cardNumber = "";

            var prefixes = prefix.Split('-');
            var FirstPart = prefixes[random.Next(0, prefixes.Length)];
            cardNumber = cardNumber.Insert(0, FirstPart);

            var SecondPart = GenerateFourRandom();
            cardNumber = cardNumber.Insert(4, SecondPart);

            var thirdPart = GenerateFourRandom();
            cardNumber = cardNumber.Insert(8, thirdPart);

            var LastPart = GenerateFourRandom();
            cardNumber = cardNumber.Insert(12, LastPart);

            return cardNumber;
        }

        public string GenerateFourRandom()
        {
            Random random = new Random();

            var randomFourDigits = random.Next(0, 9).ToString();
            randomFourDigits = randomFourDigits.Insert(1, random.Next(0, 9).ToString());
            randomFourDigits = randomFourDigits.Insert(2, random.Next(0, 9).ToString());
            randomFourDigits = randomFourDigits.Insert(3, random.Next(0, 9).ToString());

            return randomFourDigits;
        }
    }
}