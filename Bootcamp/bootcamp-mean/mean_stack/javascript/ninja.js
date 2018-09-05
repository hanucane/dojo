var makeNinja = function(name)
{
    this.name = name;
    this.health = 100;
    var speed = 3;
    var strength = 3;
    this.drinkSake = function()
    {
        this.health += 10;
        console.log("Delicious Sake replenishes health")
    }
    this.sayName = function()
    {
        console.log("My ninja name is "+this.name);
    }
    this.showStats = function()
    {
        console.log("Name: "+this.name+", Health: "+this.health+", Speed: "+speed+", Strength: "+strength);
    }
}
var ninja1 = new makeNinja("Ip");
ninja1.sayName();
ninja1.showStats();
ninja1.drinkSake();
ninja1.showStats();