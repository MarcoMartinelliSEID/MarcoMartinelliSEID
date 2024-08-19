
from sub.analog import AnalogInput
from sub.digital_input import DigitalInput

index_number = 0
group_number = 0
uni_number = 0
limit = 13
total_limit = 25

class Common:

    analog_list = []
    digital_list = []

    mms: list[AnalogInput] = []
    water: list[AnalogInput] = []
    oil: list[AnalogInput] = []
    gas: list[AnalogInput] = []

    alarm_list = []
    shutdown_list = []

    output = []

    def __init__(self, analog_list: list[AnalogInput], digital_list: list[DigitalInput]):
        self.analog_list = analog_list
        self.digital_list = digital_list # aggiunta digital_list, contentente tutti gli oggetti della classe DigitalInput già creati, da qui dovranno essere smistati anche loro per tipologia di circuito solo quelli che fanno ALARM o SH, a quel punto inseriti nella struttura insieme agli analogici PS: chiedere a SATTA come dev'essere compilata la ROW di un digitale rispetto a una generica ROW di un analogico

    def processCommonBlock(self):
        self.sortByType()
        self.structureCommon(self.mms, 'MMS')
        self.structureCommon(self.water, 'WATER')
        self.structureCommon(self.oil, 'OIL')
        self.structureCommon(self.gas, 'GAS')
        self.compileAlarmOUT()
        self.compileShutDownOUT()
        self.completeStructureCommon()

    def printBlock(self):
        i = 0; j = 0
        while i < len(self.output):
            j = 0
            while j < 32:
                print(self.output[i][j] + ' | ', end='')                
                j += 1
            print('\n---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------')
            i += 1

    def sortByType(self):
        #ANALOG
        signal: AnalogInput
        for signal in self.analog_list:
            if signal.circuit_type == 'mms':
                self.mms.append(signal)
            if signal.circuit_type == 'water':
                self.water.append(signal)
            if signal.circuit_type == 'oil':
                self.oil.append(signal)
            if signal.circuit_type == 'gas':
                self.gas.append(signal)
        #DIGITAL
        signal: DigitalInput
        for signal in self.digital_list:
            if signal.circuit_type == 'mms':
                self.mms.append(signal)
            if signal.circuit_type == 'water':
                self.water.append(signal)
            if signal.circuit_type == 'oil':
                self.oil.append(signal)
            if signal.circuit_type == 'gas':
                self.gas.append(signal)
    
    def addEmptyRow(self):
        row = [''] * 32
        return row

    def addChainRow(self):
        global uni_number
        row = [''] * 32
        row[5] = 'CMN_AL_' + str(uni_number)
        row[7] = 'SEID_Cmn_Dynamic'
        row[16] = 'Alarm'
        row[17] = 'Signal1'
        row[18] = 'X'
        return row
    
    def compileAlarmOUT(self):
        global uni_number
        i = 0; x = 15
        while i < len(self.alarm_list):
            if i == x:
                x = x + 25
                #uni_number += 1
                #self.alarm_list[i][5] = 'CMN_AL_' + str(uni_number)
                self.alarm_list[i][16] = 'Alarm'
                self.alarm_list[i][17] = 'Signal1'
                self.alarm_list[i][18] = 'X'
                self.alarm_list[i][25] = 'C. Alarm ' + str(self.alarm_list[i][25])
            i += 1
    
    def compileShutDownOUT(self):
        global uni_number
        i = 0; x = 15
        while i < len(self.shutdown_list):
            if i == x:
                x = x + 25
                uni_number += 1
                self.shutdown_list[i][5] = 'CMN_SH_' + str(uni_number)
                self.shutdown_list[i][16] = 'Shutdown'
                self.shutdown_list[i][17] = 'Signal1'
                self.shutdown_list[i][18] = 'X'
                self.shutdown_list[i][25] = 'C. Shutdown ' + str(self.shutdown_list[i][25])
            i += 1

    def structureCommon(self, array, circuit_type):
        global limit, total_limit, uni_number
        alarm_list = []; sh_list = []
        limit = 13
        total_limit = 25
        #ALARM
        total_row = self.processAlarm(array)
        if len(total_row) > 0:
            for row in total_row:
                if len(alarm_list) < limit:
                    alarm_list.append(row)
                else:
                    i = 0
                    while i < 12:
                        if i == 2:
                            out_row = self.addEmptyRow()
                            out_row[25] = circuit_type
                            uni_number += 1
                            out_row[5] = 'CMN_AL_' + str(uni_number)
                            alarm_list.append(out_row)
                        else:
                            alarm_list.append(self.addEmptyRow())
                        i += 1
                    alarm_list.append(self.addChainRow())
                    limit = limit + 25
                    total_limit = total_limit + 25
            while len(alarm_list) < total_limit:
                if (len(alarm_list)-15)%25 == 0:
                    out_row = self.addEmptyRow()
                    out_row[25] = circuit_type
                    uni_number += 1
                    out_row[5] = 'CMN_AL_' + str(uni_number)
                    alarm_list.append(out_row)
                else:
                    alarm_list.append(self.addEmptyRow())
            self.alarm_list = self.alarm_list + alarm_list #alarm_list è una lista di row --> Aarray2D

        #SHUTDOWN
        total_row = self.processShutDown(array)
        if len(total_row) > 0:
            limit = 13
            total_limit = 25
            for row in total_row:
                if len(sh_list) < limit:
                    sh_list.append(row)
                else:
                    i = 0
                    while i < 12:
                        if i == 2:
                            out_row = self.addEmptyRow()
                            out_row[25] = circuit_type
                            sh_list.append(out_row)
                        else:
                            sh_list.append(self.addEmptyRow())
                        i += 1
                    row[7] = 'SEID_Cmn_Dynamic'
                    sh_list.append(row)
                    limit = limit + 25
                    total_limit = total_limit + 25
            while len(sh_list) < total_limit:
                if (len(sh_list)-15)%25 == 0:
                    out_row = self.addEmptyRow()
                    out_row[25] = circuit_type
                    sh_list.append(out_row)
                else:
                    sh_list.append(self.addEmptyRow())
            self.shutdown_list = self.shutdown_list + sh_list

    def processAlarm(self, array):
        total_row = []
        signal: DigitalInput
        for signal in array:
            #HIGH
            if signal.io_type != 'AI': #digital signal
                if signal.error_type == 'H' or signal.error_type == 'L':
                    row = ['']*32
                    row[5] = signal.tag_number + '_' + signal.error_type
                    if signal.error_type == 'H':
                        row[16] = 'High'
                    else:
                        row[16] = 'Low'
                    row[17] = 'Signal 1'
                    row[18] = 'X'
                    row[19] = 'IN'
                    row[25] = signal.tag_number + '_' + signal.error_type
                    total_row.append(row)
            else: #analog signal
                if signal.sp_hi != 'None':
                    row = ['']*32
                    row[5] = signal.tag_number + '_H'
                    row[16] = 'High'
                    row[17] = 'Signal 1'
                    row[18] = 'X'
                    row[19] = 'IN'
                    row[25] = signal.tag_number + '_H'
                    total_row.append(row)
                #LOW
                if signal.sp_low != 'None':
                    row = ['']*32
                    row[5] = signal.tag_number + '_L'
                    row[16] = 'Low'
                    row[17] = 'Signal 1'
                    row[18] = 'X'
                    row[19] = 'IN'
                    row[25] = signal.tag_number + '_L'
                    total_row.append(row)
        return total_row

    def processShutDown(self, array):
        total_row = []
        signal: DigitalInput
        for signal in array:            
            #HIHI
            if signal.io_type != 'AI': #digital signal
                if signal.error_type == 'HH' or signal.error_type == 'LL':
                    row = ['']*32
                    row[5] = signal.tag_number + '_' + signal.error_type
                    if signal.error_type == 'HH':
                        row[16] = 'High High'
                    else:
                        row[16] = 'Low Low'
                    row[17] = 'Signal 1'
                    row[18] = 'X'
                    row[19] = 'IN'
                    row[25] = signal.tag_number + '_' + signal.error_type
                    total_row.append(row)
            else: #analog signal
                if signal.sp_hihi != 'None':
                    row = ['']*32
                    row[5] = signal.tag_number + '_HH'
                    row[16] = 'High High'
                    row[17] = 'Signal 1'
                    row[18] = 'X'
                    row[19] = 'IN'
                    row[25] = signal.tag_number + '_HH'
                    total_row.append(row)
                #LOWLOW
                if signal.sp_lowlow != 'None':
                    row = ['']*32
                    row[5] = signal.tag_number + '_LL'
                    row[16] = 'Low Low'
                    row[17] = 'Signal 1'
                    row[18] = 'X'
                    row[19] = 'IN'
                    row[25] = signal.tag_number + '_LL'
                    total_row.append(row)
        return total_row

    def completeStructureCommon(self):
        global index_number
        i = 0; limit_in = 0
        self.output = self.alarm_list + self.shutdown_list
        while i < len(self.output):
            index_number += 1
            limit_in += 1
            self.output[i][0] = 'CMN_AL_' + str(index_number)
            self.output[i][2] = 'CMN_AL_' + str(int(i / 25) + 1)
            if limit_in <= 15:
                if limit_in == 1:
                    self.output[i][7] = 'SEID_Cmn_Dynamic'
                self.output[i][19] = 'IN'
                self.output[i][26] = 'SEID_LineIN_' + str(limit_in)
                self.output[i][27] = str(limit_in)
            else:
                self.output[i][19] = 'OUT'
                self.output[i][26] = 'SEID_LineOUT_' + str(limit_in-15)
                self.output[i][27] = str(limit_in-15)
                if limit_in == 25:
                    limit_in = 0
            i += 1

            