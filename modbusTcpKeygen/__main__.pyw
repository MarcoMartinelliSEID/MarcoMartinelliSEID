
from tkinter import *
from tkinter import font
import tkinter as tk
import pyperclip
import modbusTcpKeygen
from HoverButton import HoverButton


class MainApplication(tk.Tk):

    global logo

    def __init__(self, master, *args, **kwargs):
        tk.Frame.__init__(self, master, *args, **kwargs)
        self.master = master
        #FONT
        font1 = font.Font(family='Helvetica', size=8, weight='bold')

        # BUTTON'S FUNCTIONS
        def openProgram1():
            ident = entry1.get()
            prod_id = entry2.get()
            entry3.delete(0, 'end')
            entry3.insert(INSERT, modbusTcpKeygen.keygen(ident, prod_id))
            print(entry1.get() + ' - ' + entry2.get()  + ' - ' + entry3.get())

        def openProgram2():
            pyperclip.copy(entry3.get())
            entry3.delete(0, 'end')
            entry3.insert(INSERT, 'Copied!')

        #GENERAL SETTINGS
        master.title('Modbus TCP Keygen')
        master.geometry('775x350')
        master.iconbitmap(intenal_link + 'img/seid.ico')
        master.config(background = 'black')

        #LABEL
        labelLogo = tk.Label(master, image=logo, bd = 0)
        label_program1 = tk.Label(master, text = "Ident Code:", width =22, height = 3, fg = "white", background = "#404040")
        label_program2 = tk.Label(master, text = "Product ID:", width = 22, height = 3, fg = "white", background = "#404040")
        label_program3 = tk.Label(master, text = "Version:", width = 32, height = 3, fg = "white", background = "#404040")
        label_program4 = tk.Label(master, text = "License Code:", width = 22, height = 3, fg = "white", background = "#404040")
        label_program5 = tk.Label(master, text="", width=110, height=5, fg="white", background="#000000")

        #BUTTON
        button_program1 = HoverButton(master, text = "Generate", command = openProgram1, width=22, height=3, bd=0, font=font1, bg='#252c4d', fg='#ffffff', activebackground='#664646', activeforeground='#ffffff')
        button_program2 = HoverButton(master, text= "Copy", command= openProgram2, width=22, height=3, bd=0, font=font1, bg='#252c4d', fg='#ffffff', activebackground='#664646', activeforeground='#ffffff')

        #STRUTTURA
        labelLogo.grid(column = 1, row = 1, columnspan = 3)
        label_program1.grid(column = 1, row = 2)
        label_program2.grid(column = 1, row = 3)
        label_program3.grid(column = 3, row = 2)
        label_program4.grid(column = 1, row = 5)
        label_program5.grid(column=1, row=4, columnspan=3)
        button_program1.grid(column = 1, row = 4)
        button_program2.grid(column=3, row=4)

        # ENTRY text
        name = StringVar()
        entry1 = Entry(master, width=25, font=('Arial', 20), textvariable=StringVar(), bd=0, background='#bfbfbf')
        entry1.grid(column=2, row=2)
        entry2 = Entry(master, width=25, font=('Arial', 20), textvariable=StringVar(), bd=0, background='#bfbfbf')
        entry2.grid(column=2, row=3)
        entry3 = Entry(master, width=40, font=('Arial', 20), textvariable=StringVar(), bd=0, background='#bfbfbf')
        entry3.grid(column=2, row=5, columnspan=2)
        #inserisciDati()

        # Menu a tendina
        option_list = ['MODBUS PN 400  (FB102 v3.7)', 'MODBUS CP 300  (FB108 v4.0)', 'MODBUS CP 400H (FB909 v2.0)', 'MODBUS PN 400H (FB915 v1.0)']
        option_list2 = ['MODPN2XV94501MB02', 'MODCP2XV94501MB00', 'MORED2XV94501MB11', 'PN6AVMODBUSREDMA3']
        variable = StringVar(master)
        variable.set(option_list[0])
        opt = OptionMenu(master, variable, *option_list)
        opt.config(font=('Helvetica', 8), width=30, height=2, bd=0, bg='#292626', fg='white',
                   activebackground='#292626', activeforeground='#ffffff')
        opt["menu"].config(bd=0, bg='#292626', fg='white', activebackground='#595656', activeforeground='#ffffff')
        opt.focus()
        opt["menu"].focus()
        opt.grid(column=3, row=3)

        def callback(*args):
            # labelTest.configure(text="The selected item is {}".format(variable.get()))
            entry2.delete(0, 'end')
            for i in range(4):
                if variable.get() == str(option_list[i]):
                    entry2.insert(INSERT, str(option_list2[i]))
            #inserisciDati()

        variable.trace("w", callback)



#°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°


#MAIN PROGRAM

if __name__ == "__main__":

    intenal_link = ''
    master = tk.Tk()
    logo = tk.PhotoImage(file = intenal_link + "img/SEIDN2.jpg")
    MainApplication(master)
    master.mainloop()


