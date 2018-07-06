class MathDojo:
    def __inti__(self):
        self.result = 0
    def add(self,*args):
        for num in args:
            self.result += num
        return self
    def subtract(self, *args):
        for num in args:
            self.result -= num
        return self
    
md = MathDojo()

print(md.result)
md.add(10,30).subtract(3,6,3)
print(md.result)