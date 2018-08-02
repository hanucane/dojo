using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            Console.WriteLine("Card Dealt: "+newDeck.Deal().stringVal);
            Console.WriteLine("Deck Count: "+newDeck.deck.Count);
            newDeck.Reset();
            Console.WriteLine("Deck Reset: "+newDeck.deck.Count);
            newDeck.Shuffle();
            Console.WriteLine("Shuffled Deck Top Card: "+newDeck.deck[0].stringVal);
            Player player1 = new Player("John");
            player1.Draw(newDeck);
            Console.WriteLine("Player First Card: "+player1.hand[0].suit+" "+player1.hand[0].stringVal);
            Console.WriteLine("Player discards: "+player1.Discard().stringVal);
        }
    }
}
