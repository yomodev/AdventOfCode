import math

class Day01:

 def GetFuelPerMass(mass):
  fuel = math.floor(mass / 3)
  return fuel -2


 def GetFuelPerMassIncludingFuel(mass):
  sum = 0
  while True:
    fuel = math.floor(mass / 3)
    mass = fuel -2
    if mass > 0:
     sum += mass
    else:
     break    
  return sum


 def Test1(input):
  with open(input, 'r') as content_file: input = content_file.read()
  sum = 0 
  for line in input.splitlines():
   if len(line.strip()) > 0:
    mass = int(line)
    sum += Day01.GetFuelPerMass(mass)
  return sum


 def Test2(input):
  with open(input, 'r') as content_file: input = content_file.read()
  sum = 0 
  for line in input.splitlines():
   if len(line.strip()) > 0:
    mass = int(line)
    sum += Day01.GetFuelPerMassIncludingFuel(mass)
  return sum


# test 1
result = Day01.GetFuelPerMass(12)
print('test 1.1', result, 'OK' if result == 2 else 'ERROR!')

result = Day01.GetFuelPerMass(1969)
print('test 1.2', result, 'OK' if result == 654 else 'ERROR!')

result = Day01.GetFuelPerMass(100756)
print('test 1.3', result, 'OK' if result == 33583 else 'ERROR!')

result = Day01.Test1("inputs\day01_1.txt")
print('test1', result)

# test 2
result = Day01.GetFuelPerMassIncludingFuel(14)
print('test 2.1', result, 'OK' if result == 2 else 'ERROR!')

result = Day01.GetFuelPerMassIncludingFuel(1969)
print('test 2.2', result, 'OK' if result == 966 else 'ERROR!')

result = Day01.GetFuelPerMassIncludingFuel(100756)
print('test 2.3', result, 'OK' if result == 50346 else 'ERROR!')

result = Day01.Test2("inputs\day01_1.txt")
print('test2', result)

