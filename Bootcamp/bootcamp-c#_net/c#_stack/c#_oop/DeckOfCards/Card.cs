namespace DeckOfCards
{
    public class Card 
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string _stringVal, string _suit, int _val)
        {
            stringVal = _stringVal;
            suit = _suit;
            val = _val;
        }
    }

}