import datetime
import re


def test1():
	input = '0: 3\n1: 2\n4: 4\n6: 4'
	#with open('day13.txt', 'r') as content_file: input = content_file.read()
	d = dict()
	for line in input.splitlines():
		ln = list(map(lambda x: int(x), re.sub('\W+',' ', line).split()))
		#print(ln)
		d[ln[0]] = ln[1]

	sev = 0
	lun = max(d.keys())
	for layer in range(lun+1):
		rng = d.get(layer, 0)
		status = -1 if rng == 0 else 0
		status = layer % (rng-1) if rng > 0 and layer > 0 else status
		if rng == 2:
			status = 0 if layer %2 == 0 else 1

		print('layer', layer, 'range', rng, 'status', status)
		sev += layer * rng if status == 0 else 0
	return sev




class layer:

	def __init__(self, range):
		self.range = range
		
	def hit(self, time):
		b = time % (self.range * 2 - 2) == 0
		return b

	def severity(self, i):
		s = i * self.range if i % (self.range * 2 - 2) == 0 else 0
		return s


def scan(firewall, time):
	for i in range(max(firewall.keys())+1):
		if i in firewall and firewall[i].hit(time + i):
			return False
	return True

def severity(firewall):
	sev = 0
	for i in range(max(firewall.keys())+1):
		if i in firewall:
		   sev += firewall[i].severity(i)
	return sev


def test2():
	input = '0: 3\n1: 2\n4: 4\n6: 4'
	with open('day13.txt', 'r') as content_file: input = content_file.read()
	
	firewall = {}
	
	for line in input.splitlines():
		i, rng = map(int, re.sub('\W+',' ', line).split())
		firewall[i] = layer(rng)

	print('severity', severity(firewall))

	found = False
	time = 0
	while not found:
		found = scan(firewall, time)
		if time % 20000 == 0:
		    print('found', found, 'time', time)		
		time += 1
		
	return time -1

print(datetime.datetime.now())
print(test2(),datetime.datetime.now())
