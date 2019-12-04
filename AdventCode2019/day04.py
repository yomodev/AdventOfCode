import collections

class Day04:

 def IsValid(pwd):
  pwd = [int(i) for i in str(pwd)]
  same = 0
  for i in range(1,6):
   v = pwd[i]
   if v < pwd[i -1]:
    return False

   if v == pwd[i -1]:
    same += 1

   #print(k,v)
  return same > 0


 def CountValidsInRange(lower, upper):
  valids = 0
  for val in range(lower, upper +1):
   valids += 1 if Day04.IsValid1(val) else 0
  return valids
 

 def IsValid1(pwd):
  pwd = str(pwd)
  if sorted(pwd) != list(pwd):
   return False
  return max(collections.Counter(pwd).values()) > 1


 def IsValid2(pwd):
  pwd = str(pwd)
  if sorted(pwd) != list(pwd):
   return False
  return 2 in collections.Counter(pwd).values()


 def CountValidsInRange2(lower, upper):
  valids = 0
  for val in range(lower, upper +1):
   valids += 1 if Day04.IsValid2(val) else 0
  return valids



# test 1
result = Day04.IsValid1(122345)
print('test 1.1', result, 'OK' if result == True else 'ERROR!')

result = Day04.IsValid1(111123)
print('test 1.2', result, 'OK' if result == True else 'ERROR!')

result = Day04.IsValid1(135679)
print('test 1.3', result, 'OK' if result == False else 'ERROR!')

result = Day04.IsValid1(111111)
print('test 1.4', result, 'OK' if result == True else 'ERROR!')

result = Day04.IsValid1(223450)
print('test 1.5', result, 'OK' if result == False else 'ERROR!')

result = Day04.IsValid1(123789)
print('test 1.6', result, 'OK' if result == False else 'ERROR!')

result = Day04.CountValidsInRange(156218, 652527)
print('test 1', result)


# test 2
result = Day04.IsValid2(112233)
print('test 2.1', result, 'OK' if result == True else 'ERROR!')

result = Day04.IsValid2(123444)
print('test 2.2', result, 'OK' if result == False else 'ERROR!')

result = Day04.IsValid2(111122)
print('test 2.3', result, 'OK' if result == True else 'ERROR!')

result = Day04.CountValidsInRange2(156218, 652527)
print('test 2', result)
