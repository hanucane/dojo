class Bike:
    def __init__(self, name, price, max_speed, miles):
        self.name = name
        self.price = price
        self.max_speed = max_speed
        self.miles = miles
    def displayInfo(self):
        print(f"{self.name} bike cost is {self.price}. It has a max speed of {self.max_speed} and a total mileage of {self.miles}.")
        return self
    def ride(self):
        print("Riding")
        self.miles = self.miles + 10
        return self
    def reverse(self):
        print("Reversing")
        if self.miles > 5:
            self.miles = self.miles - 5
        else: 
            print("Bike can not reverse any farther.")
        return self

bike1 = Bike("Schwinn", "$200", "40 miles per hour", 0)
bike1.displayInfo()
bike1.ride().ride().ride().displayInfo()
bike1.ride().ride().reverse().reverse().displayInfo()
bike1.reverse().reverse().reverse().displayInfo()