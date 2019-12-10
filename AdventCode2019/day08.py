from collections import Counter

class COLOR:
 BLACK = 0
 WHITE = 1
 TRANSPARENT = 2

class SpaceImage:
 
 def __init__(self, width, height, data):
  self.w = width
  self.h = height
  self.layers = []
  layer = []
  layerSize = width * height
  for i, j in enumerate(data):
   if i % layerSize == 0:
    layer = []
    self.layers.append(layer)
   layer.append(j)
   
 def Decode(self):
  out = []
  for k, v in enumerate(range(self.w * self.h)):
   layerId = 0
   out.append(COLOR.TRANSPARENT)
   while layerId < len(self.layers):
    color = self.layers[layerId][k]
    if color in [COLOR.WHITE, COLOR.BLACK]:
     out[k] = color
     break
    layerId += 1
  return out

 def Print(self):
  out = self.Decode()
  str = ""
  for k,v in enumerate(out):
   str += "\n" if k % self.w == 0 else ''
   str += chr(0x2588) if v == COLOR.WHITE else ' '
  print(str)

class Day08:

 def Test1(input):
  data = [int(s) for s in open(input, 'r').readlines()[0].strip()]
  img = SpaceImage(25, 6, data)
  mins = dict(enumerate(map(lambda x: Counter(x)[0], img.layers)))
  layerId = min(mins, key = mins.get)
  stats = Counter(img.layers[layerId])
  return stats[1] * stats[2]

 def Test2(input):
  data = [int(s) for s in open(input, 'r').readlines()[0].strip()]
  img = SpaceImage(25, 6, data)
  img.Print()

 
# test 1
result = Day08.Test1("inputs\Day08_1.txt")
print('test1', result)

# test 2

img = SpaceImage(2, 2, [int(s) for s in '0222112222120000'])
result = img.Decode()
print('test 2.1', result, 'OK' if "".join(map(str, result)) == "0110" else 'ERROR!')

result = Day08.Test2("inputs\Day08_1.txt")
print('test2', result)
