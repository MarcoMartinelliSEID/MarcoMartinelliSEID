import datetime
import random

class GameMatch:
    player1 = ""
    player2 = ""
    match_number = 0
    date = datetime.date.today
    result = [] * 2

    def __init__(self, player1, player2, match_number, date):
        self.player1 = player1
        self.player2 = player2
        self.match_number = match_number
        self.date = date
    
    def set_result(self, result1, result2):
        self.result[0] = result1
        self.result[1] = result2
    
    def print(self):
        print("Match " + str(self.match_number) + ": " + self.player1 + " vs " + self.player2 + " --> date: "+ str(self.date))