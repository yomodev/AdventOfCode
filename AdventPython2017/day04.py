import itertools

def test1():
	input = "5 1 9 5\n7 5 3\n2 4 6 8"
	with open('day04.txt', 'r') as content_file: input = content_file.read()
	checksum = 0
	for line in input.splitlines():
		words = line.split()
		#print(words)
		s = set(words)
		#print(s)
		checksum += 1 if len(s) == len(words) else 0
	#print(anagram(["ramo","mora"]))
	return checksum


def test2():
	input = "5 1 9 5\n7 5 3\n2 4 6 8"
	with open('day04.txt', 'r') as content_file: input = content_file.read()
	checksum = 0
	for line in input.splitlines():
		words = line.split()
		#print(words)
		s = set(words)
		#print(s)
		checksum += 1 if len(s) == len(words) and not anagram(words) else 0
	#print(anagram(["ramo","mora"]))
	return checksum


def anagram(words):
	for w1, w2 in itertools.combinations(words, 2):
		if len(w1) == len(w2):
			s1 = set(list(w1))
			s2 = set(list(w2))
			if s1 == s2:
				return True
	return False