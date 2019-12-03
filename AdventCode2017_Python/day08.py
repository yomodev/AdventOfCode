
def test1():
	input = '''b inc 5 if a > 1
				a inc 1 if b < 5
				c dec -10 if a >= 1
				c inc -20 if c == 10'''

	with open('day08.txt', 'r') as content_file: input = content_file.read()
	reg = dict()
	M = 0
	for line in input.splitlines():
		instr = line.strip().split()
		print(instr)
		regAddress = instr[0]
		instrValue = int(instr[2])
		testValue = int(instr[6])
		testAddress = instr[4]
		comp = instr[5]
		
		if testReg(reg.get(testAddress, 0), comp, testValue):
			regValue = reg.get(regAddress, 0)
			incrValue = instrValue if instr[1] == 'inc' else -1 * instrValue
			newValue = regValue + incrValue
			M = newValue if newValue > M else M
			reg[regAddress] = newValue

	print(max(reg.values()), M)

def testReg(v1, op, v2):
	if op == '==': return v1 == v2
	elif op == '!=': return v1 != v2
	elif op == '<': return v1 < v2
	elif op == '<=': return v1 <= v2
	elif op == '>': return v1 > v2
	elif op == '>=': return v1 >= v2
	print('unhandled op', op)
	return False


		

		