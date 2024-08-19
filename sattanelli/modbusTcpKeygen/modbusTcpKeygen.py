
def keygen(ident, prod):
	ident_int = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
	prod_int = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
	key_int = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
	rcv_time = [1, 2, 4, 8, 16, 32, 64, 128, 1, 2, 4, 8, 16, 32, 64, 128, 1]
	snd_time = [128, 64, 32, 16, 8, 4, 2, 1, 128, 64, 32, 16, 8, 4, 2, 1, 128]
	arr = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
	key = ''
	for x in range(len(prod)):
		prod_int[x] = ord(prod[x])  # Translate string into array of ASCII int values
	for x in range(len(ident)):
		ident_int[x] = ord(ident[x])  # Translate string into array of ASCII int values
	for i in range(17):
		for j in range(8):
			pos = (int(int(int(i / 8) * 8) + j))
			if ((prod_int[i] & snd_time[j]) == snd_time[j]):
				arr[pos] = arr[pos] | rcv_time[i]
	for i in range(17):
		key_int[i] = ((ident_int[i] ^ arr[i]) ^ (i + 1))
		key_int[i] = (key_int[i] % 26) + 65
		key = key + chr(key_int[i])  # Translate an array of ASCII int values in a string
		print(ident + ' - ' + prod  + ' - ' + key)
	return key









