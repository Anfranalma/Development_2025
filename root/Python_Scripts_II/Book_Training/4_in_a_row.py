board = [
        [' ',' ',' ',' ',' ',' ',' '],
        [' ',' ',' ',' ',' ',' ',' '],
        [' ',' ',' ',' ',' ',' ',' '],
        [' ',' ',' ',' ',' ',' ',' '],
        [' ',' ',' ',' ',' ',' ',' '],
        [' ',' ',' ',' ',' ',' ',' ']
]

state = []
def board_state(x,y):
  position = str(x)+','+str(y)
  state.append(position)
  return state

def  validate_state(row,col):
  eva_pos=str(row)+','+str(col)
  if eva_pos in state:
    print("invalid positoion! Try another postion")
    return True
  else:
    return False
  

def show_board(board):
  for i in range(len(board)):
      print('+---+---+---+---+---+---+---+')
      for j in range(len(board[i])):
          print("|", board[i][j], end=" ")
      print("|")
  print('+---+---+---+---+---+---+---+')

def piece_position(piece,row,col):
  new_piece= piece.upper()
  if new_piece != "X" and new_piece!="O":
    print("There was an error!, not the right piece!")
    exit()
  else:
    if validate_state(row,col)==False:
      if row > 5 or col > 6:
        print('The value of columns or rows exceeded the set range!')
        exit()
      else:
        board[row][col] = new_piece
        print(board_state(row,col))
    
  return board

def check_winner(board, piece):
  #Check horizontal, verticial, and idagonal directions
  for row in range(len(board)):
    for col in range(len(board[row])):
      if board[row][col] == piece:
        # Check horizontal (rightwards)
        if col +3 < len(board[row]) and all(board[row][col +1] == piece for i in range(4)):
          return True
        
        #Check vertical (downwards)
        if row +3 < len(board) and all(board[row + i][col] == piece for i in range(4)):
          return True
        #Check diagonal (down-right)
        if row +3 < len(board) and col +3 < len(board[row]) and all(board[row + i][col+i] == piece for i in range(4)):
          return True
        
        #Check diagonal (down-left)
        if row+3 < len(board) and col -3 >= 0 and all(board[row+i][col -i] == piece for i in range(4)):
          return True
  return False

#Test the function after placing pieces
show_board(piece_position('X',2,5))
show_board(piece_position('X',2,4))
show_board(piece_position('X',2,3))
show_board(piece_position('X',2,2,))

#Check if 'X' is the winner
pie = ['X','O']
for i in range(len(pie)):
  if check_winner(board, pie[i]):
    print("Player {} wins!".format(pie[i]))
    break
  else:
    print("No winner yet.")

def turns(player, ):
  turn = input("Your turn player {}".format(player))
  


if __name__=="__main__":
  while True:


#Add more moves and check for other scenarios
# show_board(piece_position('O',0,0))
# show_board(piece_position('O',1,1))
# show_board(piece_position('O',2,2))
# show_board(piece_position('O',3,3))

#Check if 'O' is the winner
#if check_winner(board, 'O'):
#  print("Player O wins!")
#else:
#  print("No winner yet.")

# show_board(piece_position('X',2,5))
# show_board(piece_position('X',2,4))
# show_board(piece_position('X',1,6))
# show_board(piece_position('O',3,4))
# show_board(piece_position('O',3,7))

