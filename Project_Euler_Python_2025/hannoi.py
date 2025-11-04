import copy
import sys

TOTAL_DISKS = 5
COMPLETE_TOWER = list(range(TOTAL_DISKS, 0, -1))

def main():
    print("Hanoi Tower, created by myself")

    towers = {'A': copy.copy(COMPLETE_TOWER), 'B': [], 'C': []}

    while True:
        displayTowers(towers)
        fromTower, toTower = askForPlayerMove(towers)

        disk = towers[fromTower].pop()
        towers[toTower].append(disk)

        if towers['B'] == COMPLETE_TOWER or towers['C'] == COMPLETE_TOWER:
            displayTowers(towers)
            print('You have solved the puzzle! Well done!')
            sys.exit()

def askForPlayerMove(towers):
    """Ask the player for a move. Return (fromTower, toTower)."""
    while True:
        print('Enter the letters of "from" and "to" towers, or QUIT.')
        print('(E.g., AB to move a disk from tower A to tower B.)')
        response = input('> ').upper().strip()

        if response == 'QUIT':
            print('Thanks for playing!')
            sys.exit()

        if response not in ('AB', 'AC', 'BA', 'BC', 'CA', 'CB'):
            print('Enter one of AB, AC, BA, BC, CA, or CB.')
            continue

        fromTower, toTower = response[0], response[1]

        if len(towers[fromTower]) == 0:
            print('You selected a tower with no disks.')
            continue
        elif len(towers[toTower]) == 0:
            return fromTower, toTower
        elif towers[toTower][-1] < towers[fromTower][-1]:
            print("Can't put larger disks on top of smaller ones.")
            continue
        else:
            return fromTower, toTower

def displayTowers(towers):
    """Display the current state of the towers."""
    for level in range(TOTAL_DISKS - 1, -1, -1):
        for tower in ('A', 'B', 'C'):
            if level < len(towers[tower]):  # Check if the level exists in the tower
                displayDisk(towers[tower][level])
            else:
                displayDisk(0)  # Empty level
        print()  # Move to the next row

    emptySpace = ' ' * TOTAL_DISKS
    print('{0} A {0}{0} B {0}{0} C\n'.format(emptySpace))

def displayDisk(width):
    """Display a disk of the given width. A width of 0 means no disk."""
    emptySpace = ' ' * (TOTAL_DISKS - width)

    if width == 0:
        print(emptySpace + '||' + emptySpace, end=' ')
    else:
        disk = '@' * width
        numLabel = str(width).rjust(2, '_')
        print(emptySpace + disk + numLabel + disk + emptySpace, end=' ')

if __name__ == '__main__':
    main()
