import itertools
import math

def quiz1(input):
	a,b = tran(input)
	return abs(a) + abs(b)

def quiz2(Max):
	dict = {}
	for n in range(1,Max+2):
		t = tran(n)
		v = sumAdj(t, dict)
		dict[t] = v
		if v > Max:
			return v


def sumAdj(t, dict):
	x, y = t
	#print(x,y)
	if (x, y) == (0,0):
		return 1

	ee = dict.get((x+1,y),0)
	ne = dict.get((x+1,y-1),0)
	nn = dict.get((x,y-1),0)
	no = dict.get((x-1,y-1),0)
	oo = dict.get((x-1,y),0)
	so = dict.get((x-1,y+1),0)
	ss = dict.get((x,y+1),0)
	se = dict.get((x+1,y+1),0)
	return ee + ne + nn + no + oo + so + ss + se


def tran(n):
	x, y = pos(n)
	l = math.ceil(math.sqrt(n))
	if l % 2 == 0:
	    return (x - int(l/2), -1* (y - int(l/2) -1))
	return (x - math.ceil(l/2), -1 * (y - math.ceil(l/2)))


def pos(n):
	l = math.ceil(math.sqrt(n))
	sq = l*l
	if sq == n and l%2 == 1:
		return (l,l)
	elif sq -l < n < sq and l%2 == 1: #down
		return (l - (sq-n), l)
	elif sq - l*2 < n <= sq -l and l%2 == 1: #left
		return (1, n - (sq - l*2 +1))
	elif sq -l < n <= sq: #top
		return (sq - n +1, 1)
	elif sq - l*2 < n <= sq -l: #right
		return (l, l - (n - (l-1)*(l-1)) +1)
	return "error " + n


def runtests(tests):
	for x in tests[1]:
		res = tests[0](x[0])
		print(x, res, res == x[1])


test1 = (quiz1, [(1, 0), (12, 3), (23, 2), (1024, 31)])
runtests(test1)

print('quiz1', quiz1(312051), 430)	

test2 = (quiz2, [(1, 1), (2, 1), (3, 2), (4, 4), (5, 5)])
runtests(test2)

print('quiz2', quiz2(312051), 312453)
