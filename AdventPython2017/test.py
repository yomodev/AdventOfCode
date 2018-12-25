firewall = {}
with open('day13.txt') as file:
    for line in file.readlines():
        depth, layer_range = map(int, line.strip().split(':'))
        firewall[depth] = layer_range

delay = 0
while True:
    caught = False
    scanner = delay
    for position in range(max(firewall.keys())+1):
        if position in firewall and scanner % (firewall[position] * 2 - 2) == 0:
            caught = True
            break
        scanner += 1

    if caught:
        delay += 1
    else:
        print(delay)
        break