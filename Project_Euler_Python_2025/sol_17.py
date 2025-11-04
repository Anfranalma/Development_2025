def number_to_words(n):
    ones = ['','one','two','three','four','five','six','seven','eight','nine','ten','eleven','twelve','thirteen','fourteen','fifteen','sixteen','seventeen','eighteen','nineteen']
    tens = ['','','twenty','thirty','forty','fifty','sixty','seventy','eighty','ninety']

    if 1 <= n < 20:
        return ones[n]
    elif 20 <= n < 100:
        return tens[n//10] + ones[n %10]
    elif 100 <= n < 1000:
        return ones[n // 100] + 'hundred' + ('and'+ number_to_words(n % 100) if n % 100 != 0 else '')
    elif n == 1000:
        return 'onethousand'
    else:
        return ''
    
def total_letter_count(limit):
    return sum(len(number_to_words(i)) for i in range(1, limit +1))

print(total_letter_count(1000))