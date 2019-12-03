
def test1():
	input = '''set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2'''

	with open('day18.txt', 'r') as content_file: input = content_file.read()
	reg = dict()
	lines = list(input.splitlines())

	snd = 0
	line = 0
	while True:
		instr = lines[line].strip().split()
		x = instr[1]
		y = None
		if len(instr) > 2:
			y = instr[2]
		instr = instr[0]

		print(instr, x, y)
		
		if instr == 'snd':
			snd = getvalue(x, reg)
		elif instr == 'set':
			reg[x] = getvalue(y, reg)
		elif instr == 'add':
			reg[x] = reg.get(x, 0) + getvalue(y, reg)
		elif instr == 'mul':
			reg[x] = reg.get(x, 0) * getvalue(y, reg)
		elif instr == 'mod':
			reg[x] = reg.get(x, 0) % getvalue(y, reg)
		elif instr == 'rcv':
			if getvalue(x, reg) > 0:
				return snd
		elif instr == 'jgz':
			if getvalue(x, reg) > 0:
				line += getvalue(y, reg)
				continue
		else:
			print(line, instr, x, y)

		line += 1
		if line >= len(lines):
		    break
	print(snd)

def getvalue(s, reg):
	try:
		i = int(s)
		return i
	except ValueError:
		return reg[s]


#print(test1(), 3188)



class prog:

	def __init__(self, input, pid, queue, external_queue):
		self.pid = pid
		self.lines = input
		self.reg = { 'p': pid }
		self.line = 0
		self.wait = False
		self.queue = queue
		self.sendcount = 0
		self.external_queue = external_queue

	def play(self):
		while True:
			instr = self.lines[self.line]
			#print(instr)
			op = instr[0]
			x = instr[1] 
			y = self.getvalue(instr[2]) if len(instr) > 2 else None
			#print(self.pid, op, x, y)
		
			if op == 'snd':
				self.external_queue.append(self.getvalue(x))
				self.sendcount += 1
			elif op == 'set':
				self.reg[x] = y
			elif op == 'add':
				self.reg[x] = self.reg.get(x, 0) + y
			elif op == 'mul':
				self.reg[x] = self.reg.get(x, 0) * y
			elif op == 'mod':
				self.reg[x] = self.reg.get(x, 0) % y
			elif op == 'rcv':
				if len(self.queue) > 0:
					self.reg[x] = self.queue.pop(0)
					self.wait = False
				else:
					self.wait = True
					return
			elif op == 'jgz':
				if self.getvalue(x) > 0:
					self.line += y
					continue
			else:
				print('unhandled op', op, self.line, x, y)

			self.line += 1
			if self.line >= len(self.lines):
				break

	def getvalue(self, x):
		try:
			i = int(x)
			return i
		except ValueError:
			return self.reg[x]


def test2():
	input = '''snd 1
	snd 2
	snd p
	rcv a
	rcv b
	rcv c
	rcv d'''
	with open('day18.txt', 'r') as content_file: input = content_file.read()
	input = [line.strip().split() for line in input.splitlines()]

	q0 = list()
	q1 = list()
	p0 = prog(input, 0, q0, q1)
	p1 = prog(input, 1, q1, q0)
	
	while True:
		p0.play()
		p1.play()
		if len(p0.queue) == 0 and len(p1.queue) == 0:
			break
	return p1.sendcount

print(test2())

