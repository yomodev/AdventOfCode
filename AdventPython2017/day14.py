def knothashes(input):
	
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

def test1(input):
	tot = 0
	for i in range(0,128):
		s = input + '-' + str(i)
		kh = knothashes(s)	
		for h in kh:
			n = int(h,16)
			#print('{0} = {0:04b}'.format(n))
			b = '{0:b}'.format(n)
			tot += len(b.replace('0',''))
		print(s, kh, tot)
	return tot

#print(test1('flqrgnkx'), 8108)
#print(test1('ugkiagan'))

def test2(input):
	file = open(input + '.txt','w')
	for i in range(0,128):
		s = input + '-' + str(i)
		kh = knothashes(s)
		b = ''
		for h in kh:
			n = int(h,16)
			#print('{0} = {0:04b}'.format(n))
			b += '{0:04b}'.format(n)
		print(s, kh, b)
		file.write(b)
		file.write('\n')
	file.close()

#print(test2('ugkiagan'))

def test3(input):
	with open(input + '.txt', 'r') as content_file: input = content_file.read()
	matrix = dict()
	for y, line in enumerate(input.splitlines()):
		for x, b in enumerate(list(line)):
			matrix[(x,y)] = 0 if b == '0' else -1
	
	tot = 0
	for y in range(0, 128):
		for x in range(0, 128):
			tot += mark(matrix, (x, y), tot)

	file = open('day14.txt','w')
	for y in range(0, 128):
		for x in range(0, 128):
			file.write('{:>5}'.format(matrix[x,y]))
		file.write('\n')
	file.close()

	return tot


def mark(m, p, c):
	if m[p] >= 0:
	    return 0
	c += 1
	m[p] = c
	x = 0
	y = 1
	q = list()
	q.append(p)
	while len(q) > 0:
		p = q.pop()

		n = (p[x], p[y]-1)
		if n[y] >= 0 and m[n] < 0:
			m[n] = c
			q.append(n)

		s = (p[x], p[y]+1)
		if s[y] < 128 and m[s] < 0:
			m[s] = c
			q.append(s)

		o = (p[x] -1, p[y])
		if o[x] >= 0 and m[o] < 0:
			m[o] = c
			q.append(o)

		e = (p[x] +1, p[y])
		if e[x] < 128 and m[e] < 0:
			m[e] = c
			q.append(e)

	return 1


print(test3('ugkiagan'))

