import collections
point = collections.namedtuple('point', ['x', 'y'])

def read(input):
	board = {}
	y = 0
	x = 0
	p = None
	for y, cy in enumerate(input.splitlines()):
		for x, c in enumerate(list(cy)):
			if c != ' ':
			    #print(x, y, c)
				p = point(x, y)
				board[p] = c
	board['w'] = p.x +1
	board['h'] = p.y +1
	return board

def quiz1(board):
	p = findstart(board)
	word = ''
	dir = 's'
	steps = 0
	while True:
		steps += 1
		c = board.get(p)
		if c == '-' or c == '|':
			p = nextpoint(p, dir)
		elif c == '+':
			p, dir = nextpointdir(board, p, dir)
		elif p in board:
			word += c
			p = nextpoint(p, dir)
		else:
			break
	return word, steps -1

def findstart(board):
	for x in range(board['w']):
		p = point(x, 0)
		if p in board:
			return p

def nextpoint(p, dir):
	if dir == 's':
		return point(p.x, p.y +1)
	elif dir == 'n':
		return point(p.x, p.y -1)
	if dir == 'o':
		return point(p.x -1, p.y)
	else: #e
		return point(p.x +1, p.y)
	
def nextpointdir(board, p, dir):
	if dir in ['s', 'n']:
		e = point(p.x +1, p.y)
		o = point(p.x -1, p.y)
		if e in board and board[e] not in ['|', '+']:
			return e, 'e'
		else:
			return o, 'o'
	else:
		n = point(p.x, p.y -1)
		s = point(p.x, p.y +1)
		if n in board and board[n] not in ['-', '+']:
			return n, 'n'
		else:
			return s, 's'

input = '''     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ 
'''

board = read(input)
print(quiz1(board), 38)

with open('day19.txt', 'r') as content_file: input = content_file.read()
board = read(input)
print(quiz1(board))

