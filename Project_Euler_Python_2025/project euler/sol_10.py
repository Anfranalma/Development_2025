#sum of all primer number under one million

import math

def sieve_sum(limit):
    sieve = [True] * limit
    sieve[0:2] = [False,False]

    for i in range(2, int(limit ** 0.5)+1):
        if sieve[i]:
            for j in range(i * i, limit, i):
                sieve[j] = False

    return sum(i for i, is_prime in enumerate(sieve) if is_prime)

print(sieve_sum(2000000))