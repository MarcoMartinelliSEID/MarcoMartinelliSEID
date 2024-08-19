# -*- coding: utf-8 -*-
"""
Created on Mon Sep 14 17:06:19 2020

@project: ZohoCreator
@author: M. Martinelli, N. Satta
@version: 0.2
@date: 13/10/2020

"""

import gui
import zoho_API

#--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

#MAIN PROGRAM
internal_link = zoho_API.getInternalLink()
fileTKN = open(internal_link + 'files/' + 'token.txt', 'r')
access_token = fileTKN.read()
fileTKN.close
gui.zohoCreatorGUI(access_token)