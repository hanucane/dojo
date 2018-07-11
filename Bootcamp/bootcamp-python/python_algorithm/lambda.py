def map(list, function):
    for i in range(len(list)):
        list[i] = function(list[i])
    return list

print( map([1,2,3,4], (lambda num: num*num) ))
print( map([1,2,3,4], (lambda num: num*3) ))
print( map([1,2,3,4], (lambda num: num%2) ))