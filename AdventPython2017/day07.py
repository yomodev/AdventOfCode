import re
import sys
import collections

def test1():
	with open('day07.txt', 'r') as content_file: input = content_file.read()
	d = dict()
	totWeight = 0
	for line in input.splitlines():
		line = re.sub('\W+',' ', line)
		#print(line)
		progs = line.split()
		current = progs[0]
		#print(line)
		weight = int(progs[1])
		totWeight += weight
		prog = addProg(d, current, weight, None)
		#if len(line) > 2:
		for i in range(2, len(progs)):
			#print(progs[i])
			child = addProg(d, progs[i], None, current)
			prog.addChild(child)
		#print(len(prog.childs), prog.name)
	
	root = None
	# search first without parent
	for name, entry in d.items():
		if entry.parent is None:
			root = entry
			entry.totWeight()
			print("root", name, entry.tot)			
			#break

	#locate different one
	print(root)
	node = root
	level = 1
	should = 0
	while True:
		if len(node.childs) > 0:
			avg = sum(list(map(lambda x: x.tot, node.childs)))/len(node.childs)
			#print('avg', avg)
			dif = None
			#dif = filter(lambda x: x.tot > avg, node.childs)
			#dif = dif[0]
			dif = [x for x in node.childs if x.tot > avg]
			if len(dif) > 0:
				dif = dif[0]
			else:
				print(level, node.name, node.weight, '->', node.weight - (node.tot - should))
				break
			should = (avg * len(node.childs) - dif.tot ) / (len(node.childs)-1)
			print(level, dif.name, dif.tot, should)
			level += 1
			node = dif
		else:
			break



class program:
	
	def __init__(self, name, weight, parent):
		self.weight = weight
		self.parent = parent
		self.name = name
		self.childs = []
		self.tot = 0
	
	def totWeight(self):
		self.tot = self.weight
		for prog in self.childs:
		    self.tot += prog.totWeight()
		return self.tot

	def addChild(self, entry):
		self.childs.append(entry)

def addProg(dictionary, prog, weight, parent):
	#if prog not in dictionary:
	#	dictionary[prog] = program(prog, None, None)
	dictionary.setdefault(prog, program(prog, None, None))
	entry = dictionary[prog]
	if weight is not None:
	    entry.weight = weight
	if parent is not None:
	    entry.parent = parent
	return entry
