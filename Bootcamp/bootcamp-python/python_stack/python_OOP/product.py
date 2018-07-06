class Product:
    def __init__(self, name, price, weight, brand):
        self.name = name
        self.price = price
        self.weight = weight
        self.brand = brand
        self.status = "For sale"
    def sell(self):
        self.status = "Sold"
        return self
    def addTax(self, taxRate):
        self.price += self.price * taxRate
        return self
    def returnProduct(self, reason_for_return):
        if reason_for_return == "defective":
            self.price = 0
            self.status = "Defective"
        elif reason_for_return == "like_new":
            self.status = "Like New"
        elif reason_for_return == "opened":
            self.price -= (self.price * .2)
            self.status = "Used"
        return self
    def displayInfo(self):
        print("-"*50)
        print(f"Item: {self.name}")
        print(f"Price: {self.price}")
        print(f"Weight: {self.weight}")
        print(f"Brand: {self.brand}")
        print(f"Status: {self.status}")
        print("-"*50)
        return self

shoes = Product("Running Shoes", 50, "3 pounds", "Nike")
shoes.displayInfo().addTax(.01).sell().displayInfo().returnProduct('like_new').displayInfo().returnProduct('opened').displayInfo().returnProduct('defective').displayInfo()