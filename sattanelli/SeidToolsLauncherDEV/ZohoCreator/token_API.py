from tkinter import *
import tkinter as tkinter
import requests

#CREAZIONE TOKEN
def genTKN(text, client_id, client_secret, code):
    response = requests.post('https://accounts.zoho.com/oauth/v2/token', data = {
                                                                                    'grant_type': 'authorization_code',
                                                                                    'code': code,
                                                                                    'client_id': client_id,
                                                                                    'client_secret': client_secret,
                                                                                })    
    print(response.text)
    text.insert(INSERT, response.text)   
    vart = response.text    
    arr = []
    arr = str(vart).split('"')        
    newTKN = str(arr[7])
    #text.insert(INSERT, 'ACCESS TOKEN = ' + newTKN + '\n')
    return newTKN

#----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

#REFRESH TOKEN
def refreshTKN(text, client_id, client_secret, code, newTKN):
    response = requests.post('https://accounts.zoho.com/oauth/v2/token', data = {
                                                                                    'refresh_token': newTKN,
                                                                                    'client_id': client_id,
                                                                                    'client_secret': client_secret,
                                                                                    'grant_type': 'refresh_token',
                                                                                })
    vart = response.text
    arr = []
    arr = str(vart).split('"')
    newTKN = str(arr[3])
    return newTKN