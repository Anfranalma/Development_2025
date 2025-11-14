def separate_string(t,word):
    T = t
    for i in range(T):        
        odd = []
        even = []
        for i in range(len(word)):
            if(i==0 or i % 2 == 0):
                even.append(word[i])
            else:
                odd.append(word[i])
        print(T)
        print(odd.join(','))
        print(even.join(','))

    separate_string(3, "abcdef")