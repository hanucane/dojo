class Car:
    def __init__(self, price, speed, fuel, mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        self.tax = self.setTax()
        # or 
        # if self.price > 10000:
        #     self.tax = 0.15
        # else:
        #     self.tax = 0.12
    def setTax(self):
        if self.price > 10000:
            return 0.15
        else:
            return 0.12
        return self
    def display_all(self):
        print(f"Price: {self.price}")
        print(f"Speed: {self.speed}")
        print(f"Fuel: {self.fuel}")
        print(f"Mileage: {self.mileage}")
        print(f"Tax: {self.tax}")
        print("-"*50)
        return self

car1 = Car(2000, "35mph", "Full", "15mpg")
car2 = Car(2000, "5mph", "Not full", "105mpg")
car3 = Car(2000, "15mph", "Kind of Full", "95mpg")
car4 = Car(2000, "25mph", "Full", "25mpg")
car5 = Car(2000, "45mph", "Empty", "25mpg")
car6 = Car(20000000, "35mph", "Empty", "15mpg")

car1.display_all()
car2.display_all()
car3.display_all()
car4.display_all()
car5.display_all()
car6.display_all()