#longuest collatz chain
import math

def collatz_length(n, cache):
    original = n
    lenght = 0
    while n!=1:
        if n in cache:
            lenght += cache[n]
            break
        if n % 2 == 0:
            n //= 2
        else:
            n = 3 * n +1
        lenght += 1
    cache[original] = lenght
    return lenght


def longest_collatz(limit):
    max_length = 0
    number =0
    cache = {}
    for i in range(1, limit):
        lenght = collatz_length(i,cache)
        if lenght > max_length:
            max_length = lenght
            number = i
    return number

print(longest_collatz(1000000))