

index_number = 0


class AnalogInput(): #separare su nuovo file e renderlo gerarchico (main class = signal, sub class = analogInput, DigitalInput)

    io_type = ''
    tag_number = ''
    description = ''
    device_name = ''
    sp_hihi = ''
    sp_hi = ''
    sp_low = ''
    sp_lowlow = ''    
    circuit_type = ''
    signal_from = ''
    tag_part1 = ''
    tag_part2 = ''

    def __init__(self, io_type, tag_number, description, device_name, sp_hihi, sp_hi, sp_low, sp_lowlow, circuit_type, signal_from, tag_part1, tag_part2):
        self.io_type = io_type
        self.tag_number = tag_number
        self.description = description
        self.device_name = device_name
        self.sp_hihi = sp_hihi
        self.sp_hi = sp_hi
        self.sp_low = sp_low
        self.sp_lowlow = sp_lowlow
        self.circuit_type = circuit_type
        self.signal_from = signal_from
        self.tag_part1 = tag_part1
        self.tag_part2 = tag_part2
    
    def print(self):
        print(str(self.io_type) + ' - ' + str(self.tag_number) + ' - ' + str(self.description) + ' - ' + str(self.device_name) + ' - ' + str(self.sp_hihi) + ' - ' + str(self.sp_hi) + ' - ' + str(self.sp_low) + ' - ' + str(self.sp_lowlow))

    def getDescSplitted(self):
        words = self.description.split(' ')
        desc1 = ''; desc2 = ''
        i = 0
        while i < len(words):
            if len(desc1) < 28 and len(desc1 + words[i]) < 28:
                desc1 = desc1 + ' ' + words[i]
            else:
                desc2 = desc2 + ' ' + words[i]
            i += 1
        return desc1, desc2

#________________________________________________________________________________________________________________________________________________________________________________________________________________________________

class AiBlock():

    analog_input = None
    parameters = []
    total_rows = []

    bypass_hihi = False
    bypass_hi = False
    bypass_low = False
    bypass_lowlow = False
    spare_hihi = False
    spare_hi = False
    spare_low = False
    spare_lowlow = False
    mos = False
    safety = False
    all_pin_sp = False
    in_num = 3
    out_num = 2    

    def __init__(self, analog_input: AnalogInput, parameters, bypass_hihi: bool, bypass_hi: bool, bypass_low: bool, bypass_lowlow: bool, mos: bool, safety: bool, spare_hihi: bool, spare_hi: bool, spare_low: bool, spare_lowlow: bool, all_pin_sp: bool):
        self.analog_input = analog_input
        self.bypass_hihi = bypass_hihi
        self.bypass_hi = bypass_hi
        self.bypass_low = bypass_low
        self.bypass_lowlow = bypass_lowlow
        self.spare_hihi = spare_hihi
        self.spare_hi = spare_hi
        self.spare_low = spare_low
        self.spare_lowlow = spare_lowlow
        self.mos = mos
        self.safety = safety
        self.all_pin_sp = all_pin_sp
        self.total_rows = []
        self.parameters = parameters

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
    
    def processAnalogInputBlock(self):
        self.buildStructure()
        self.completeStructure()
    
    #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    def completeStructure(self):
        global index_number
        i = 0
        #IN
        while i < 15:
            index_number += 1
            self.total_rows[i][0] = 'AI_INDEX_' + str(index_number)
            self.total_rows[i][2] = self.analog_input.tag_number
            self.total_rows[i][19] = 'IN'
            self.total_rows[i][20] = str(i+1)
            self.total_rows[i][30] = '=IFERROR(INDEX(Parametri!$D$3:$D$100,MATCH(G' + str(index_number+1) + ',Parametri!$A$3:$A$100,0)),"")'
            if i == 0:
                self.total_rows[i][7] = 'SEID_AI_Dynamic_V3'
            else:
                self.total_rows[i][7] = 'SEID_SingleINOUT'
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
            self.total_rows[i][0] = 'AI_INDEX_' + str(index_number)
            self.total_rows[i][2] = self.analog_input.tag_number
            self.total_rows[i][19] = 'OUT'
            self.total_rows[i][20] = str(i+1-15)
            self.total_rows[i][30] = '=IFERROR(INDEX(Parametri!$D$3:$D$100,MATCH(G' + str(index_number+1) + ',Parametri!$A$3:$A$100,0)),"")'
            self.total_rows[i][7] = 'SEID_SingleINOUT'
            if i < 24:
                self.total_rows[i][21] = 'O_E_PIN0' + str(i+1-15)
                self.total_rows[i][22] = 'O_I_PIN0' + str(i+1-15)
            else:
                self.total_rows[i][21] = 'O_E_PIN' + str(i+1-15)
                self.total_rows[i][22] = 'O_I_PIN' + str(i+1-15)
            self.total_rows[i][26] = 'SEID_LineOUT_' + str(i+1-15)
            self.total_rows[i][27] = str(i+1-15)
            i += 1
        self.total_rows[0][8] = 'SEID_DIN_AI_' + self.getTypeBlock()

    def getTypeBlock(self):
        i = 0
        count = 0
        while i < 15:
            if self.total_rows[i][18] == 'x' or self.total_rows[i][18] == 'X':
                count +=1
            i += 1
        if count <= 3:
            return '03'
        elif count <= 6:
            return '06'
        elif count <= 9:
            return '09'
        else:
            return '15'       


    #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    def buildStructure(self):
        #IN
        self.total_rows.append(self.processAI_IN())
        
        count = 0
        if self.analog_input.sp_hihi != 'None' or self.all_pin_sp:
            arr1, arr2 = self.processHiHi()
            self.total_rows.append(arr1)
            self.total_rows.append(arr2)
            if self.bypass_hihi:
                self.total_rows.append(self.processHiHiBypass())
            else:
                count += 1
        else:
            count += 3

        if self.analog_input.sp_hi != 'None' or self.all_pin_sp:
            arr1, arr2 = self.processHi()
            self.total_rows.append(arr1)
            self.total_rows.append(arr2)
            if self.bypass_hi:
                self.total_rows.append(self.processHiBypass())
            else:
                count += 1
        else:
            count += 3

        if self.analog_input.sp_low != 'None' or self.all_pin_sp:
            arr1, arr2 = self.processLow()
            self.total_rows.append(arr1)
            self.total_rows.append(arr2)
            if self.bypass_low:
                self.total_rows.append(self.processLowBypass())
            else:
                count += 1
        else:
            count += 3

        if self.analog_input.sp_lowlow != 'None' or self.all_pin_sp:
            arr1, arr2 = self.processHi()
            self.total_rows.append(arr1)
            self.total_rows.append(arr2)
            if self.bypass_lowlow:
                self.total_rows.append(self.processLowLowBypass())
            else:
                count += 1
        else:
            count += 3

        if self.mos:
            self.total_rows.append(self.processMOS())
        else:
            count += 1
        if self.safety:
            self.total_rows.append(self.processSafety())
        else:
            count += 1
        
        #EMPTY IN
        while count > 0:
            empty_row = [''] * 32
            self.total_rows.append(empty_row)
            count -= 1

        #OUT
        self.total_rows.append(self.processAI_OUT())
        
        if self.analog_input.sp_hihi != 'None' or self.all_pin_sp:
            self.total_rows.append(self.processHiHi_OUT())
        else:
            count += 1
        if self.analog_input.sp_hi != 'None' or self.all_pin_sp:
            self.total_rows.append(self.processHi_OUT())
        else:
            count += 1
        if self.analog_input.sp_low != 'None' or self.all_pin_sp:
            self.total_rows.append(self.processLow_OUT())
        else:
            count += 1
        if self.analog_input.sp_lowlow != 'None' or self.all_pin_sp:
            self.total_rows.append(self.processLowLow_OUT())
        else:
            count += 1

        if self.mos:
            self.total_rows.append(self.processMOS_OUT())
        else:
            count += 1
        
        if self.spare_hihi and (self.analog_input.sp_hihi != 'None' or self.all_pin_sp):
            self.total_rows.append(self.processHiHiSpare_OUT())
        else:
            count += 1
        if self.spare_hi and (self.analog_input.sp_hi != 'None' or self.all_pin_sp):
            self.total_rows.append(self.processHiSpare_OUT())
        else:
            count += 1
        if self.spare_low and (self.analog_input.sp_low != 'None' or self.all_pin_sp):
            self.total_rows.append(self.processLowSpare_OUT())
        else:
            count += 1
        if self.spare_hihi and (self.analog_input.sp_lowlow != 'None' or self.all_pin_sp):
            self.total_rows.append(self.processLowLowSpare_OUT())
        else:
            count += 1
        
        #EMPTY OUT
        while count > 0:
            empty_row = [''] * 32
            self.total_rows.append(empty_row)
            count -= 1
        

    #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    def processAI_IN(self):
        #ROW_AI_IN
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[5] = self.analog_input.tag_number + '_RAW'
        row[6] = str(self.selectGraphicType())
        row[9], row[10] = self.analog_input.getDescSplitted()        
        row[10] = row[10] + ' A'
        row[16] = 'Analog'
        row[17] = 'Signal'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'Inp_PVA'
        row[31] = 'Note'
        return row
    
    def selectGraphicType(self):
        param = self.parameters
        i = 0
        if 'lamp' in str(self.analog_input.device_name).lower():
            while i < len(param[1]):            
                if self.analog_input.signal_from == param[1][i] and param[2][i] == 'IN' and ('LAMP' in param[0][i]):
                    return param[0][i]
                i += 1
        else:
            i = 0
            while i < len(param[1]):
                if self.analog_input.signal_from == param[1][i] and param[2][i] == 'IN':
                    return param[0][i]
                i += 1
        return 'not found'
            
    
    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processHiHi(self):
        #ROW_HIHI
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[3] = row[3] + '-SP-HH'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' HH SP'
        row[16] = 'High High'
        row[17] = 'SetPoint'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'OSet_HiHiLim'
        row[31] = 'Rimando per HH'
        #ROW_HIHI
        row_2 = [''] * 32
        row_2[2] = self.analog_input.tag_number
        row_2[3], row_2[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row_2[6] = 'P'
        row_2[18] = 'X'
        row_2[19] = 'IN'
        row_2[23] = 'Cfg_HiHiDelay'
        row_2[24] = str(1) +'s'
        string = str(self.analog_input.device_name).lower()
        if string.find('temperature') != -1:
            row_2[24] = str(5) +'s'
        if string.find('rtd') != -1:
            row_2[24] = str(5) +'s'
        if string.find('pt100') != -1:
            row_2[24] = str(5) +'s'
        return row, row_2

    def processHiHiBypass(self):
        #ROW_HIHI_BYPASS
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[6] = 'P'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'Cfg_HiHIBypass'
        return row

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processHi(self):
        #ROW_HI
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[3] = row[3] + '-SP-H'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()        
        row[10] = row[10] + ' H SP'
        row[16] = 'High'
        row[17] = 'SetPoint'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'OSet_HiLim'
        row[31] = 'Rimando per H'
        #ROW_HI
        row_2 = [''] * 32
        row_2[2] = self.analog_input.tag_number
        row_2[3], row_2[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row_2[6] = 'P'
        row_2[18] = 'X'
        row_2[19] = 'IN'
        row_2[23] = 'Cfg_HiDelay'
        row_2[24] = str(1) +'s'
        string = str(self.analog_input.device_name).lower()
        if string.find('temperature') != -1:
            row_2[24] = str(5) +'s'
        if string.find('rtd') != -1:
            row_2[24] = str(5) +'s'
        if string.find('pt100') != -1:
            row_2[24] = str(5) +'s'
        return row, row_2

    def processHiBypass(self):
        #RIW_HI_BYPASS
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[6] = 'P'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'Cfg_HiBypass'
        return row

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processLow(self):
        #ROW_LOW
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[3] = row[3] + '-SP-L'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()        
        row[10] = row[10] + ' L SP'
        row[16] = 'Low'
        row[17] = 'SetPoint'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'OSet_LoLim'
        row[31] = 'Rimando per L'
        #ROW_LOW
        row_2 = [''] * 32
        row_2[2] = self.analog_input.tag_number
        row_2[3], row_2[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row_2[6] = 'P'
        row_2[18] = 'X'
        row_2[19] = 'IN'
        row_2[23] = 'Cfg_LoDelay'
        row_2[24] = str(1) +'s'
        string = str(self.analog_input.device_name).lower()
        if string.find('temperature') != -1:
            row_2[24] = str(5) +'s'
        if string.find('rtd') != -1:
            row_2[24] = str(5) +'s'
        if string.find('pt100') != -1:
            row_2[24] = str(5) +'s'
        return row, row_2

    def processLowBypass(self):
        #RIW_LOW_BYPASS
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[6] = 'P'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'Cfg_LoBypass'
        return row

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processLowLow(self):
        #ROW_LOWLOW
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[3] = row[3] + '-SP-LL'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()        
        row[10] = row[10] + ' LL SP'
        row[16] = 'Low Low'
        row[17] = 'SetPoint'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'OSet_LoLoLim'
        row[31] = 'Rimando per LL'
        #ROW_LOWLOW
        row_2 = [''] * 32
        row_2[2] = self.analog_input.tag_number
        row_2[3], row_2[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row_2[6] = 'P'
        row_2[18] = 'X'
        row_2[19] = 'IN'
        row_2[23] = 'Cfg_LoLoDelay'
        row_2[24] = str(1) +'s'
        string = str(self.analog_input.device_name).lower()
        if string.find('temperature') != -1:
            row_2[24] = str(5) +'s'
        if string.find('rtd') != -1:
            row_2[24] = str(5) +'s'
        if string.find('pt100') != -1:
            row_2[24] = str(5) +'s'
        return row, row_2

    def processLowLowBypass(self):
        #RIW_LOWLOW_BYPASS
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[6] = 'P'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'Cfg_LoLoBypass'
        return row

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processMOS(self):
        #ROW_MOS
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[3] = row[3] + '-MOS'
        row[6] = 'P'
        row[16] = 'MOS'
        row[17] = 'Trigger'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'O_CmdMOS'
        row[31] = 'Rimando per Analogico pronto all\'uso'
        return row

    def processSafety(self):
        #ROW_SAFETY
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[3], row[4] = self.analog_input.tag_part1, self.analog_input.tag_part2
        row[6] = 'P'
        row[18] = 'X'
        row[19] = 'IN'
        row[23] = 'Safety Signal'
        row[31] = 'Rimando per Analogico pronto all\'uso'
        return row

        #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processAI_OUT(self):
        #ROW_AI_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_PV'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()        
        row[10] = row[10] + ' A'
        row[16] = 'Analog'
        row[17] = 'Signal'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Val'
        return row

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processHiHi_OUT(self):
        #ROW_HIHI_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_HH'
        row[6] = 'R'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' HH'
        row[16] = 'High High'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_HiHi'
        row[25] = self.analog_input.tag_number + '_HH'
        return row

    def processHi_OUT(self):
        #ROW_HI_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_H'
        row[6] = 'R'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' H'
        row[16] = 'High'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_Hi'
        row[25] = self.analog_input.tag_number + '_H'
        return row

    def processLow_OUT(self):
        #ROW_LOW_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_L'
        row[6] = 'R'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' L'
        row[16] = 'Low'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_lo'
        row[25] = self.analog_input.tag_number + '_L'
        return row

    def processLowLow_OUT(self):
        #ROW_LOWLOW_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_LL'
        row[6] = 'R'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' LL'
        row[16] = 'Low Low'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_lolo'
        row[25] = self.analog_input.tag_number + '_LL'
        return row    

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processMOS_OUT(self):
        #ROW_MOS_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_MOS'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' MOS ACTIVATED'
        row[16] = 'Activated'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_MOS'
        return row    

    #-----------------------------------------------------------------------------------------------------------------------------------------------------

    def processHiHiSpare_OUT(self):
        #ROW_HIHI_SPARE_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_EXTRA_HIHI'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' HH'
        row[16] = 'High High'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_HiHi'
        return row 
    
    def processHiSpare_OUT(self):
        #ROW_HI_SPARE_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_EXTRA_HI'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' H'
        row[16] = 'High'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_Hi'
        return row  
    
    def processLowSpare_OUT(self):
        #ROW_LOW_SPARE_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_EXTRA_LOW'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' L'
        row[16] = 'Low'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_lo'
        return row  

    def processLowLowSpare_OUT(self):
        #ROW_HIHI_SPARE_OUT
        row = [''] * 32
        row[2] = self.analog_input.tag_number
        row[5] = self.analog_input.tag_number + '_EXTRA_LOWLOW'
        row[6] = 'P'
        row[9], row[10] = self.analog_input.getDescSplitted()
        row[10] = row[10] + ' LL'
        row[16] = 'Low Low'
        row[17] = 'Signal1'
        row[18] = 'X'
        row[19] = 'OUT'
        row[23] = 'Sts_lolo'
        return row  