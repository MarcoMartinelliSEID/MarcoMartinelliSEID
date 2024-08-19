import os
import time
from tkinter import *
from BitToPLC.Segnale import Segnale
from enum import Enum


class Gestore:

    class Type(Enum):

    

    #Funzione per le nuove IO List con intestazione di colonna
    @staticmethod
    def getColumnData(ioList):
        column_data = [1, 1, 1, 1, 1, 1]
        y = 1
        while y != 50:
            if (str(ioList.cell(1, y).value) == '#Card'):
                column_data[0] = y
            if (str(ioList.cell(1, y).value) == '#TAG'):
                column_data[1] = y
            if (str(ioList.cell(1, y).value) == '#Descr'):
                column_data[2] = y
            if (str(ioList.cell(1, y).value) == '#PLCAddr'):
                column_data[3] = y
            if (str(ioList.cell(1, y).value) == '#RedCard'):
                column_data[4] = y
            if (str(ioList.cell(1, y).value) == '#PLCRedAddr'):
                column_data[5] = y
            y += 1
        return column_data


    @staticmethod
    def readSignals(ioList, text2, x, column_data, descr_length, signal_types_list, signal_accepted_types):
        card = column_data[0];          tag = column_data[1];               descr = column_data[2]
        address = column_data[3];       redundant = column_data[4];         r_address = column_data[5]
        i = 0
        try:
            for type in signal_accepted_types:                
                while str(ioList.cell(x, descr).value) != 'None':
                    signal = Gestore.getRedSignal(card, descr, descr_length, ioList, address, tag, x)
                    if signal.scheda[0:len(type)] == type:
                        signal_types_list[i].append(signal)
                        if str(ioList.cell(x, redundant).value) != 'None':
                            signal_2 = Gestore.getRedSignal(card, descr, descr_length, ioList, r_address, tag, x)
                            signal_types_list[8].append(signal_2)
                i += 1
        except:
            text2.insert(INSERT, 'Errore: Foglio IOLIST non compatibile.\n')
            text2.see("end")
            file_log = open("log.txt", "a")
            file_log.write(time.ctime() + ' | ' + os.getlogin() + ': ' + 'Errore: Foglio IOLIST non compatibile.' + '\n')
            file_log.close()

    @staticmethod
    def getRedSignal(card, descr, descr_length, ioList, r_address, tag, x):
        return Segnale(str(ioList.cell(x, tag).value), str(ioList.cell(x, card).value),
                       str(ioList.cell(x, descr).value), str(ioList.cell(x, r_address).value),
                       int(descr_length))

    @staticmethod
    def printOp(text, signal_types_list):
        print()
        print(str(len(signal_types_list[0])) + '\tAI Signals found')
        print(str(len(signal_types_list[0])) + '\tAO Signals found')
        print(str(len(signal_types_list[0])) + '\tDI Signals found')
        print(str(len(signal_types_list[0])) + '\tDO Signals found')

        print(str(len(signal_types_list[0])) + '\tRAI Signals found')
        print(str(len(signal_types_list[0])) + '\tRAO Signals found')
        print(str(len(signal_types_list[0])) + '\tRDI Signals found')
        print(str(len(signal_types_list[0])) + '\tRDO Signals found')

        print(str(len(signal_types_list[0])) + '\tSAI Signals found')
        print(str(len(signal_types_list[0])) + '\tSAO Signals found')
        print(str(len(signal_types_list[0])) + '\tSDI Signals found')
        print(str(len(signal_types_list[0])) + '\tSDO Signals found')

        print(str(len(signal_types_list[0])) + '\tRSAI Signals found')
        print(str(len(signal_types_list[0])) + '\tRSAO Signals found')
        print(str(len(signal_types_list[0])) + '\tRSDI Signals found')
        print(str(len(signal_types_list[0])) + '\tRSDO Signals found')

        text.insert(INSERT, str(len(AI)) + '\tAI Signals found' + '\n')
        text.insert(INSERT, str(len(AO)) + '\tAO Signals found' + '\n')
        text.insert(INSERT, str(len(DI)) + '\tDI Signals found' + '\n')
        text.insert(INSERT, str(len(DO)) + '\tDO Signals found' + '\n')
        text.see("end")

        text.insert(INSERT, str(len(RAI)) + '\tRAI Signals found' + '\n')
        text.insert(INSERT, str(len(RAO)) + '\tRAO Signals found' + '\n')
        text.insert(INSERT, str(len(RDI)) + '\tRDI Signals found' + '\n')
        text.insert(INSERT, str(len(RDO)) + '\tRDO Signals found' + '\n')
        text.see("end")

        text.insert(INSERT, str(len(SAI)) + '\tSAI Signals found' + '\n')
        text.insert(INSERT, str(len(SAO)) + '\tSAO Signals found' + '\n')
        text.insert(INSERT, str(len(SDI)) + '\tSDI Signals found' + '\n')
        text.insert(INSERT, str(len(SDO)) + '\tSDO Signals found' + '\n')
        text.see("end")

        text.insert(INSERT, str(len(RSAI)) + '\tRSAI Signals found' + '\n')
        text.insert(INSERT, str(len(RSAO)) + '\tRSAO Signals found' + '\n')
        text.insert(INSERT, str(len(RSDI)) + '\tRSDI Signals found' + '\n')
        text.insert(INSERT, str(len(RSDO)) + '\tRSDO Signals found' + '\n')

        text.insert(INSERT, str(len(RTD)) + '\tRTD Signals found' + '\n')
        text.see("end")

    @staticmethod
    def Elaboration(filename2, fileBit, bits, text, text2, label_file_explorer3, AI, AO, DI, DO, SAI, SAO, SDI, SDO, RAI, RAO, RDI, RDO, RSAI, RSAO, RSDI, RSDO, RTD):
        #Normal
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy AI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy AI in progress...\n')
        Segnale.copyAI(AI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy AO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy AO in progress...\n')
        Segnale.copyAO(AO, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy DI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy DI in progress...\n')
        Segnale.copyDI(DI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy DO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy DO in progress...\n')
        Segnale.copyDO(DO, bits, text, text2, label_file_explorer3)
        #RTD
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RTD in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RTD in progress...\n')
        Segnale.copyRTD(RTD, bits, text, text2, label_file_explorer3)
        #Safety
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SAI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SAI in progress...\n')
        Segnale.copySAI(SAI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SAO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SAO in progress...\n')
        Segnale.copySAO(SAO, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SDI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SDI in progress...\n')
        Segnale.copySDI(SDI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SDO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy SDO in progress...\n')
        Segnale.copySDO(SDO, bits, text, text2, label_file_explorer3)
        #Redundant
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RAI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RAI in progress...\n')
        if not RAI:
            Segnale.copyRAI(AI, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRAI(RAI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RAO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RAO in progress...\n')
        if not RAO:
            Segnale.copyRAO(AO, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRAO(RAO, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RDI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RDI in progress...\n')
        if not RDI:
            Segnale.copyRDI(DI, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRDI(RDI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RDO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RDO in progress...\n')
        if not RDO:
            Segnale.copyRDO(DO, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRDO(RDO, bits, text, text2, label_file_explorer3)
        #Redundant-Safety
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSAI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSAI in progress...\n')
        if not RSAI:
            Segnale.copyRSAI(SAI, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRSAI(RSAI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSAO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSAO in progress...\n')
        if not RSAO:
            Segnale.copyRSAO(SAO, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRSAO(RSAO, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSDI in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSDI in progress...\n')
        if not RSDI:
            Segnale.copyRSDI(SDI, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRSDI(RSDI, bits, text, text2, label_file_explorer3)
        print('\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSDO in progress...\n')
        text.insert(INSERT, '\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\nCopy RSDO in progress...\n')
        if not RSDO:
            Segnale.copyRSDO(SDO, bits, text, text2, label_file_explorer3)
        else:
            Segnale.copyRSDO(RSDO, bits, text, text2, label_file_explorer3)

        print('\nSaving...')
        text.insert(INSERT, '\nSaving...\n')
        fileBit.save(filename2)
        print('\nDone.')
        text.insert(INSERT, '\nDone.\n')
        text.see("end")