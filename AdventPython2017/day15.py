
class gen:

	def __init__(self, factor, prev):
		self.factor = factor
		self.prev = prev
		
	def next(self):
		#d, m = divmod(self.prev * self.factor, 2147483647)
		self.prev = self.prev * self.factor % 2147483647
		return self.prev

	def low16(self):
		n = self.next() % 2**16
		#n = '{0:016b}'.format(int(n))
		return n

class judge:

	def __init__(self, a, b):
		self.gena = gen(16807, a)
		self.genb = gen(48271, b)

	def comp(self, n):
		i = 0
		for x in range(int(n)+1):
			a = self.gena.low16()
			b = self.genb.low16()
			i += 1 if a == b else 0
			if x % 20000 == 0:
			    print(x, i)
		return i

def test1a():
	j = judge(65, 8921)
	#j = judge(591, 393)
	return j.comp(40e6)

def test1b():
	ap = 65
	bp = 8921
	ap = 591
	bp = 393

	af = 16807
	bf = 48271
	pow = 2**16

	i = 0
	j = 0
	lim = int(40e6) +1
	while j < lim:	
		ap = (ap * af) % 2147483647
		bp = (bp * bf) % 2147483647
		i += 1 if ap % pow == bp % pow else 0
		if j % 1000000 == 0:
			print(j, i)
		j += 1
	return i

print(test1b())
