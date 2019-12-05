import math

class OP:
 SUM = 1
 MUL = 2
 INPUT = 3
 OUTPUT = 4
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
  if self.opcode == OP.HALT:
   return

  for i in range(1 if opcode in [OP.INPUT, OP.OUTPUT] else 3):
   mode = Instruction.GetMode(opcode, i)
   param = Parameter(mode, parameters[0][i])
   self.parameters.append(param)

 def GetMode(opcode, i):
  return MODE.IMMEDIATE if opcode // 10** i +3 % 10 == 1 else MODE.POSITION

 def GetValue(self, index, intCode):
  p = self.parameters[index -1] 
  v = intCode[p.value] if p.mode == MODE.POSITION else p.value
  return v


class Prog:
 def __init__(self, intCode):
  offset = 0
  while True:
   opcode = intCode[offset]
   rest = intCode[offset +1:]
   instr = Instruction(opcode, rest)
   offset += 1+ len(instr.parameters)

   if instr.opcode == OP.INPUT:
    par1 = instr.GetValue(1, intCode)
    intCode[par1] = 1 #by design

   elif instr.opcode == OP.OUTPUT:
    par1 = instr.GetValue(1, intCode)
    output = intCode[par1]
    print(output)

   elif instr.opcode == OP.SUM:
    par1 = instr.GetValue(1, intCode)
    par2 = instr.GetValue(2, intCode)
    address = instr.GetValue(3, intCode)
    intCode[address] = par1 + par2
    
   elif instr.opcode == OP.MUL:
    par1 = instr.GetValue(1, intCode)
    par2 = instr.GetValue(2, intCode)
    address = instr.GetValue(3, intCode)
    intCode[address] = par1 * par2

   if offset >= len(intCode):
    break

  print("prog ok")


class Day05:


 def RunIntcode(intCode):
  #intCode = dict(zip(range(len(intCode)),intCode))
  offset = 0
  output = -1
  while True:
   par0 = intCode[offset]
   opcode = par0 % 100
   if opcode == OP.HALT:
    return output
   
   modePar1 = MODE.IMMEDIATE if par0 // 10**3 % 10 == 1 else MODE.POSITION
   modePar2 = MODE.IMMEDIATE if par0 // 10**4 % 10 == 1 else MODE.POSITION
   modePar3 = MODE.IMMEDIATE if par0 // 10**5 % 10 == 1 else MODE.POSITION
   par1 = 0
   par2 = 0
   address = 0

   if opcode == OP.INPUT:
    par1 = intCode[offset +1]
    intCode[par1] = 1 #by design
    offset += 2
    continue

   elif opcode == OP.OUTPUT:
    par1 = intCode[offset +1]
    output = intCode[par1]
    print(output)
    offset += 2
    continue

   else:
    par1 = intCode[offset +1] if modePar1 == MODE.IMMEDIATE else intCode[intCode[offset +1]]
    par2 = intCode[offset +2] if modePar2 == MODE.IMMEDIATE else intCode[intCode[offset +2]]
    address = intCode[offset +3] if modePar3 == MODE.IMMEDIATE else intCode[intCode[offset +3]]
    offset += 4
    

   if opcode == OP.SUM:
    intCode[address] = par1 + par2
    
   elif opcode == OP.MUL:
    intCode[address] = par1 * par2
   
   if offset >= len(intCode) -1:
    print('offset', offset, len(intCode))
    return -1

  return output


 def Test1(input):
  with open(input, 'r') as content_file: input = content_file.read()
  intCode = [int(s) for s in input.split(',')]
  intCode = dict(zip(range(len(intCode)),intCode))

  p = Prog(intCode)
  #outCode = Day05.RunIntcode(intCode)
  #return outCode




# test 1
#result = Day05.RunIntcode([3,0,4,0,99])
#print('test 1.1', result, 'OK' if result == 1 else 'ERROR!')

#result = Day05.RunIntcode([1002,4,3,4,33,4,4,99])
#print('test 1.2', result, 'OK' if result == 99 else 'ERROR!')

result = Day05.Test1("inputs\Day05_1.txt")
#print('test1', result)

# test 2
#result = Day05.Test2("inputs\Day05_1.txt", 19690720)
#print('test2', result)
