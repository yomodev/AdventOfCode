import itertools

class UniversalOrbitMap:
 
 def __init__(self, data):
  self.tree = {}
  for ab in data:
   ab = (ab.strip().split(')'))
   self.tree.setdefault(ab[0])
   self.tree[ab[1]] = ab[0]
 
 def CalculateChecksum(self):
  s = 0
  for k, v in self.tree.items():
   while v is not None:
    v = self.tree[v]
    s += 1
    
   #print(k, s)
  return s    

 def CalculateTransfer(self):
  
  v = self.tree["YOU"]
  you = [v]
  while v is not None:
    v = self.tree[v]
    if v is not None:
     you.append(v)
  
  
  v = self.tree["SAN"]
  san = [v]
  while v is not None:
    v = self.tree[v]
    if v is not None:
     san.append(v)
  #you.reverse()
  c = next(filter(lambda y: y in san, you), None)
  y = list(itertools.takewhile(lambda x: x != c, you))
  s = list(itertools.takewhile(lambda x: x != c, san))
  
  return len(s) + len(y)   


class Day06:

 def Test1(input):
  data = open(input, 'r').readlines()
  uom = UniversalOrbitMap(data)
  return uom.CalculateChecksum()

 def Test2(input):
  data = open(input, 'r').readlines()
  uom = UniversalOrbitMap(data)
  return uom.CalculateTransfer()

 
# test 1
uom = UniversalOrbitMap("COM)B B)C C)D D)E E)F B)G G)H D)I E)J J)K K)L".split(' '))
result = uom.CalculateChecksum()
print('test 2.1', result, 'OK' if result == 42 else 'ERROR!')

result = Day06.Test1("inputs\Day06_1.txt")
print('test1', result)

# test 2
uom = UniversalOrbitMap("COM)B B)C C)D D)E E)F B)G G)H D)I E)J J)K K)L K)YOU I)SAN".split(' '))
result = uom.CalculateTransfer()
print('test 2.1', result, 'OK' if result == 4 else 'ERROR!')

result = Day06.Test2("inputs\Day06_1.txt")
print('test2', result)
