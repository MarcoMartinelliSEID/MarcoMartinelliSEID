import json

class Persona:
    def __init__(self, nome, cognome):
        self.nome = nome
        self.cognome = cognome

# Creare una lista di oggetti Persona
persone = [
    Persona("Mario", "Rossi"),
    Persona("Luigi", "Verdi")
]

# Convertire la lista in una stringa JSON
persone_json = json.dumps([p.__dict__ for p in persone])
with open('my_array.json', 'w') as f:
    json.dump(persone_json, f)

# Stampare la stringa JSON
print(persone_json)

