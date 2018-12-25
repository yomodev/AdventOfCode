import collections
import datetime
import gc

def test1(step, limit):
	buffer = [0]
	pos = 1
	i = 1
	while i <= limit:
		pos = (pos + step) % len(buffer) +1
		buffer.insert(pos, i)
		i += 1
	return buffer[pos +1] if pos +1 < len(buffer) else buffer[0]

def test2(step, limit, find):
	buffer = collections.deque([0], limit +1)
	pos = 1
	i = 1
	while i <= limit:
		pos = (pos + step) % i +1
		buffer.insert(pos, i)
		i += 1
		if i % 50000 == 0:
		    print(i)
	pos = buffer.index(find)
	return buffer[pos +1] if pos +1 < len(buffer) else buffer[0]

def test3(step, limit):
	pos = 0
	z = 0
	for i in range(1, limit +2):
		pos = (pos + step) % i +1
		if pos == 1:
		    z = i
	return z


print(test1(3, 2017), 638)
print(test1(376, 2017), 777)
print(test2(3, 2017, 2017), 638)
print(test2(376, 2017, 2017), 777)
print(test2(376, 2017, 0))
print(test3(376, 2017), 1612)
print(datetime.datetime.now())
print(test3(376, int(5e7)), 39289581, "3'17''")
print(datetime.datetime.now())
