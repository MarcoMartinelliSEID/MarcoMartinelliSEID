"""----------------------------------------------------------------------------------------------------------------------------------------------------------------------
SEID Srl
Progetto: SeidToolsLauncher
Versione: 2.2
Data: 01/12/2021
Autori: M. Martinelli
Aggiornamenti: 0.1 Creazione del LAUNCHER nel file __main__.py e classe MainApplication | 1.0 release | 1.1 release |
2.0 Adattamento a nuova IOLIST STANDARD, aggiunta segnali RTD, file log, path memorizzato, spinbox per lunghezza descrizioni variabile
2.1 fixed scoll text, fixed bug array column_data, new logo updated
2.2 ZohoCreator program updated to V0.2 (beta)
----------------------------------------------------------------------------------------------------------------------------------------------------------------------"""


import tkinter.font as font
import tkinter as tk
from BitToPLC import BitToPlc
from BitToPLC.HoverButton import HoverButton
from Generator import ModbusDB_Generator
from Generator import Function_Generator
from ZohoCreator import gui



class MainApplication(tk.Tk):

    global logo

    def __init__(self, master, *args, **kwargs):
        tk.Frame.__init__(self, master, *args, **kwargs)
        self.master = master
        #FONT
        font1 = font.Font(family='Helvetica', size=8, weight='bold')


        #GENERAL SETTINGS
        master.title('SEID Launcher')
        master.geometry('640x380')
        master.iconbitmap(intenal_link + 'img/seid.ico')
        master.config(background = 'black')

        #ROMELLI'S HIDDEN IMAGE        
        label = tk.Label(master, image = img, bd=0)
        label.pack()
        label.grid(column = 1, row = 7)

        #LABEL
        labelLogo = tk.Label(master, image=logo, bd = 0)
        label_program1 = tk.Label(master, text = "Import BITs to PLC", width = 70, height = 4, fg = "white", background = "#404040")
        label_program2 = tk.Label(master, text = "ModbusDB Generator", width = 70, height = 4, fg = "white", background = "#404040")
        label_program3 = tk.Label(master, text = "Function Generator", width = 70, height = 4, fg = "white", background = "#404040")
        label_program4 = tk.Label(master, text = "ZohoCreatorTool", width = 70, height = 4, fg = "white", background = "#404040")
        label_exit = tk.Label(master, text = "Exit", width = 70, height = 4, fg = "white", background = "#404040")

        #BUTTON
        button_program1 = HoverButton(master, text = "Import BITs to PLC", command = self.openProgram1, width=21, height=3, bd=0, font=font1, bg='#292626', fg='#ffffff', activebackground='#494666', activeforeground='#ffffff')
        button_program2 = HoverButton(master, text = "ModbusDB Generator", command = self.openProgram2, width=21, height=3, bd=0, font=font1, bg='#292626', fg='#ffffff', activebackground='#494666', activeforeground='#ffffff')
        button_program3 = HoverButton(master, text = "Function Generator", command = self.openProgram3, width=21, height=3, bd=0, font=font1, bg='#292626', fg='#ffffff', activebackground='#494666', activeforeground='#ffffff')
        button_program4 = HoverButton(master, text = "ZohoCreatorTool", command = self.openProgram4, width=21, height=3, bd=0, font=font1, bg='#292626', fg='#ffffff', activebackground='#494666', activeforeground='#ffffff')
        button_exit = HoverButton(master, text = "Chiudi", command = exit, width=21, height=3, bd=0, font=font1, bg='#292626', fg='#ffffff', activebackground='#494666', activeforeground='#ffffff')

        #STRUTTURA
        labelLogo.grid(column = 1, row = 1, columnspan = 2)
        label_program1.grid(column = 2, row = 2)
        label_program2.grid(column = 2, row = 3)
        label_program3.grid(column = 2, row = 4)
        label_program4.grid(column = 2, row = 5)
        label_exit.grid(column = 2, row = 6)

        button_program1.grid(column = 1, row = 2)
        button_program2.grid(column = 1, row = 3)
        button_program3.grid(column = 1, row = 4)
        button_program4.grid(column = 1, row = 5)
        button_exit.grid(column = 1, row = 6)

    #BUTTON'S FUNCTIONS
    def openProgram1(self):
        master.destroy()
        #master.destroy() --> può essere usata per chiudere il master dopo aver aperto un subprogram, bisogna però far diventare i subprogram Tk e non TopLevel
        BitToPlc.openBitToPLC()

    def openProgram2(self):
        master.destroy()
        ModbusDB_Generator.openModbusDB()

    def openProgram3(self):
        master.destroy()
        Function_Generator.openFunctionGen()

    def openProgram4(self):
        master.destroy()
        gui.startZoho()



#°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°


#MAIN PROGRAM
'''
@staticmethod
def getInternalLink():
    #DA FARE
'''

if __name__ == "__main__":

    intenal_link = ''

    master = tk.Tk()
    logo = tk.PhotoImage(file = intenal_link + "img/SEIDN2.jpg")
    img = tk.PhotoImage(file = intenal_link + 'img/' + 'ROM.png')
    MainApplication(master)
    master.mainloop()


