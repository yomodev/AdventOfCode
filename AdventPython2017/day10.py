
def pr(lis):
	for i,x in enumerate(lis):
		print(i,x)

def test1(limit, input):
	lis = list(range(limit))
	le = len(lis)
	skip = 0
	pos = 0
	for i in input:
		#print('input', i)
		#pr(lis)
		for x in range(int(i/2)):
			a = (pos + x) % le
			b = (pos + i -1 -x) % le
			#print('swap {0}[{1}] - {2}[{3}]'.format(a, lis[a], b, lis[b]))
			lis[a], lis[b] = lis[b], lis[a]
	
		pos = (pos + i + skip) % le
		#print('pos', pos)
		skip += 1
	return lis[0]*lis[1]

def test2(input):
	
	for x in [17, 31, 73, 47, 23]:
		input += chr(x)

	#for i,x in enumerate(inp2):
	#	print(i,ord(x))

	lis = list(range(256))
	le = len(lis)
	skip = 0
	pos = 0
	for rep in range(64):
		for i in input:
			i = ord(i)
			#print('input', i)
			#pr(lis)
			for x in range(int(i/2)):
				a = (pos + x) % le
				b = (pos + i -1 -x) % le
				#print('swap {0}[{1}] - {2}[{3}]'.format(a, lis[a], b, lis[b]))
				lis[a], lis[b] = lis[b], lis[a]
	
			pos = (pos + i + skip) % le
			#print('pos', pos)
			skip += 1

	#pr(lis)

	x = 0
	ans2 = ''
	#s = ''
	for i, n in enumerate(lis):
		x = x ^ n
		#s += ' ^ ' + str(n)
		if (i+1) % 16 == 0:
			ans2 += '{0:02X}'.format(x)
			#print(s + ' = ' + str(x) + ' = {0:02X}'.format(x))
			x = 0
			#s = ''
	return ans2.strip().lower()

def runTest(list):
	for i, inp in enumerate(list):
		res = test2(inp[0])
		print('test '+str(i+1)+':', '"' +inp[0] + '"', '->', res, 'OK' if res == inp[1] else 'ERROR!')

print('test 1:', test1(5, [3, 4, 1, 5]), 'expected', 12)
print('answer 1:', test1(256, [31,2,85,1,80,109,35,63,98,255,0,13,105,254,128,33]))
print()
test = [('','a2582a3a0e66e6e86e3812dcb672a272'),
		('AoC 2017','33efeb34ea91902bb2f59c9920caa6cd'),
		('1,2,3','3efbe78a8d82f29979031a4aa0b16a9d'),
		('1,2,4','63960835bcdc130f0b66d7ff4f6a5a8e')]
runTest(test)
print()
print('answer 2:', test2('31,2,85,1,80,109,35,63,98,255,0,13,105,254,128,33'))

