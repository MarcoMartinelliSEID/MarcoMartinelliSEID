import os
import time
from tkinter import *


class Segnale:
    tagNumber = '%' + '%'
    scheda = ''
    descrizione1 = ''
    descrizione2 = '%' + '%'
    descrizione3 = '%' + '%'
    schedaAttuale = 'AI1'
    address = ''

    def __init__(self, tagNumber, scheda, descrizione, address, descr_length): #costruttore dell'oggetto
        if(tagNumber != 'None'):
            self.tagNumber = tagNumber
        self.scheda = scheda
        self.setScheda(scheda)
        self.splitDescrizione(descrizione, descr_length)
        if address == 'None':
            self.address = ''
        else:
            self.address = address
    
    def print(self):
        return str(self.tagNumber) + ' - ' + str(self.scheda) + ' - ' + str(self.descrizione1) + ' ' + str(self.descrizione2) + ' ' + str(self.descrizione3) + ' - ' + str(self.address)

    def splitDescrizione(self, descrizione, descr_length):
        array = [] 
        array = descrizione.split(' ')
        i = 0
        self.descrizione1 = array[i]
        i += 1
        permesso = True
        permesso2 = True

        while i < len(array):
            if len(self.descrizione1) < descr_length and (len(self.descrizione1) + len(array[i])) < descr_length and permesso == True:                
                self.descrizione1 += ' ' + array[i]
                i+=1
                continue
            else:
                if self.descrizione2 == '%' + '%':
                    permesso = False
                    self.descrizione2 = array[i]
                    i += 1
                    continue
                if len(self.descrizione2) < descr_length and (len(self.descrizione2) + len(array[i])) < descr_length and permesso2 == True:
                    permesso = False                    
                    self.descrizione2 += ' ' + array[i]
                    i+=1
                    continue
                else:
                    permesso2 = False
                    if self.descrizione3 == '%' + '%':
                        self.descrizione3 = array[i]
                        i += 1
                        continue
                    self.descrizione3 += ' ' + array[i]                    
            i += 1
            
         
    #necessario perchè nel file excel le celle del nome della scheda sono unite in 1 sola, quindi verrebbe letta solo quella del primo segnale per ogni scheda
    def setScheda(self, scheda):
        if self.scheda != 'None':
            self.scheda = scheda
            Segnale.schedaAttuale = scheda
        else:         
            self.scheda = Segnale.schedaAttuale

    @staticmethod
    def copyAI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':            
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:2] == 'AI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y-14).value = array[i].address
                i += 1      
            x += 1
    
    @staticmethod
    def copyAO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:2] == 'A0' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            if stringa[0:2] == 'AO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            x += 1
    
    @staticmethod
    def copyDI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:2] == 'DI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    @staticmethod
    def copyDO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:2] == 'DO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    #------------------------------------------------------------------------------------------------------------------------------------------

    @staticmethod
    def copyRTD(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y + 1).value)
            if stringa[0:3] == 'RTD' and stringa2 != 'S_SCH_INP':
                print('copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y - 10).value = array[i].tagNumber
                bits.cell(x, y - 9).value = array[i].descrizione1
                bits.cell(x, y - 8).value = array[i].descrizione2
                bits.cell(x, y - 7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1
            x += 1

            # ------------------------------------------------------------------------------------------------------------------------------------------

    @staticmethod
    def copySAI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':            
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'SAI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1
           
    
    @staticmethod
    def copySAO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'SA0' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            if stringa[0:3] == 'SAO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            x += 1
    
    @staticmethod
    def copySDI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'SDI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    @staticmethod
    def copySDO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'SDO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    #-------------------------------------------------------------------------------------------------------------------------

    @staticmethod
    def copyRAI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':            
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'RAI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1
           
    
    @staticmethod
    def copyRAO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'RA0' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            if stringa[0:3] == 'RAO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            x += 1
    
    @staticmethod
    def copyRDI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'RDI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    @staticmethod
    def copyRDO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:3] == 'RDO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    #-------------------------------------------------------------------------------------------------------------------------------

    @staticmethod
    def copyRSAI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':            
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:4] == 'RSAI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1
           
    
    @staticmethod
    def copyRSAO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:4] == 'RSA0' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            if stringa[0:4] == 'RSAO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1    
            x += 1
    
    @staticmethod
    def copyRSDI(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:4] == 'RSDI' and stringa2 != 'S_SCH_INP':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    @staticmethod
    def copyRSDO(array, bits, text, text2, label_file_explorer3):
        x = 2; y = 15; i = 0
        lenArr = len(array)
        while str(bits.cell(x, y).value) != 'None':
            stringa = str(bits.cell(x, y).value)
            stringa2 = str(bits.cell(x, y+1).value)
            if stringa[0:4] == 'RSDO' and stringa2 != 'S_SCH_OUT':
                print( 'copy --> ')
                try:
                    print(array[i].print())
                except IndexError:
                    Segnale.indexError(array, i, label_file_explorer3, text, text2)
                text.insert(INSERT, 'copy --> ')
                text.insert(INSERT, array[i].print() + '\n')
                text.see("end")
                bits.cell(x, y-10).value = array[i].tagNumber
                bits.cell(x, y-9).value = array[i].descrizione1
                bits.cell(x, y-8).value = array[i].descrizione2
                bits.cell(x, y-7).value = array[i].descrizione3
                bits.cell(x, y - 14).value = array[i].address
                i += 1      
            x += 1

    #--------------------------------------------------------------------------------------------------------------------------

    @staticmethod
    def indexError(array, i, label_file_explorer3, text, text2):
        text2.insert(INSERT, 'ERROR AFTER SIGNAL:\n' + array[i - 1].print() + '\n')
        text2.see("end")
        text.see("end")
        label_file_explorer3.configure(text='Failed.')
        file_log = open("log.txt", "a")
        file_log.write(time.ctime() + ' | ' + os.getlogin() + ': ' + 'ERROR AFTER SIGNAL:\n' + array[i - 1].print() + '\n')
        file_log.close()

    #--------------------------------------------------------------------------------------------------------------------------

    @staticmethod
    def setVoidCell(bits, text, text2, label_file_explorer3):
        x = 2; y = 5; i = 0
        while str(bits.cell(x, y).value) != 'None':
            if str(bits.cell(x, y).value) == 'None':
                bits.cell(x, y).value = "%" + "%"
            if bits.cell(x, y+2).value == 'None':
                bits.cell(x, y+2).value = "%" + "%"
            x += 1

