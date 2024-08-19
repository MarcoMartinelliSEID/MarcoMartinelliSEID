
from openpyxl import load_workbook
from tkinter import *
from tkinter import filedialog
import time
import tkinter as tkinter
import tkinter.font as font
import requests
import os
import token_API
import zoho_API
import tkinter as tk
import tkinter.messagebox


internal_link = zoho_API.getInternalLink()  #cambiare solo nella variabile generale in zoho_API
client_id = '1000.HERUAU0LPHBFUQ3RQ27GQISI6WA6IJ'
client_secret = '82f26c5105bef1c251197d8b27f9bae04c6c08ee6d'
code = '1000.c0bbca41289f30320848585bc9e5d4a1.7fc7936831e37b42ed087054baa1c793'
user = 'bennice2'
app = 'tabscomuni1'
report = 'IntestazionePrj_Report'
report2 = 'PrjStatus_Report'
Id = '3343883000000502003'
id_record = ''
url = 'https://creator.zoho.com/api/v2/' + user + '/' + app + '/report/' + report
url2 = 'https://creator.zoho.com/api/v2/' + user + '/' + app + '/report/' + report2
#access_token = None
refresh_token = None
prj_status_array = []
new_status = ''
status_name = ''
note_record = ''

#DA FARE: funzione con text.insert è text.see end
#--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

class HoverButton(tkinter.Button):
    def __init__(self, master, **kw):
        tkinter.Button.__init__(self,master=master,**kw)
        self.defaultBackground = self["background"]
        self.bind("<Enter>", self.on_enter)
        self.bind("<Leave>", self.on_leave)

    def on_enter(self, e):
        self['background'] = self['activebackground']

    def on_leave(self, e):
        self['background'] = self.defaultBackground

#--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



def zohoCreatorGUI(token):

    access_token = token

    def enter(event):
        getRecord()
    
    def askUpdate():
        question = 'NEW JOB STATUS: ' + str(status_name.upper()) + '\nDo you want to continue?'
        msg = tkinter.messagebox.askquestion("Confirm update request", question)
        if msg == 'no':
            return False
        else:
            return True
    
    def warningToken():
        msg = tkinter.messagebox.showerror('Authorization denied', 'Please, request to access')

    def genToken():
        #global access_token
        global refresh_token
        if access_token == None:
            refresh_token = token_API.genTKN(text, client_id, client_secret, code)
            fileTKN = open(internal_link + 'files/' + 'token.txt', 'w')
            fileTKN.write(refresh_token)
            fileTKN.close
            #label_token.configure(text = refresh_token)
        else:
            refresh_token = token_API.refreshTKN(text, client_id, client_secret, code, access_token)
            #label_token.configure(text = 'Autorization: ' + refresh_token)
        getRecordStatus()

    def getRecordStatus():
        zoho_API.getRecordStatus('csv', text, url2, refresh_token)
        lines = []
        with open(internal_link + 'files/' + 'json.txt') as my_file:
            flag = True
            for line in my_file:
                lines2 = line.split('@')
                prj_status_array.append(lines2)
                if(flag):
                    flag = False
                    continue
                lines.append(lines2[0])
        my_file.close
        variable.set('')
        opt['menu'].delete(0, 'end')

        # nuova lista tendina
        nuovoMenu = []
        nuovoMenu = lines
        for choice in nuovoMenu:
            opt['menu'].add_command(label=choice, command = tk._setit(variable, choice))

    def getRecord():
        global id_record
        global note_record
        if refresh_token == None:
            genToken()
        #record semplice
        simple_report = 'IntestazionePrjSimple'
        url = 'https://creator.zoho.com/api/v2/' + user + '/' + app + '/report/' + simple_report
        job_url = url + '?criteria=JobID=="' + entry1.get() + '"'
        id_record, note_record = zoho_API.getRecord(text, job_url, refresh_token)
        #label_job.configure(text = id_record + ' ' + note_record)

        #record completo
        url = 'https://creator.zoho.com/api/v2/' + user + '/' + app + '/report/' + report
        job_url = url + '?criteria=JobID=="' + entry1.get() + '"'
        labels = [label_job1, label_job2, label_job3, label_job4, label_job5, label_job6]
        zoho_API.getCompleteRecord(text, labels, job_url, refresh_token)


    def updateRecordID():
        global id_record
        global note_record
        global new_status
        global status_name        
        if askUpdate() == False:
            return None
        url_record = url + '/' + id_record
        zoho_API.updateRecord(text, url_record, new_status, status_name, note_record, refresh_token)

    #funzione che viene lanciata quando un elemento del menu a tendina viene selezionato
    def selected(*args):
        global prj_status_array
        global new_status
        global status_name
        prefix = zoho_API.getPrefix('csv')
        i = 0        
        while(i != len(prj_status_array)):
            arr = prj_status_array[i]
            if(arr[0] == str(variable.get())):
                #text.insert(INSERT, arr[0] + '\n')
                #text.insert(INSERT, prefix + arr[1] + '\n')
                new_status = zoho_API.getPrefix('csv') + arr[1]
                new_status = new_status[0:-1]
                status_name = arr[0]
                #label_exit.configure(text = 'New Status: ' + status_name)
            i += 1


    #OPEN WINDOW
    GUI = Tk()
    GUI.iconbitmap(internal_link + 'img/' + 'seid.ico')
    GUI.bind('<Return>', enter)
    logo = PhotoImage(file = internal_link + 'img/' + 'SEIDN3.jpg')
    image_entry1 = PhotoImage(file = internal_link + 'img/' + 'entry1.png')
    image_entry1 = image_entry1.subsample(3,2)
    image_menu = PhotoImage(file = internal_link + 'img/' + '1.png')
    image_menu2 = PhotoImage(file = internal_link + 'img/' + '2.png')
    image_menu3 = PhotoImage(file = internal_link + 'img/' + '3.png')
    image_menu4 = PhotoImage(file = internal_link + 'img/' + '4.png')
    image_menu5 = PhotoImage(file = internal_link + 'img/' + 'expanddown.png')
            
    #FINESTRA
    GUI.title('Zoho Creator Interface')
    GUI.geometry("1050x700")
    GUI.config(background = "black")

    #FONT
    font1 = font.Font(family='Helvetica', size=8, weight='bold')
    font2 = font.Font(size=9, weight='bold')

    # TITOLO SCHERMATA
    label_space = Label(GUI, text = "", font = font2, width = 147, height = 1, fg = "white", background = "#382222")
    label_job = Label(GUI, text = "", image = image_entry1, bd=0)
    label_job1 = Label(GUI, text = "", font = font2, width = 100, height = 4, wraplength=800, borderwidth=2, relief="flat", fg = "yellow", background = "#404040")
    label_job2 = Label(GUI, text = "", font = font2, width = 100, height = 4, wraplength=110, borderwidth=2, relief="flat", fg = "white", background = "#404040")
    label_job3 = Label(GUI, text = "", font = font2, width = 100, height = 4, wraplength=110, borderwidth=2, relief="flat", fg = "white", background = "#404040")
    label_job4 = Label(GUI, text = "", font = font2, width = 100, height = 4, wraplength=110, borderwidth=2, relief="flat", fg = "white", background = "#404040")
    label_job5 = Label(GUI, text = "", font = font2, width = 100, height = 4, wraplength=110, borderwidth=2, relief="flat", fg = "white", background = "#404040")

    label_job11 = Label(GUI, text = "     Commessa:     ", font = font2, width = 20, height = 4, wraplength=800, anchor=CENTER, borderwidth=2, relief="flat", fg = "yellow", background = "#202020")
    label_job22 = Label(GUI, text = "     Stato:     ", font = font2, width = 20, height = 4, wraplength=110, anchor=CENTER, borderwidth=2, relief="flat", fg = "white", background = "#202020")
    label_job33 = Label(GUI, text = "     PM:     ", font = font2, width = 20, height = 4, wraplength=110, anchor=CENTER, borderwidth=2, relief="flat", fg = "white", background = "#202020")
    label_job44 = Label(GUI, text = "     PE:     ", font = font2, width = 20, height = 4, wraplength=110, anchor=CENTER, borderwidth=2, relief="flat", fg = "white", background = "#202020")
    label_job55 = Label(GUI, text = "     NOTE:     ", font = font2, width = 20, height = 4, wraplength=110, anchor=CENTER, borderwidth=2, relief="flat", fg = "white", background = "#202020")

    #label_job6 = Label(GUI, text = "", font = font2, width = 120, height = 4, wraplength=110, borderwidth=2, relief="flat", fg = "white", background = "#404040")
    #labelLogo = Label(FunctGen, image=logo, bd = 0)

    #BUTTON
    #button_token = HoverButton(GUI, text = "Refresh Token   ", command = genToken, image = image_menu, compound=RIGHT, width=180, height=55, bg='#292626', fg='#ffffff', activebackground='#648062', activeforeground='#ffffff', bd = 0)  
    #button_elabora = HoverButton(GUI, text = "GetRecord Status", command = getRecordStatus, width=25, height=3, bg='#292626', fg='#ffffff', activebackground='#6D6F89', activeforeground='#ffffff', bd = 0)
    button_output = HoverButton(GUI, text = "updateRecordID   ", command = updateRecordID, image = image_menu2, compound=RIGHT, width=180, height=55, bg='#292626', fg='#ffffff', activebackground='#6D6F89', activeforeground='#ffffff', bd = 0)
    button_job = HoverButton(GUI, text = "Import Job Data   ", command = getRecord, image = image_menu3, compound=RIGHT, width=180, height=55, bg='#292626', fg='#ffffff', activebackground='#6D6F89', activeforeground='#ffffff', bd = 0)
    button_exit = HoverButton(GUI, text = "        Chiudi          ", command = exit, image = image_menu4, compound=RIGHT, width=180, height=55, bg='#292626', fg='#ffffff', activebackground='#6D6F89', activeforeground='#ffffff', bd = 0)

    #button_token['font'] = font1
    #button_elabora['font'] = font1
    button_output['font'] = font1
    button_exit['font'] = font1
    button_job['font'] = font1

    #Struttura
    label_job.grid(column = 1, row = 1)
    label_job1.grid(column = 3, row = 1)
    label_job2.grid(column = 3, row = 2)
    label_job3.grid(column = 3, row = 3)
    label_job4.grid(column = 3, row = 4)
    label_job5.grid(column = 3, row = 5)
    label_job11.grid(column = 2, row = 1)
    label_job22.grid(column = 2, row = 2)
    label_job33.grid(column = 2, row = 3)
    label_job44.grid(column = 2, row = 4)
    label_job55.grid(column = 2, row = 5)
    #label_job6.grid(column = 2, row = 6)
    label_space.grid(column = 1, row = 6, columnspan = 3)
    #button_token.grid(column = 1, row = 1)
    #button_elabora.grid(column = 1, row = 2)
    button_output.grid(column = 1, row = 3)
    button_job.grid(column = 1, row = 2)
    button_exit.grid(column = 1, row = 5)
    #labelLogo.grid(column = 1, row = 5)

    #scrollText
    frame = Frame(GUI, width=385, height=300, bd=0, relief=SUNKEN)
    frame.grid_rowconfigure(0, weight=1)
    frame.grid_columnconfigure(0, weight=1)
    xscrollbar = Scrollbar(frame, orient=HORIZONTAL)
    #xscrollbar.grid(row=1, column=0, sticky=E+W)
    yscrollbar = Scrollbar(frame)
    #yscrollbar.grid(row=0, column=1, sticky=N+S)
    text = Text(frame, width=105, height=24, wrap=NONE, bd=0, xscrollcommand=xscrollbar.set, yscrollcommand=yscrollbar.set, fg = "#4bc973", background = "#222222")
    text.grid(row=0, column=0, sticky=N+S+E+W)
    xscrollbar.config(command=text.xview)
    yscrollbar.config(command=text.yview)
    frame.grid(row=9, column=2, columnspan=2)

    #Menu a tendina
    OptionList = ['EMPTY']
    variable = StringVar(GUI)
    variable.set(OptionList[0])
    opt = OptionMenu(GUI, variable, *OptionList)
    opt.config(font=('Helvetica', 8), image = image_menu5, compound=RIGHT, width=140, height=40, wraplength=90, bd=0, relief='flat', bg='#292626', fg='white', activebackground='#292626', activeforeground='#ffffff')
    opt["menu"].config(bd=0, bg='#292626', fg='white', activebackground='#595656', activeforeground='#ffffff')
    #opt.focus()
    #opt["menu"].focus()
    opt.grid(column = 1, row = 4,)
    variable.trace("w", selected)

    #ENTRY text
    name = StringVar()
    entry1 = Entry(GUI, width = 9, font=('Helvetica', 14), fg = 'black', textvariable = StringVar(), relief="flat", bd=1, background = '#b3b3b3')
    entry1.grid(column = 1, row = 1, columnspan = 1) #sticky="W" for align
    entry1.insert(INSERT, '[Insert Job]')
    entry1.focus()

    #loop window
    GUI.mainloop()



#--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

zohoCreatorGUI('')