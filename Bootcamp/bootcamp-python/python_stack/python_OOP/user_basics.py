class User:
    # the __init__ method is called every time a new object is created
    def __init__(self, name, email):
        # set some instance of variables
        self.name = name
        self.email = email
        self.logged = False
    def login(self):
        self.logged = True
        print(self.name + " is logged in.")
        return self
    def logout(self):
        self.logged = False
        print(self.name + " is logged out.")
        return self
    def show(self):
        print(f"My name is {self.name}. You can email me at {self.email}.")
        return self
    
user1 = User("Anna", "anna@gmail.com")
user1.login().show().logout()