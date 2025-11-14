import datetime, random

def getBirthdays(numberOfBirthdays):
    birthdays = []
    for i in range(numberOfBirthdays):
        startOfYear = datetime.date(2001,1,1)
        randomNumerOfDays = datetime.timedelta(random.randint(0,365))
        birthday = startOfYear + randomNumerOfDays
        birthdays.append(birthday)
    return birthdays
def printBirthdays(birthdays):
    for i in range(birthdays):
        return getBirthdays(i)
    

print(printBirthdays(200))
