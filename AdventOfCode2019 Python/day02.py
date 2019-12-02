import math


class Day02:

 def ArrayEqual(a, b):
  n = len(a)
  if (n != len(b)): 
   return False; 
  
  for i in range(0, n - 1): 
   if (a[i] != b[i]): 
    return False;

  return True


 def RunIntcode(intcode):
  for x in range(0, len(intcode), 4):
   opcode = intcode[x]
   if opcode == 99:
    return intcode
   
   par1 = intcode[intcode[x +1]]
   par2 = intcode[intcode[x +2]]
   address = intcode[x +3]

   if opcode == 1:
    intcode[address] = par1 + par2
   elif opcode == 2:
    intcode[address] = par1 * par2

  return intcode


 def Test1(input):
  with open(input, 'r') as content_file: input = content_file.read()
  intCode = [int(s) for s in input.split(',')]
  intCode[1] = 12
  intCode[2] = 2

  outCode = Day02.RunIntcode(intCode)
  return outCode[0]


 def Test2(input, expectedCode):
  with open(input, 'r') as content_file: input = content_file.read()
  
  for noun in range(0,100):
   for verb in range(0,100):
    intCode = [int(s) for s in input.split(',')]
    intCode[1] = noun
    intCode[2] = verb
  
    outCode = Day02.RunIntcode(intCode)
    if outCode[0] == expectedCode:
     return 100 * noun + verb
  


# test 1
result = Day02.RunIntcode([1,9,10,3,2,3,11,0,99,30,40,50])
print('test 1.1', result, 'OK' if Day02.ArrayEqual(result, [3500,9,10,70,2,3,11,0,99,30,40,50]) else 'ERROR!')

result = Day02.RunIntcode([1,0,0,0,99])
print('test 1.2', result, 'OK' if Day02.ArrayEqual(result, [2,0,0,0,99]) else 'ERROR!')

result = Day02.RunIntcode([2,3,0,3,99])
print('test 1.3', result, 'OK' if Day02.ArrayEqual(result, [2,3,0,6,99]) else 'ERROR!')

result = Day02.RunIntcode([2,4,4,5,99,0])
print('test 1.3', result, 'OK' if Day02.ArrayEqual(result, [2,4,4,5,99,9801]) else 'ERROR!')

result = Day02.RunIntcode([1,1,1,4,99,5,6,0,99])
print('test 1.3', result, 'OK' if Day02.ArrayEqual(result, [30,1,1,4,2,5,6,0,99]) else 'ERROR!')

result = Day02.Test1("inputs\day02_1.txt")
print('test1', result)

# test 2
result = Day02.Test2("inputs\day02_1.txt", 19690720)
print('test2', result)
