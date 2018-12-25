
def test1():
	input = "0\n3\n0\n1\n-3"
	with open('day05.txt', 'r') as content_file: input = content_file.read()
	step = 0
	nums = []
	for line in input.splitlines():
		nums.append(int(line))

	cur = 0
	while True:
		nex = cur + nums[cur]
		nums[cur] += 1
		step += 1
		cur = nex
		if nex >= len(nums):
		    break
		
	return step



def test2():
	input = "0\n3\n0\n1\n-3"
	with open('day05.txt', 'r') as content_file: input = content_file.read()
	step = 0
	nums = []
	for line in input.splitlines():
		nums.append(int(line))

	cur = 0
	while True:
		nex = cur + nums[cur]
		nums[cur] += 1 if nums[cur] < 3 else -1
		step += 1
		cur = nex
		if nex >= len(nums):
		    break
		
	return step

