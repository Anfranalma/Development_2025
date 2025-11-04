ALL_SPACES = ['1','2','3','4','5','6','7','8','9']
X, O, BLANK = 'X','O',' ' 

def main():
    print('Welcome to Tic-Tac-Toe!')
    gameBoard= getBlankBoard()
    currentPlayer, nextPlayer = X,O

    while True:
        #Display the board on the screen
        print(getBoardStr(gameBoard))

        move= None
        while not isValidSpace(gameBoard, move):
            print('What is {}\s move? (1-9)'.format(currentPlayer))
            move = input('> ')
        updateBoard(gameBoard, move, currentPlayer)

        if isWinner(gameBoard,currentPlayer):
            print(getBoardStr(gameBoard))
            print(currentPlayer + ' has won the game!')
            break
        elif isBoardFull(gameBoard):
            print(getBoardStr(gameBoard))
            print('The game is a tie!')
            break
        currentPlayer, nextPlayer = nextPlayer, currentPlayer
        print('Thanks for playing!')

def getBlankBoard():
    'create a new board'
    board = {}
    for space in ALL_SPACES:
        board[space] = BLANK
    return board

# def getBoardStr(board):
#     '''Return a text representation of the board'''
#     return '''
#         {}|{}|{} 1 2 3
#         -+-+-
#         {}|{}|{} 4 5 6
#         -+-+-
#         {}|{}|{} 7 8 9
#     '''.format(board['1'], board['2'], board['3'],
#                board['4'], board['5'], board['6'],
#                board['7'], board['8'], board['9'])

def getBoardStr(board):
    """Return a text representation of the board dynamically."""
    rows = [
        " {} | {} | {} ".format(board[str(i)], board[str(i+1)], board[str(i+2)])
        for i in range(1, 10, 3)
    ]
    return "\n---+---+---\n".join(rows)

def isValidSpace(board,space):
    """Return Ture if the space on the board is a valid space number and the space is blank."""
    return space in ALL_SPACES and board[space] == BLANK

# def isWinner(board,player):
#     '''Return True if player is a winner on this TTTBoard'''
#     b, p = board, player
#     #Check for 3 marks accross 3 rows, 3 columns and 2 diagonals
#     return ((b['1'] == b['2'] == b['3'] ==p) or
#             (b['4'] == b['5'] == b['6'] ==p) or
#             (b['7'] == b['8'] == b['9'] ==p) or
#             (b['1'] == b['4'] == b['7'] ==p) or
#             (b['2'] == b['5'] == b['8'] ==p) or
#             (b['3'] == b['6'] == b['9'] ==p) or
#             (b['1'] == b['5'] == b['9'] ==p) or
#             (b['3'] == b['5'] == b['7'] ==p)) 

def isWinner(board, player):
    """Return True if the player has won the game dynamically."""
    size = 3  # Change this to support larger Tic-Tac-Toe boards
    winning_combinations = []

    # Generate row and column winning combinations
    for i in range(size):
        row = [str(i * size + j + 1) for j in range(size)]  # Row indexes
        col = [str(j * size + i + 1) for j in range(size)]  # Column indexes
        winning_combinations.append(row)
        winning_combinations.append(col)

    # Generate diagonal winning combinations
    diag1 = [str(i * size + i + 1) for i in range(size)]
    diag2 = [str(i * size + (size - i) + (size - 2)) for i in range(size)]
    winning_combinations.append(diag1)
    winning_combinations.append(diag2)

    # Check if player occupies all positions in any winning combination
    return any(all(board[pos] == player for pos in combo) for combo in winning_combinations)

def isBoardFull(board):
    """Return True if every space on the board has been taken"""
    return all(board[space] != BLANK for space in ALL_SPACES)
    
def updateBoard(board, space, mark):
    board[space] = mark

if __name__ == '__main__':
    main()
