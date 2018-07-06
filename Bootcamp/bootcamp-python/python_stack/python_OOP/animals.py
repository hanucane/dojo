class Animal:
    def __init__(self, name):
        self.name = name
        self.health = 100
    def walk(self):
        print("Walking")
        self.health -= 1
        return self
    def run(self):
        print("Running")
        self.health -= 5
        return self
    def displayHealth(self):
        print(f"Health: {self.health}")
        return self

animal1 = Animal("puppy")
animal1.walk().walk().walk().run().run().displayHealth()

class Dog(Animal):
    def __init__(self, name):
        Animal.__init__(self,name)
        self.health = 150
    def pet(self):
        print("Petting")
        self.health += 5
        return self

dog1 = Dog(Animal)
dog1.walk().walk().walk().run().run().pet().displayHealth()

class Dragon(Animal):
    def __init__(self, name):
        Animal.__init__(self, name)
        self.health = 170
    def fly(self):
        print("Flying")
        self.health -= 10
        return self
    def dragonHealth(self):
        super().displayHealth()
        print("I am a Dragon")
        return self

dragon1 = Dragon(Animal)
dragon1.fly().fly().dragonHealth()