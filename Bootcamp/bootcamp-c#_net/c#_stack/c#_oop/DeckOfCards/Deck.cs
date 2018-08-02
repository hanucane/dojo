using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Deck 
    {
        public List<Card> deck { get; set; } = new List<Card>();
        public int currentCard;
        public string[] stringVal = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
        public string[] suits = {"Hearts","Clubs","Diamonds","Spades"};
        public int[] val = {1,2,3,4,5,6,7,8,9,10,11,12,13};
         
        public Deck()
        {    
            currentCard = 0;
            for (int suit = 0; suit < suits.Length; suit++){
                for (int strVal = 0; strVal < stringVal.Length; strVal++){
                    string _suit = suits[suit];
                    string _stringVal = stringVal[strVal];
                    int _val = val[strVal]; 
                    deck.Add(new Card(_stringVal,_suit,_val));
                }
            }
        }
        public Card Deal()
        {
            Card temp = deck[currentCard];
            deck.Remove(temp);
            return temp;
        }
        public void Reset()
        {
            deck.Clear();
            for (int suit = 0; suit < suits.Length; suit++){
                for (int strVal = 0; strVal < stringVal.Length; strVal++){
                    string _suit = suits[suit];
                    string _stringVal = stringVal[strVal];
                    int _val = val[strVal]; 
                    deck.Add(new Card(_stringVal,_suit,_val));
                }
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < deck.Count; i++){
                int count = rand.Next(deck.Count);
                object temp = deck[i];
                deck[i] = deck[count];
                deck[count] = deck[i];
            }
        }
    }
}