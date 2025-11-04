import math

def find_triplet(target_sum):
    for a in range(1,target_sum):
        for b in range(a+1, target_sum - a):
            c = target_sum - a - b
            if a * a + b * b == c*c:
                return a * b * c
    return None

print(find_triplet(1000))