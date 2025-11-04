import math

def factorial_digit_sum(n):
    number = math.factorial(n)
    return sum(int(d) for d in str(number))


print(factorial_digit_sum(100))