# -*- coding: utf-8 -*-
"""
Created on 03/11/2020

@project: Import IOLIST to BetaCAD
@author: M. Martinelli, N. Satta
@version: 0.1
@date: 20/11/2020
"""


from sub.manager import Manager
from sub.common import Common


#-----------------------------------------------------------------------------------------------------------------------------------------------------


if __name__ == "__main__":
    io_list = Manager.loadExcel(Manager.getInternalLink() + 'NE20020IO01.xlsx', 'PLC IO LIST')
    ai_list = Manager.readIoList_AI(io_list)
    di_list = Manager.readIoList_DI(io_list)
    Manager.printArr(ai_list)
    print('\n\n\n\n')
    Manager.printArr(di_list)
    print('\n\n\n\n')


    ai_blocks = Manager.processDataBlock_AI(ai_list)
    Manager.toExcel(ai_blocks, 'Analogici')



    data = Common(ai_list, di_list)
    data.processCommonBlock()
    Manager.writeCommonToExcel(data.output, 'Comuni')



    print('\n\n\n\n')

    di_blocks = Manager.processDataBlock_DI(di_list)
    Manager.toExcel(di_blocks, 'Digitali')






