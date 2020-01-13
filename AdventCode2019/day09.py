import itertools
from collections import deque
from collections import OrderedDict


class STATUS:
 READY = 0
 COMPLETE = 1
 WAIT = 2


class OP:
 SUM = 1
 MUL = 2
 INPUT = 3
 OUTPUT = 4
 JUMP_IF_TRUE = 5
 JUMP_IF_FALSE = 6
 LESS_THAN = 7
 EQUALS = 8
 BASE = 9
 HALT = 99


class MODE:
 POSITION = 0
 IMMEDIATE = 1
 RELATIVE = 2


class Parameter:
 def __init__(self, mode, value):
  self.mode = mode
  self.value = value


class Instruction:
 
 def __init__(self, opcode, *parameters):
  self.opcode = opcode % 100
  self.parameters = []
  #self._opcode = opcode
  #self._parameters = []
  if self.opcode == OP.HALT:
   return

  paramCount = 1 if self.opcode in [OP.INPUT, OP.OUTPUT, OP.BASE] else 3
  paramCount = 2 if self.opcode in [OP.JUMP_IF_TRUE, OP.JUMP_IF_FALSE] else paramCount

  for i in range(paramCount):
   mode = Instruction.GetMode(opcode, i)
   param = Parameter(mode, parameters[0][i][1])
   #self._parameters.append(parameters[0][i])
   self.parameters.append(param)

 def GetMode(opcode, i):
  if opcode // 10** (i +2) % 10 == 1:
   return MODE.IMMEDIATE
  elif opcode // 10** (i +2) % 10 == 2:
   return MODE.RELATIVE
  return MODE.POSITION

 def GetValue(self, index, memory, offset = 0):
  p = self.parameters[index -1] 
  v = p.value if p.mode == MODE.IMMEDIATE else memory.get(p.value + offset, 0)
  return v 

 def GetRawValue(self, index, memory):
  p = self.parameters[index -1] 
  return p.value


class IntcodeComputer:
 def __init__(self, memory, phase = None):
  self.memory = OrderedDict(enumerate(memory))
  self.input = deque([phase] if phase is not None else [])
  self.ip = 0
  self.base = 0
  self.output = []
  self.status = STATUS.READY
  

 def Run(self, input = []):
  self.input += input
  while self.status != STATUS.COMPLETE:
   self.RunWait()  
  return self.output


 def RunWait(self, input = None):
  if input is not None:
   self.input += [input]

  while True:
   opcode = self.memory[self.ip]
   rest = list(self.memory.items())[self.ip +1:]
   instr = Instruction(opcode, rest)
   #print('self.offset', self.offset, opcode, instr.opcode)
   
   if instr.opcode == OP.SUM:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    address = instr.GetRawValue(3, self.memory)
    #print('+', address, par1, par2)
    self.memory[address] = par1 + par2
    
   elif instr.opcode == OP.MUL:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    address = instr.GetRawValue(3, self.memory)
    #print('*', address, par1, par2)
    self.memory[address] = par1 * par2
   
   elif instr.opcode == OP.INPUT:
    par1 = instr.GetRawValue(1, self.memory)
    #print('in', instr.parameters[0].value)
    if len(self.input) == 0:
     self.status = STATUS.WAIT
     return self.output[-1]
    inp = self.input.popleft()
    self.memory[par1] = inp

   elif instr.opcode == OP.OUTPUT:
    out = instr.GetValue(1, self.memory)
    self.output.append(out)
    #print('ou', out, instr.parameters[0].value)
    print(out)

   elif instr.opcode == OP.EQUALS:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    address = instr.GetRawValue(3, self.memory)
    #print('=', address, par1, par2)
    self.memory[address] = 1 if par1 == par2 else 0
   
   elif instr.opcode == OP.JUMP_IF_TRUE:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    if par1 != 0:
     self.ip = par2
     continue

   elif instr.opcode == OP.JUMP_IF_FALSE:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    if par1 == 0:
     self.ip = par2
     continue

   elif instr.opcode == OP.LESS_THAN:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    address = instr.GetRawValue(3, self.memory)
    #print('=', address, par1, par2)
    self.memory[address] = 1 if par1 < par2 else 0

   elif instr.opcode == OP.BASE:
    par1 = instr.GetRawValue(1, self.memory)
    self.base += par1
    print('@', self.base, par1)

   elif instr.opcode == OP.HALT:
    break

   self.ip += 1+ len(instr.parameters)
   if self.ip >= len(self.memory):
    break

  self.status = STATUS.COMPLETE
  return self.output[-1]


class AmplifierControllerSoftware:
 def __init__(self, memory):
  self.memory = memory

 def Run(self, rang):
  d = {}
  for perm in itertools.permutations(rang, len(rang)):
   #print(perm)
   out = [0]
   for i in perm:
    #print(i)
    input = [i] + out
    out = IntcodeComputer(self.memory).Run(input)
   d[out[-1]] = perm
  result = max(d.keys())
  perm = d[result]
  return result, perm

 def Loop(self, rang):
  d = {}
  for perm in itertools.permutations(rang, len(rang)):
   #print("perm", perm)
   amp = [IntcodeComputer(list(self.memory), perm[i]) for i in range(5)]
   i = 0
   input = 0
   #print(i, "input", input)

   while True:
    ampX = amp[i]
    if ampX.status == STATUS.COMPLETE:
     break
    input = ampX.RunWait(input)
    #print(i, "input", input)
    i = (i +1) % 5
   d[amp[4].output[-1]] = perm
   
  result = max(d.keys())
  perm = d[result]
  return result, perm

  return (0,0)


class Day09:

 def Test1(input):
  intCode = [int(s) for s in open(input, 'r').readlines()[0].strip().split(',')]
  output = AmplifierControllerSoftware(intCode).Run(range(5))
  return output

 def Test2(input):
  intCode = [int(s) for s in open(input, 'r').readlines()[0].strip().split(',')]
  output = AmplifierControllerSoftware(intCode).Loop(range(5,10))
  return output

# test 1
result = AmplifierControllerSoftware([3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0]).Run(range(5))
print('test 1.1', result, 'OK' if result[0] == 43210 else 'ERROR!')

result = AmplifierControllerSoftware([3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,
                                      24,23,23,4,23,99,0,0]).Run(range(5))
print('test 1.2', result, 'OK' if result[0] == 54321 else 'ERROR!')

result = AmplifierControllerSoftware([3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0]).Run(range(5))
print('test 1.3', result, 'OK' if result[0] == 65210 else 'ERROR!')

result = IntcodeComputer([109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99]).Run()
print('test 1.4', result, 'OK' if result[0] == 65210 else 'ERROR!')

#result = Day09.Test1("inputs\Day09_1.txt")
print('test1', result)

# test 2
result = AmplifierControllerSoftware([3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,
                                      1001,28,-1,28,1005,28,6,99,0,0,5]).Loop(range(5,10))
print('test 2.1', result, 'OK' if result[0] == 139629729 else 'ERROR!')

result = AmplifierControllerSoftware([3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,
                                      55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,
                                      1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,
                                      99,0,0,0,0,10]).Loop(range(5,10))
print('test 2.2', result, 'OK' if result[0] == 18216 else 'ERROR!')

#result = Day09.Test2("inputs\Day09_1.txt")
print('test2', result)
