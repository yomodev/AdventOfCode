import re

def test1():
	input = '''0 <-> 2
			1 <-> 1
			2 <-> 0, 3, 4
			3 <-> 2, 4
			4 <-> 2, 3, 6
			5 <-> 6
			6 <-> 4, 5'''
	with open('day12.txt', 'r') as content_file: input = content_file.read()
	d = dict()
	for line in input.splitlines():
		progs = list(map(lambda x: int(x), re.sub('\W+',' ', line).split()))
		n = progs[0]
		d[n] = set(progs[1::])

	for i in range(len(d)-1, 0, -1):
		#print(i, d[i])
		s = set(d[i])
		s.add(i)
		r = 0
		for n in d[i]:
			if n < i:
				d[n].update(s)
				r += 1
		
		if r > 0:
		    del d[i]
		
		
	#print(d)
	return len(d[0]), len(d)

			
print(test1())