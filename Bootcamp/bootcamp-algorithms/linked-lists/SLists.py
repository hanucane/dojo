class Node:
    def __init__(self, value):
        self.value = value
        self.next = None
        self.prev = None

class SList:
    def __init__(self, value):
        node = Node(value)
        self.head = node
    def printAllValues(self):
        runner = self.head
        while runner.next != None:
            print(id(runner), runner.value, id(runner.next))
            runner = runner.next
        print(id(runner), runner.value, id(runner.next))
    def addNode(self, value):
        node = Node(value)
        runner = self.head
        while runner.next != None:
            runner = runner.next
        runner.next = node
    def removeNode(self, value):
        runner = self.head
        prev = None
        if runner != None:
            if runner.value == value:
                self.head = runner.next
                runner = None
                return
        while runner != None:
            if runner.value == value:
                break
            prev = runner
            runner = runner.next      
        if runner == None:
            return
        
        prev.next = runner.next
        runner = None

slist = SList(5)
slist.addNode(7)
slist.addNode(3)
slist.addNode(8)
slist.printAllValues()
slist.removeNode(7)
slist.removeNode(5)
slist.printAllValues()
slist.addNode(10)
slist.addNode(2)
slist.printAllValues()