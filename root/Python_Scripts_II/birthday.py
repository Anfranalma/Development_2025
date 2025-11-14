import datetime, random

def getBirhdays(numberOfBirthdays):
    """Return a list of numbers random date objects for birhday"""
    birthdays = []

    for i in range(numberOfBirthdays):
        #The year is not important as long as all the people have the same year of birth
        startOfYear = datetime.date(2001,1,1)

        #Get random day into the year
        randomNumberOfDays = datetime.timedelta(random.randint(0,364))
        birthday = startOfYear + randomNumberOfDays
        birthdays.append(birthday)
    return birthdays


def getMatch(birthdays):
    """Return the date object of a birthday that occurs more than once"""
    if len(birthdays) == len(set(birthdays)):
        return None 
    
    #Compare each birthday to every other birthday:
    for a, birthdayA in enumerate(birthdays):
        for b, birthdayB in enumerate(birthdays[a + 1 :]):
            if birthdayA == birthdayB:
                return birthdayA #return the matching birthday
            
#Display the intro:
print('''Birthday Paradox''')

"""The brithday paradox shows us that in a group of N people, the odds
that 2 or them have matching birthdays is surprisingly large.\
    This program does a Monte Carlo simulation (that is, repeated)"""

#set a tuple of month names in order:

MONTHS = ('')