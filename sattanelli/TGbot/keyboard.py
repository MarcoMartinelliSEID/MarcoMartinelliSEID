import pyautogui
import time
import random



time.sleep(5)
# Simula la pressione del tasto "W" ogni 3 secondi per 4 volte
for i in range(100000):
    t = random.randint(1, 10)
    pyautogui.keyDown("w")
    pyautogui.press(" ")
    time.sleep(t)
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    pyautogui.keyUp("w")
    pyautogui.press("f")
    time.sleep(0.5)
    pyautogui.press("tab")
    time.sleep(0.5)
    pyautogui.press("r")
    time.sleep(2)
    pyautogui.press("2")
    pyautogui.press(" ")
    time.sleep(3)
    pyautogui.keyDown("s")
    time.sleep(3)
    pyautogui.keyUp("s")
