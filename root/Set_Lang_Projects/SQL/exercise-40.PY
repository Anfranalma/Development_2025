valor = 1234

chares = []

def calcule(valor):

    for x in range(len(str(valor))):
        chares.append(str(valor)[x])

    sum =0
    for y in range(len(chares)):
        sum += int(chares[y])**4
    
    return sum

values_eva=[]
for x in range(1000,10000):
    result = calcule(x)
    print(result)

