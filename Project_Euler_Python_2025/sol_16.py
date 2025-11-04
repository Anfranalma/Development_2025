import sys

sys.set_int_max_str_digits(25000)

def power_digit_sum(base,exponent):
    number = base ** exponent
    return sum(int(digit) for digit in str(number))

print(power_digit_sum(2,20000))