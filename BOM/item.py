
class Item:
    quantity = ''
    item_name = ''
    description_ita = ''
    description_en = ''
    code = ''
    brand = ''

    product = ''
    mark = True

    def __init__(self, quantity, item_name, description_ita, description_en, code, brand):
        self.quantity = quantity
        self.item_name = item_name
        self.description_ita = description_ita
        self.description_en = description_en
        self.code = code
        self.brand = brand
        self.product = self.description_ita + self.description_en + self.code + self.brand

    #-------------------------------------------------------------------------------------------------------------
    
    #print
    def print(self):
        print(str(self.quantity) + ' - ' + 
              str(self.item_name) + ' - ' + 
              str(self.description_ita) + ' - ' + 
              str(self.description_en) + ' - ' + 
              str(self.code) + ' - ' + 
              str(self.brand))
    
    