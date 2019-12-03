import re
import collections
point = collections.namedtuple('point', ['x', 'y', 'z'])

class tripla:

	def __init__(self, input):
		values = list(map(int, re.sub('[^-\d]+',' ', input).split()))
		#print(values)
		self.p = point(values[0], values[1], values[2])
		self.v = point(values[3], values[4], values[5])
		self.a = point(values[6], values[7], values[8])
		self.avg = list()
		self.len = 20

	def tick(self):
		a = self.a
		v = self.v
		self.v = point(v.x + a.x, v.y + a.y, v.z + a.z)
		v = self.v
		p = self.p
		self.p = point(v.x + p.x, v.y + p.y, v.z + p.z)
		d = self.dist()

		self.avg.insert(0, d)
		if len(self.avg) > self.len:
			self.avg.pop()
		return d

	def dist(self):
		p = self.p
		dist = abs(p.x) + abs(p.y) + abs(p.z)
		return dist

	def purge(self, particles):
		return
		if len(self.avg) == self.len:
			if abs(self.avg[0]) > abs(self.avg[1]) and abs(self.avg[1]) > abs(self.avg[2]):
				particles.remove(self)


def quiz1(input):
	particles = []
	for line in input.splitlines():
	    particles.append(tripla(line))
	i = 0
	part = None
	repeat = 0
	while True:
		print('tick', i, 'particles', len(particles), 'part', particles.index(part) if part is not None else None)
		curmin = 9999
		curpart = None
		for n in reversed(range(len(particles))):
			t = particles[n]
			manh = t.tick()
			if manh < curmin:
				curmin = manh
				curpart = t
			else:
				t.purge(particles)
		if curpart != part:
			print('cur', part.dist() if part is not None else None, 'prev', curpart.dist())
			part = curpart
			repeat = 0
		elif repeat < 9:
			print('101', particles[101].dist(), '170', particles[170].dist())
			repeat += 1
		else:
			break
		i += 1
	return particles.index(part)

input = 'p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>\np=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>'
#print(quiz1(input), 0)

with open('day20.txt', 'r') as content_file: input = content_file.read()
print(quiz1(input), 170)

def quiz2(input):
	particles = []
	for line in input.splitlines():
	    particles.append(tripla(line))
	i = 0
	repeat = 0
	while True:
		print('tick', i, 'particles', len(particles))
		d = dict()
		for n in reversed(range(len(particles))):
			t = particles[n]
			t.tick()
			d.setdefault(t.p, list())
			d[t.p].append(t)

		collisions = 0
		for x in d.values():
			if len(x) > 1:
				collisions += 1
				for t in x:
				    particles.remove(t)

		if len(particles) == 1:
			break
		elif collisions > 0:
			repeat = 0
		elif repeat < 100:
			repeat += 1
		else:
			break
		i += 1
	return len(particles)

#input = 'p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>\np=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>\np=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>\np=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>\n'
print(quiz2(input))
