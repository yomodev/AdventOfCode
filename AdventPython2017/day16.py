import re

def test1(moves, input):
	l = input
	for move in moves:
		a, b, c = move
		if a == 1:
			l = l[-b:] + l[:-b]
		elif a == 2:
			l = list(l)
			l[b], l[c] = l[c], l[b]
			l = ''.join(l)
		else: #p
			l = l.replace(b, '#').replace(c, b).replace('#', c);
		#print(l)

	return l


def parse(input):
	pat = re.compile('(.)(\w+)/?(\w+)?')
	moves = []
	for move in input.split(','):
			#print(move)
			a, b, c = pat.match(move.strip()).group(1,2,3)
			if a == 's':
				moves.append((1, int(b), None))
			elif a == 'x':
				moves.append((2, int(b), int(c)))
			else: #p
				moves.append((3, b, c))
	return moves


def test2(moves, input, cycles):
	
	cycles = int(cycles)
	i = 0
	match = ''
	while i < cycles:
		output = test1(moves, input)
		if output == match:
			i = cycles - (cycles % i)
		elif match == '':
		    match = output
		input = output
		i += 1
	return output

moves = parse('s1, x3/4, pe/b')
result = test1(moves, 'abcde')
print('test 1', result, 'OK' if result == 'baedc' else 'ERROR!')

input = ''
with open('day16.txt', 'r') as content_file: input = content_file.read()
moves = parse(input)
result = test1(moves, 'abcdefghijklmnop')
print('test 1', result, 'OK' if result == 'ebjpfdgmihonackl' else 'ERROR!')

result = test2(moves, 'abcdefghijklmnop', 1e9)
print('test 2', result, 'OK' if result == 'abocefghijklmndp' else 'ERROR!')
