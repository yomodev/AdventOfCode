import itertools

def quiz1(input):
	checksum = 0
	for line in input.splitlines():
		nums = list(map(lambda x: int(x), line.split()))
		#print(nums)
		checksum += max(nums) - min(nums)
	return checksum


def quiz2(input):
	checksum = 0
	for line in input.splitlines():
		nums = list(map(lambda x: int(x), line.split()))
		#print(nums)
		for x, y in itertools.combinations(nums, 2):
		    #print(x,y)
			a = max(x, y)
			b = min(x, y)
			checksum += int(a/b) if a % b == 0 else 0
	return checksum


def runtests(tests):
	for x in tests[1]:
		res = tests[0](x[0])
		print(x, res == x[1])


with open('day02.txt', 'r') as content_file: input = content_file.read()

test1 = (quiz1, [('5 1 9 5\n7 5 3\n2 4 6 8', 18)])
runtests(test1)

print('quiz1', quiz1(input), 36174)	

test2 = (quiz2, [('5 9 2 8\n9 4 7 3\n3 8 6 5', 9)])
runtests(test2)

print('quiz2', quiz2(input), 244)	
