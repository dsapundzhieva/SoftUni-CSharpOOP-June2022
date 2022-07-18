
namespace Cards
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Card
        {
            private readonly List<string> cardFaces;
            private readonly Dictionary<string, char> cardSuits;
            private string face;
            private string suit;

            public Card()
            {
                this.cardFaces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

                this.cardSuits = new Dictionary<string, char>
                {
                    {"S", '\u2660'},
                    {"H", '\u2665'},
                    {"D", '\u2666'},
                    {"C", '\u2663'}
                };
            }
            public Card(string face, string suit)
                : this()
            {
                this.Face = face;
                this.Suit = suit;
            }
            public string Face
            {
                get
                {
                    return this.face;
                }
                set
                {
                    if (!this.cardFaces.Contains(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    this.face = value;
                }
            }

            public string Suit
            {
                get
                {
                    return this.suit;
                }
                set
                {
                    if (!this.cardSuits.ContainsKey(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    this.suit = value;
                }
            }

            public override string ToString()
            {
                return $"[{this.Face}{cardSuits[this.Suit]}] ";
            }
        }

        static void Main(string[] args)
        {
            string[] deck = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Card> deckResult = new List<Card>();

            for (int i = 0; i < deck.Length; i += 2)
            {
                try
                {
                    string face = deck[i];
                    string suit = deck[i + 1];

                    Card card = new Card(face, suit);

                    deckResult.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            foreach (var card in deckResult)
            {
                Console.Write(card);
            }
        }
    }
}
