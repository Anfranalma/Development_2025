import math

def lattice_paths(n):
    return math.comb(2*n,n)

print(lattice_paths(20))