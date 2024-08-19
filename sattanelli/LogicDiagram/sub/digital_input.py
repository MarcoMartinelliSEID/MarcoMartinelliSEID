
from sub.analog import AnalogInput

index_number = 0

class DigitalInput(AnalogInput):
    
    error_type = ''

    def __init__(self, io_type, tag_number, description, device_name, error_type, circuit_type, signal_from, sp_hihi, sp_hi, sp_low, sp_lowlow, tag_part1, tag_part2):
        AnalogInput.__init__(self, io_type, tag_number, description, device_name, sp_hihi, sp_hi, sp_low, sp_lowlow, circuit_type, signal_from, tag_part1, tag_part2)
        self.io_type = io_type
        self.tag_number = tag_number
        self.description = description
        self.device_name = device_name
        if error_type != 'None':
            self.error_type = str(error_type).upper()
        else:
            self.error_type = error_type
        self.circuit_type = circuit_type
        self.signal_from = signal_from

#________________________________________________________________________________________________________________________________________________________________________________________

class DiBlock():

    digital_input = None
    parameters = []
    total_rows = []

    def __init__(self, digital_input: DigitalInput, parameters):
        self.digital_input = digital_input
        self.parameters = parameters
        self.total_rows = []
    
    def getFinalStructure(self):
        return self.total_rows
    
    def printBlockFast(self):
        print(self.total_rows)

    def printBlock(self):
        i = 0; j = 0
        #print(len(self.total_rows))
        while i < len(self.total_rows):
            j = 0
            while j < 32:
                print(self.total_rows[i][j] + ' | ', end='')                
                j += 1
            print('\n---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------')
            i += 1

    def addEmptyRow(self):
        row = [''] * 32
        return row

    def processDigitalInputBlock(self):
        self.buildStructure()
        self.completeStructure()

    def buildStructure(self):
        self.total_rows.append(self.processDI_IN())
        row_1, row_2 = self.processDelay()
        self.total_rows.append(row_1)
        self.total_rows.append(row_2)
        for i in range(12):
            self.total_rows.append(self.addEmptyRow())
        self.total_rows.append(self.processDI_OUT())
        for i in range(9):
            self.total_rows.append(self.addEmptyRow())
    
    def completeStructure(self):
        global index_number
        i = 0
        #IN
        while i < 15:
            index_number += 1
            self.total_rows[i][0] = 'DI_INDEX_' + str(index_number)
            self.total_rows[i][2] = self.digital_input.tag_number
            if i != 0:
                self.total_rows[i][6] = 'P'
                self.total_rows[i][7] = 'SEID_SingleINOUT'
            self.total_rows[i][19] = 'IN'
            self.total_rows[i][20] = str(i+1)
            self.total_rows[i][30] = '=IFERROR(INDEX(Parametri!$D$3:$D$100,MATCH(G' + str(index_number+1) + ',Parametri!$A$3:$A$100,0)),"")'
            if i < 9:                
                self.total_rows[i][21] = 'I_E_PIN0' + str(i+1)
                self.total_rows[i][22] = 'I_I_PIN0' + str(i+1)
            else:
                self.total_rows[i][21] = 'I_E_PIN' + str(i+1)
                self.total_rows[i][22] = 'I_I_PIN' + str(i+1)
            self.total_rows[i][26] = 'SEID_LineIN_' + str(i+1)
            self.total_rows[i][27] = str(i+1)
            i += 1
        #OUT
        while i < 25:
            index_number += 1
            self.total_rows[i][0] = 'DI_INDEX_' + str(index_number)
            self.total_rows[i][2] = self.digital_input.tag_number
            self.total_rows[i][7] = 'SEID_SingleINOUT'
            self.total_rows[i][19] = 'OUT'
            self.total_rows[i][20] = str(i+1-15)
            self.total_rows[i][30] = '=IFERROR(INDEX(Parametri!$D$3:$D$100,MATCH(G' + str(index_number+1) + ',Parametri!$A$3:$A$100,0)),"")'
            if i < 24:
                self.total_rows[i][21] = 'O_E_PIN0' + str(i+1-15)
                self.total_rows[i][22] = 'O_I_PIN0' + str(i+1-15)
            else:
                self.total_rows[i][21] = 'O_E_PIN' + str(i+1-15)
                self.total_rows[i][22] = 'O_I_PIN' + str(i+1-15)
            self.total_rows[i][26] = 'SEID_LineOUT_' + str(i+1-15)
            self.total_rows[i][27] = str(i+1-15)
            i += 1

    #---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
    def processDI_IN(self):
        #ROW_DI_IN
        row = self.addEmptyRow()
        row[3], row[4] = self.digital_input.tag_part1, self.digital_input.tag_part2
        row[5] = self.digital_input.tag_number + 'A'
        row[6] = str(self.selectGraphicType())
        if self.digital_input.error_type != 'None':
            row[7] = 'SEID_DI_Dynamic_V3'
        else:
            row[7] = 'SEID_SingleINOUT'
        row[8] = 'SEID_DIN_DI'
        row[9], row[10] = self.digital_input.getDescSplitted()
        row[10] = row[10] + ' A'
        row[16] = 'Digital'
        row[17] = 'Signal'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'IN_DI'
        row[31] = 'Note'
        return row

    def selectGraphicType(self):
        param = self.parameters
        i = 0
        if 'lamp' in str(self.digital_input.device_name).lower():
            while i < len(param[1]):            
                if self.digital_input.signal_from == param[1][i] and param[2][i] == 'IN' and ('LAMP' in param[0][i]):
                    return param[0][i]
                i += 1
        else:
            i = 0
            while i < len(param[1]):
                if self.digital_input.signal_from == param[1][i] and param[2][i] == 'IN':
                    return param[0][i]
                i += 1
        return 'not find'
    
    def processDelay(self):
        row_1 = self.addEmptyRow()
        row_1[18] = 'X'
        row_2 = self.addEmptyRow()
        row_2[18] = 'X'
        row_2[23] = 'Cfg_Delay'
        row_2[25] = '1s'
        return row_1, row_2

    def processDI_OUT(self):
        row = self.addEmptyRow()
        row[5] = self.digital_input.tag_number + 'A_D'
        if self.digital_input.error_type != 'None':
            row[6] = 'R'
        else:
            row[6] = 'P'
        row[9], row[10] = self.digital_input.getDescSplitted()
        row[10] = row[10] + ' A'
        row[16] = 'Activated'
        row[17] = 'Signal 1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'OUT'
        row[25] = self.digital_input.tag_number + 'A'
        return row
        

    
