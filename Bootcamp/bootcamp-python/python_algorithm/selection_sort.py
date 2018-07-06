def selectionSort(arr):
    for fill in range(len(arr)-1,0,-1):
        maxIndex=0
        for position in range(1,fill+1):
            if arr[position] > arr[maxIndex]:
                maxIndex = position
        temp = arr[fill]
        arr[fill] = arr[maxIndex]
        arr[maxIndex] = temp
    return arr

print(selectionSort([89,32,51,64,42]))
        