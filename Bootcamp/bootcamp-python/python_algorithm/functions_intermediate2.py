x = [ [5,2,3], [10,8,9] ] 
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

x[1][0] = 15
print(x)

students[0]['last_name'] = "Bryant"
print(students)

sports_directory['soccer'][0] = "Andres"
print(sports_directory)

z[0]['y'] = 30
print(z)

def classnames(students):
    for count in range(len(students)):
        print("first_name - ", students[count]['first_name']+", last_name - ", students[count]['last_name'])
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]
classnames(students)

def firstnames(students):
    for count in range(len(students)):
        print(students[count]['first_name'])
firstnames(students)

dojo = {
   'location': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}
def printDojoInfo(dojo):
    total_loca = len(dojo['location'])
    total_instructors = len(dojo['instructors'])
    print(total_loca, "LOCATIONS")
    for count in range(len(dojo['location'])):
        print(dojo['location'][count])
    print(total_instructors, "INSTRUCTORS")
    for count in range(len(dojo['instructors'])):
        print(dojo['instructors'][count])
printDojoInfo(dojo)