using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Player
    {
        public string name;
        public List<Card> hand { get; set; } = new List<Card>();
        public Player(string _name)
        {
            name = _name;
        }
        public void Draw(Deck deck)
        {
            hand.Add(deck.Deal());
        }
        public Card Discard()
        {
            if (hand.Count == 0) {
                return null;
            }
            else {
                Card temp = hand[0];
                hand.Remove(temp);
                return temp;
            }
        }
    }
}