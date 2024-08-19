from threading import local
from tkinter.font import nametofont
from unicodedata import name


DI = []
DI.append(1)
DI.append(2)

print(DI)
variable = [ i for i, j in locals().items() if j == DI][0]
print(variable)