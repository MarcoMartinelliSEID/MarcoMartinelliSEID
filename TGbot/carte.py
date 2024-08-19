import time
import sys
import random
##
def main():
    class Player:

        def __init__(self, name):
            self.name = name
            self.money = 100
            self.cards = 0
            pass
    class phrex:

        def __init__(self, name, value):
            self.name = name
            self.value = value
            self.phrex = 0
            pass

    jug = phrex("Phrexian God", 3)
    pala = phrex("Phrexian Paladin", 7)
    god = phrex("Phrexian Anhillator", 13)
    admin = phrex("Phrexian Godsend", 99999999999999999999999999999999999999999999)
    p = Player("Player")
    class emb:

        def __init__(self, name):
            self.emb = 0
            self.name = name
            pass
    bbox = emb("Booster Stopper")

    pjug = emb("Phrexian jug")
    gjug = emb("god jug")
    bjug = emb("lol")

    def home():
        print("You are home. Your money:")
        print(p.money)
        time.sleep(1)
        print("1.) Your Local Card Shop")
        print("2.) Collection")   #TRADE????????????????????????????????? trade/get card graded?????
        print("3.) Get Cards Graded (On Condition)")
        print("4.) Sell cards") # make diff shops?
        print("5.) Go to a different card shop")
        print("6.) Battle")
        show = int(input())
        print(show)
        if show == 1:
            cardshop()
        elif show == 2:
            collection()
        elif show == 3:
            psa()
        elif show == 4:
            sell()
        elif show == 5:
            alt()
        elif show == 6:
            battle()        
    def bat():
        battle()
    def battle():
        print("Here is the battle arena! Choose one:")
        print("1.) Deck Information")
        print("2.) Battle")
        print("3.) Back")
        battle1 = int(input())
        if battle1 == 3:
            home()
        elif battle1 == 1:
            print("1.) Check your current decks")
            print("2.) Buy a deck")
            papi = int(input())
            if papi == 1:
                print("1.) Basic Phrexian Deck")
                print("2.) Back")
                oh = int(input())
                if oh == 1:
                    print("It contains:")
                    print("1 Coleas Admin Card ")
                    time.sleep(1)
                    print("1.) Back")
                    leave = int(input())
                    if leave == 1:
                        bat()
            elif papi == 2:
                print("No decks avilable at the moment.")
                print("1.) Back")
                papo = int(input())
                if papo == 1:
                    bat()
        elif battle1 == 2:
            print("What deck do you want to use?")
            print("1.) Basic Phrexian Deck")
            papno = int(input())
            if papno == 1:
                print("You selected the Basic Phrexian Deck!")
                time.sleep(1)
                print("You place down your 1 card, for each 50$ in that cards worth, flip a dice (3 sided), the person with the highest roll wins. ")
                print("You placed down Coleas Admin card, so you roll the dice 2 times.")
                time.sleep(1)
                print("Your opponent placed down Coleas Admin card, so they roll the dice 2 times.")
                olo = random.randint(1,3)
                if olo == 1:
                    time.sleep(3)
                    print("You rolled a 1")
                    print("You rolled a 2")
                    time.sleep(1)
                    print("Your opponent rolled a 2")
                    print("Your opponent rolled a 3")
                    time.sleep(1)
                    print("Your opponent wins.")
                    bat()
                elif olo == 2:
                    time.sleep(3)
                    print("You rolled a 3")
                    print("You rolled a 2")
                    time.sleep(1)
                    print("Your opponent rolled a 1")
                    print("Your opponent rolled a 2")
                    time.sleep(1)
                    print("You win! You got 20$!")
                    p.money += 20
                    bat()
                elif olo == 3:
                    time.sleep(3)
                    print("You rolled a 3")
                    print("You rolled a 3")
                    time.sleep(1)
                    print("Your opponent rolled a 2")
                    print("Your opponent rolled a 3")
                    time.sleep(1)
                    print("You win! You got 20$!")
                    bat()



    def alt():
        print("You can go to the following shops:")
        print("1.) Back")
        print("2.) Coleas Grand Card Emporium")

        alt = int(input())
        if alt == 1:
            home()
        if alt == 2:
            coae()
    def coaes():
        coae()
    def coae():
        print("Welcome To Coleas Grand Card Emporium.")
        print("We have a large array of cards.")
        time.sleep(1)
        print("1.) Back")
        print("2.) Buy a grab bag (1 Card) (5 Dollars)")
        co = int(input())
        if co == 1:
            alt()
        elif co == 2:
            p.money -= 5
            altme = random.randint(1,3)
            if altme == 1:
                print("You got a Phrexian Anhillator! (Value: 13)")
                bjug.emb += 1
                time.sleep(1)
                coaes()
            elif altme == 2:
                print("You got a Coleas Admin Card! (Value: 100)")
                colea.emb += 1
                time.sleep(1)
                coaes()
            elif altme == 3:
                print("You got a Phrexian God! (Value: 3)")
                time.sleep(1)
                gjug.emb += 1
                coaes()





    def cardshop():
        print("Welcome to the card shop.")
        print("1.) Buy pack of the set Phrexisland / 10 Dollars (1 Card) ")
        print("2.) Exit")
        print("3.) Buy Booster Box of the set Phrexisland / 15 Dollars (36 Packs)")
        print("4.) Buy Singles")
        cardshops = int(input())
        if cardshops == 1:
            p.money -= 10 #bbox.emb
            cardslife = random.randint(1,3)



            if cardslife == 1:
                jug.phrex += 1
                print("You got a Phrexian God! Value: 3")
                gjug.emb += 1
                home()
            elif cardslife == 2:
                pala.phrex += 1
                print("You got a Phrexian Paladin! Value: 7")
                pjug.emb += 1
                home()
            elif cardslife == 3:
                bjug.emb += 1
                god.phrex += 1
                print("You got a Phrexian Anhillator! Value: 13")
                home()

        elif cardshops == 3:
            p.money -= 15
            boostersale()

        elif cardshops == 2:
            home()
        elif cardshops == 4:
            single()
    colea = emb("Coleas Admin Card")
    def singles():
        single()
    def single():
        print("You can buy single cards:") # make cards
        print("1.) Back")
        print("2.) Coleas Admin Card (Value: 100)")
        csl = int(input())
        if csl == 1:
            cardshop()
        elif csl == 2:
            print("You got 1 Coleas Admin Card!")
            colea.emb += 1
            p.money -= 100
            singles()


    #pjug = emb("Phrexian jug") # paladin
    #gjug = emb("god jug")   #g god
    #bjug = emb("lol") # anhil
    def collection():
        print("Phrexian Paladin: (Value: 7)")
        print(pjug.emb)
        time.sleep(2)
        print("Phrexian God: (Value: 3)")
        print (gjug.emb)
        time.sleep(2)
        print("Phrexian Anhillator: (Value: 13)")
        print (bjug.emb)
        time.sleep(2)
        print("Phrexian Godsend: (Value: 10000)")
        print (a.emb)
        time.sleep(2)
        print("Graded 10 Phrexian Anhillator: (Value: 2500)")
        print (psa10.emb)
        time.sleep(2)
        print("Coleas Admin Card:")
        print(colea.emb)
        time.sleep(2)
        finalcol()



    ####
    def finalcol():
        print("1.) Home")
        papa = int(input())
        if papa == 1:
            home()
    ###
    def bboxs():
        time.sleep(1)
        boostersale()

    a = emb("aemb")
    def boostersale():
        bbox.emb += 1
        if bbox.emb == 36:
            bbox.emb -= 36
            home()
        else:
            cardslifes = random.randint(1,1000)
            if cardslifes == 1000:
                admin.phrex += 1
                print("JACKPOT!!! YOU GOT A PHREXIAN GODSEND VALUE: 10000 JACKPOT!!!")
                a.emb += 1
                bboxs()
            else:
                damn = random.randint(1,3)
                if damn == 1:
                    jug.phrex += 1
                    print("You got a Phrexian God! Value: 3")
                    gjug.emb += 1
                    bboxs()
                elif damn == 2:
                    pala.phrex += 1
                    print("You got a Phrexian Paladin! Value: 7")
                    pjug.emb += 1
                    bboxs()
                elif damn == 3:
                    god.phrex += 1
                    print("You got a Phrexian Anhillator! Value: 13")
                    bjug.emb += 1
                    bboxs()











    def psa():
        print("Welcome To The PSA Grading Company! We grade cards from 1 to 10, 1 being the worst possible, 10 being pristine and unblemished condition.")
        time.sleep(1)
        print("We only grade Phrexian Anhillators at the moment.")
        print("1.) Grade a Phrexian Anhillator (150 Dollars)")
        print("2.) Leave")
        psa = int(input())
        if psa == 2:
            home()
        if psa == 1:
            grade()

    psa10 = emb("psa 10")
    def grade():
        p.money -= 150
        bjug.emb -= 1
        bug = random.randint(1,5)
        if bug == 1:
            print("Your grade is 2")
            print("We cant case it unless its a 10. Sorry.")
            psa()
        elif bug == 2:
            print("Your grade is 4")
            print("We cant case it unless its a 10. Sorry.")
            psa()
        elif bug == 3:
            print("Your grade is 6")
            print("We cant case it unless its a 10. Sorry.")
            psa()
        elif bug == 4:
            print("Your grade is 8")
            print("We cant case it unless its a 10. Sorry.")
            psa()
        elif bug == 5:
            print("Your grade is 10")
            print("You now have a Graded 10 Phrexian Anhillator! ")
            psa10.emb += 1
            psa()

    def sells():
        sell()

    def sell():
        print("You can sell cards here! You can only sell Phrexian Anhillators at the moment.")
        print("1.) Sell")
        print("2.) Back")
        sellbob = int(input())
        if sellbob == 1:
            print("You have sold 1 Phrexian Anhillator!")
            p.money += 13
            bjug.emb -= 1
            sells()
        elif sellbob == 2:
            home()
    home()
main()

