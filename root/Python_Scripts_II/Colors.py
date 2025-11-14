
import random
from termcolor import colored

colors = ['red', 'green', 'blue', 'yellow', 'magenta', 'cyan','white']

text = "Rainbow Python"

for char in text:
    color = random.choice(colors)
    print(colored(char, color), end="")

print()