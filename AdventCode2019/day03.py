import sys

class DIR:
 UP = 'U'
 DOWN = 'D'
 LEFT = 'L'
 RIGHT = 'R'


class Day03:

 def __init__(self):
  self.grid = {}
  self.wires = []


 def AddWire(self, wire):
  curPos = (0,0)
  steps = 0
  self.wires.append(wire)
  wireId = len(self.wires)
  for segment in wire.split(','):
   direction = segment[0]
   size = int(segment[1::])
   for i in range(size):
    if direction == DIR.RIGHT:
     curPos = (curPos[0] +1, curPos[1])
    elif direction == DIR.LEFT:
     curPos = (curPos[0] -1, curPos[1])
    elif direction == DIR.UP:
     curPos = (curPos[0], curPos[1] -1)
    elif direction == DIR.DOWN:
     curPos = (curPos[0], curPos[1] +1)
    
    #print(wireId, direction, i, curPos)
    steps += 1
    cell = self.grid.setdefault(curPos, {})
    if wireId not in cell:
     cell[wireId] = steps


 def AddWiresFromFile(self, fileName):
  with open(fileName, 'r') as content_file: input = content_file.read()
  input = [line.strip() for line in input.splitlines()]
  for line in input:
   self.AddWire(line)


 def GetClosestIntersectionDistance(self):
  def Manhattan(p):
   return abs(p[0]) + abs(p[1])

  distance = min(map(Manhattan, 
                     filter(lambda p: len(self.grid[p]) > 1, self.grid)))
  return distance


 def GetFewestCombinesSteps(self):
  distance = min(map(lambda p: sum(self.grid[p].values()), 
                     filter(lambda p: len(self.grid[p]) > 1, self.grid)))
  return distance




# test 1
d = Day03()
d.AddWire('R8,U5,L5,D3')
d.AddWire('U7,R6,D4,L4')
result = d.GetClosestIntersectionDistance()
print('test 1.1', result, 'OK' if result == 6 else 'ERROR!')

d = Day03()
d.AddWire('R75,D30,R83,U83,L12,D49,R71,U7,L72')
d.AddWire('U62,R66,U55,R34,D71,R55,D58,R83')
result = d.GetClosestIntersectionDistance()
print('test 1.2', result, 'OK' if result == 159 else 'ERROR!')

d = Day03()
d.AddWire('R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51')
d.AddWire('U98,R91,D20,R16,D67,R40,U7,R15,U6,R7')
result = d.GetClosestIntersectionDistance()
print('test 1.3', result, 'OK' if result == 135 else 'ERROR!')

d = Day03()
d.AddWiresFromFile("inputs\Day03_1.txt")
result = d.GetClosestIntersectionDistance()
print('test1', result)


# test 2
d = Day03()
d.AddWire('R8,U5,L5,D3')
d.AddWire('U7,R6,D4,L4')
result = d.GetFewestCombinesSteps()
print('test 2.1', result, 'OK' if result == 30 else 'ERROR!')

d = Day03()
d.AddWire('R75,D30,R83,U83,L12,D49,R71,U7,L72')
d.AddWire('U62,R66,U55,R34,D71,R55,D58,R83')
result = d.GetFewestCombinesSteps()
print('test 2.2', result, 'OK' if result == 610 else 'ERROR!')

d = Day03()
d.AddWire('R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51')
d.AddWire('U98,R91,D20,R16,D67,R40,U7,R15,U6,R7')
result = d.GetFewestCombinesSteps()
print('test 2.3', result, 'OK' if result == 410 else 'ERROR!')

d = Day03()
d.AddWiresFromFile("inputs\Day03_1.txt")
result = d.GetFewestCombinesSteps()
print('test2', result)

