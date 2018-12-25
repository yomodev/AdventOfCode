def test1():
	inp="0 2 7 0"
	inp="4 10 4 1 8 4 9 14 5 1 14 15 0 15 3 5"
	nums = list(map(lambda x: int(x), inp.split()))
	hist = [ nums ]
	step = 1
	current = nums[:]
	while True:
		#print('step', step, 'current', current)
    
		#search max
		m = max(current)
		#max index
		idx = current.index(m)
		current[idx] = 0
		idx += 1
		while m > 0:
			idx = 0 if idx >= len(current) else idx
			current[idx] += 1
			m -= 1
			idx += 1
    
		if current in hist:
			print(step, hist.index(current), step - hist.index(current))
			break
		step += 1
		hist.append(current[:])
    
	#print(hist[0])
