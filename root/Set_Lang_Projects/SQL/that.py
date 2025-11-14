list = []

for x in range(2,101):
    for y in range(2,101):
        list.append(x**y)

new_list= sorted(list)
new_l=[]
[new_l.append(x) for x in new_list if x not in new_l]
print(new_l)
print(len(new_l))