class OP:
 SUM = 1
 MUL = 2
 INPUT = 3
 OUTPUT = 4
 JUMP_IF_TRUE = 5
 JUMP_IF_FALSE = 6
 LESS_THAN = 7
 EQUALS = 8
 HALT = 99


class MODE:
 POSITION = 0
 IMMEDIATE = 1


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

  paramCount = 1 if self.opcode in [OP.INPUT, OP.OUTPUT] else 3
  paramCount = 2 if self.opcode in [OP.JUMP_IF_TRUE, OP.JUMP_IF_FALSE] else paramCount

  for i in range(paramCount):
   mode = Instruction.GetMode(opcode, i)
   param = Parameter(mode, parameters[0][i])
   #self._parameters.append(parameters[0][i])
   self.parameters.append(param)

 def GetMode(opcode, i):
  return MODE.IMMEDIATE if opcode // 10** (i +2) % 10 == 1 else MODE.POSITION

 def GetValue(self, index, memory):
  p = self.parameters[index -1] 
  v = p.value if p.mode == MODE.IMMEDIATE else memory[p.value]
  return v 

 def GetRawValue(self, index, memory):
  p = self.parameters[index -1] 
  return p.value


class IntcodeComputer:
 def __init__(self, memory):
  self.memory = memory

 def Run(self, input = 1):
  offset = 0
  while True:
   opcode = self.memory[offset]
   rest = self.memory[offset +1:]
   instr = Instruction(opcode, rest)
   #print('offset', offset, opcode, instr.opcode)
   
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
    self.memory[par1] = input

   elif instr.opcode == OP.OUTPUT:
    output = instr.GetValue(1, self.memory)
    #print('ou', output, instr.parameters[0].value)
    print(output)

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
     offset = par2
     continue

   elif instr.opcode == OP.JUMP_IF_FALSE:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    if par1 == 0:
     offset = par2
     continue

   elif instr.opcode == OP.LESS_THAN:
    par1 = instr.GetValue(1, self.memory)
    par2 = instr.GetValue(2, self.memory)
    address = instr.GetRawValue(3, self.memory)
    #print('=', address, par1, par2)
    self.memory[address] = 1 if par1 < par2 else 0

   elif instr.opcode == OP.HALT:
    break

   offset += 1+ len(instr.parameters)
   if offset >= len(self.memory):
    break

  return output


class Day05:

 def Test1(input):
  with open(input, 'r') as content_file: input = content_file.read()
  intCode = [int(s) for s in input.split(',')]
  output = IntcodeComputer(intCode).Run()
  return output

 def Test2(input):
  with open(input, 'r') as content_file: input = content_file.read()
  intCode = [int(s) for s in input.split(',')]
  output = IntcodeComputer(intCode).Run(5)
  return output

# test 1
result = Day05.Test1("inputs\Day05_1.txt")
print('test1', result)

# test 2
result = IntcodeComputer([3,9,8,9,10,9,4,9,99,-1,8]).Run(8)
print('test 2.1', result, 'OK' if result == 1 else 'ERROR!')

result = IntcodeComputer([3,9,8,9,10,9,4,9,99,-1,8]).Run(0)
print('test 2.2', result, 'OK' if result == 0 else 'ERROR!')

result = IntcodeComputer([3,9,7,9,10,9,4,9,99,-1,8]).Run(8)
print('test 2.3', result, 'OK' if result == 0 else 'ERROR!')

result = IntcodeComputer([3,9,7,9,10,9,4,9,99,-1,8]).Run(7)
print('test 2.4', result, 'OK' if result == 1 else 'ERROR!')

result = IntcodeComputer([3,3,1108,-1,8,3,4,3,99]).Run(8)
print('test 2.5', result, 'OK' if result == 1 else 'ERROR!')

result = IntcodeComputer([3,3,1108,-1,8,3,4,3,99]).Run(7)
print('test 2.6', result, 'OK' if result == 0 else 'ERROR!')

result = IntcodeComputer([3,3,1107,-1,8,3,4,3,999]).Run(7)
print('test 2.7', result, 'OK' if result == 1 else 'ERROR!')

result = IntcodeComputer([3,3,1107,-1,8,3,4,3,999]).Run(9)
print('test 2.8', result, 'OK' if result == 0 else 'ERROR!')

result = IntcodeComputer([3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9]).Run(0)
print('test 2.9', result, 'OK' if result == 0 else 'ERROR!')

result = IntcodeComputer([3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9]).Run(1)
print('test 2.10', result, 'OK' if result == 1 else 'ERROR!')

result = IntcodeComputer([3,3,1105,-1,9,1101,0,0,12,4,12,99,1]).Run(0)
print('test 2.11', result, 'OK' if result == 0 else 'ERROR!')

result = IntcodeComputer([3,3,1105,-1,9,1101,0,0,12,4,12,99,1]).Run(1)
print('test 2.12', result, 'OK' if result == 1 else 'ERROR!')

intCode = [3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99]
result = IntcodeComputer(intCode).Run(8)
print('test 2.13', result, 'OK' if result == 1000 else 'ERROR!')

result = IntcodeComputer(intCode).Run(7)
print('test 2.14', result, 'OK' if result == 999 else 'ERROR!')

result = IntcodeComputer(intCode).Run(9)
print('test 2.15', result, 'OK' if result == 1001 else 'ERROR!')

result = Day05.Test2("inputs\Day05_1.txt")
print('test2', result)
