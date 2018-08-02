using System;

namespace Phone
{
    public class Galaxy : Phone, IRingable 
    {
        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
            : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring() 
        {
            string ring = "... "+this._ringTone+" ...";
            return ring;
        }
        
        public string Unlock() 
        {
            string unlock = this._versionNumber+" unlocked with passcode";
            return unlock;
        }
        public override void DisplayInfo() 
        {
            Console.WriteLine("##################################");
            Console.WriteLine(this._versionNumber);         
            Console.WriteLine(this._batteryPercentage); 
            Console.WriteLine(this._carrier); 
            Console.WriteLine(this._ringTone);   
            Console.WriteLine("##################################");           
        }
    }
        
}