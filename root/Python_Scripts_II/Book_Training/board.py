test = [
    ['','','','','','',''],
    ['','','','','','',''],
    ['','','','','','',''],
    ['','','','','','',''],
    ['','','','','','',''],
    ['','','','','','','']
]

def valid(board):
    for i in range(len(board)):
        for j in range(len(board[i])):
            board[i][j]+=','.join([str(i),str(j)])
    return board



def print_board(board):
    for i in range(len(board)):
        print(board[i],end="\n")

print_board(valid(test))

diagonal= []
def difference(board):
    for i in range(len(board)):
        for j in range(len(board[i])):
            if (i==j or abs(i-j) ==1 or abs(j-i) ==1):
                diagonal.append(board[i][j])




def surrounding_positions(board, position):
    i, j = position
    surrounding = []
    for x in range(i-1, i+2):
        for y in range(j-1, j+2):
            if (x, y) != position and abs(x - i) == 1 and abs(y - j) == 1:
                if x != -1 and x<5 and y != -1 and y < 7:
                    surrounding.append((x, y))
    return surrounding

def position_assignment(board):
    counter = 1
    for i in range(len(board)):
        for j in range(len(board[i])):
            board[i][j] = str(counter)
            counter+=1
    return board

diagonal = []

def making_diagonal(board):
    for i in range(len(board)):
        for j in range(len(board[i])):
            diagonal.append(board[str(i+8)])


print(surrounding_positions(valid(test),(3,0)))

print(position_assignment(test))