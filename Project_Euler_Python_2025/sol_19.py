import datetime
from datetime import date

today = date.today()

e_day = today.day
e_month = today.month
e_year = today.year

b_day = 1
b_month=1
b_year=1982
def count_sundays_on_first():
    count = 0
    for year in range(1, 2001):
        for month in range(1, 13):
            if datetime.date(year,month,1).weekday()==6:
                count+=1
    return count

def count_days_from_birth(b_day,b_month,b_year):
    
    start = date(b_year,b_month,b_day)
    end = date.today()
    delta = end - start
    return delta.days

def check_one_million(b_day,b_month,b_year):
    return 1000000-count_days_from_birth(b_day,b_month,b_year)

print(count_sundays_on_first())
print(count_days_from_birth(1,1,1))
print(check_one_million())