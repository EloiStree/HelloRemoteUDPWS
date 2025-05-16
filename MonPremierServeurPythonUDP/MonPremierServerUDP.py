
# # =============== PART 1 ===============
# # pip install PyAutoGUI
# import pyautogui
# import time

# print("Hello Hordes!")



# # Petite pause pour te laisser le temps de te positionner sur le bon champ
# time.sleep(2)

# # Appuie sur Tab
# pyautogui.press('tab')

# while True:
#     # Appuie 10 fois sur la touche '1'
#     for _ in range(10):
#         time.sleep(1.6)
#         pyautogui.keyDown('1')
#         time.sleep(0.1) 
#         pyautogui.keyUp('1')



# VK_TAB	0x09	Tab key
# VK_RETURN	0x0D	Return key

# VK_LEFT	0x25	Left arrow key
# VK_UP	0x26	Up arrow key
# VK_RIGHT	0x27	Right arrow key
# VK_DOWN	0x28	Down arrow key
# VK_SPACE	0x20	Spacebar key

# `M`	0x4D	M key
# `B`	0x42	B key

# `0`	0x30	0 key
# `1`	0x31	1 key
# `2`	0x32	2 key
# `3`	0x33	3 key
# `4`	0x34	4 key
# `5`	0x35	5 key
# `6`	0x36	6 key
# `7`	0x37	7 key
# `8`	0x38	8 key
# `9`	0x39	9 key


# =============== PART 2 ===============
# pip install pywin32
# Essayons plutôt d'envoyer le Ctrl+V avec ctypes
import ctypes
import win32gui
import time  # Ajout manquant pour utiliser time.sleep
import socket
import struct


# Définissons un port sur l'ordinateur pour écouter les messages UDP
int_port_listen = 7073
ipv4_mask = "127.0.0.1"
ipv4_mask = "0.0.0.0"

# Définissons une touche à utiliser pour ouvrir le chat dans World of Warcraft
string_key_for_wow_chat = "enter"
hexadecimal_key_for_wow_chat = 0x0D
windows_to_target = "Hordes"

# Utilisé pour envoyer des événements de pression ou de relâchement de touche
WM_KEYDOWN = 0x0100
WM_KEYUP = 0x0101

# Définir les codes de touches virtuelles nécessaires
# https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
VK_CONTROL = 0x11
VK_V = 0x56
VK_ENTER = 0x0D
VK_BACKSPACE = 0x08

VK_TABULATION = 0x09
VK_1 = 0x31
VK_2 = 0x32
VK_3 = 0x33
VK_4 = 0x34
VK_5 = 0x35
VK_6 = 0x36
VK_7 = 0x37
VK_8 = 0x38
VK_9 = 0x39
VK_0 = 0x30

VK_ENTER = 0x0D # entrée 13
VK_LEFT = 0x25 # gauche 37
VK_UP = 0x26 # haut 38
VK_RIGHT = 0x27 # droite 39
VK_DOWN = 0x28 # bas 40
VK_SPACE = 0x20 # espace  32 
VK_M = 0x4D # map  77
VK_B = 0x42 # inventaire 66

int_key_enter =1013
int_key_left = 1037
int_key_up = 1038
int_key_right = 1039
int_key_down = 1040
int_key_space = 1032
int_key_m = 1077
int_key_b = 1042




# Stockons les handles des fenêtres à cibler 
target_windows = []

# Fonction pour obtenir les handles des fenêtres par le titre donné
def get_windows_by_title(title):
    windows = []
    win32gui.EnumWindows(lambda hwnd, _: windows.append((hwnd, win32gui.GetWindowText(hwnd))), None)
    return [hwnd for hwnd, window_title in windows if title.lower() in window_title.lower()]

# Obtenir les handles des fenêtres cibles au démarrage du script
target_windows = get_windows_by_title(windows_to_target)
for hwnd in target_windows:
    if hwnd == 0:
        print("Aucune fenêtre trouvée avec le titre spécifié.")
        break
    else:
        print(f"Fenêtre trouvée : {hwnd} - {win32gui.GetWindowText(hwnd)}")

# Permet de simuler la pression d'une touche pour une fenêtre spécifique
def press_key_hwnd(hwnd, key):
    ctypes.windll.user32.PostMessageW(hwnd, WM_KEYDOWN, key, 0)

# Permet de simuler la libération d'une touche pour une fenêtre spécifique                                      
def release_key_hwnd(hwnd, key):
    ctypes.windll.user32.PostMessageW(hwnd, WM_KEYUP, key, 0)

la_horde= target_windows[0]

while True:

    # Écoute les messages UDP sur le port spécifié
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    sock.bind((ipv4_mask, int_port_listen))

    print(f"En attente de messages sur le port {int_port_listen}...")
    while True:
        data, addr = sock.recvfrom(4096)
        if data ==  None:
            break
        lenght = len(data)
        if lenght== 0:
            break
        
        int_value = 0
        if lenght == 4:
            int_value = struct.unpack('<i', data)[0]
        elif lenght == 8:
            int_index, int_value = struct.unpack('<ii', data)
        elif lenght == 12:
            int_value, ulong_timestamp = struct.unpack('<iQ', data)
        elif lenght == 16:
            int_index, int_value, ulong_timestamp = struct.unpack('<iiQ', data)

        print(f"Message reçu : {int_value} de {addr}")


        if int_value == 1009:
            press_key_hwnd(la_horde, VK_TABULATION)
        elif int_value == 2009:
            release_key_hwnd(la_horde, VK_TABULATION)

        elif int_value == 1049:
            press_key_hwnd(la_horde, VK_1)
        elif int_value == 2049:
            release_key_hwnd(la_horde, VK_1)
        elif int_value == 1050:
            press_key_hwnd(la_horde, VK_2)
        elif int_value == 2050:
            release_key_hwnd(la_horde, VK_2)
        elif int_value == 1051:
            press_key_hwnd(la_horde, VK_3)
        elif int_value == 2051:
            release_key_hwnd(la_horde, VK_3)
        elif int_value == 1052:
            press_key_hwnd(la_horde, VK_4)
        elif int_value == 2052:
            release_key_hwnd(la_horde, VK_4)
        elif int_value == 1053:
            press_key_hwnd(la_horde, VK_5)
        elif int_value == 2053:
            release_key_hwnd(la_horde, VK_5)
        elif int_value == 1054:
            press_key_hwnd(la_horde, VK_6)
        elif int_value == 2054:
            release_key_hwnd(la_horde, VK_6)
        elif int_value == 1055:
            press_key_hwnd(la_horde, VK_7)
        elif int_value == 2055:
            release_key_hwnd(la_horde, VK_7)
        elif int_value == 1056:
            press_key_hwnd(la_horde, VK_8)
        elif int_value == 2056:
            release_key_hwnd(la_horde, VK_8)
        elif int_value == 1057:
            press_key_hwnd(la_horde, VK_9)
        elif int_value == 2057:
            release_key_hwnd(la_horde, VK_9)


        elif int_value == 1013:
            press_key_hwnd(la_horde, VK_ENTER)
        elif int_value == 1037:
            press_key_hwnd(la_horde, VK_LEFT)
        elif int_value == 1038:
            press_key_hwnd(la_horde, VK_UP)
        elif int_value == 1039:
            press_key_hwnd(la_horde, VK_RIGHT)
        elif int_value == 1040:
            press_key_hwnd(la_horde, VK_DOWN)
        elif int_value == 1032:
            press_key_hwnd(la_horde, VK_SPACE)
        elif int_value == 1077:
            press_key_hwnd(la_horde, VK_M)
        elif int_value == 1042:
            press_key_hwnd(la_horde, VK_B)


        elif int_value == 2013:
            release_key_hwnd(la_horde, VK_ENTER)
        elif int_value == 2037:
            release_key_hwnd(la_horde, VK_LEFT)
        elif int_value == 2038:
            release_key_hwnd(la_horde, VK_UP)
        elif int_value == 2039:
            release_key_hwnd(la_horde, VK_RIGHT)
        elif int_value == 2040:
            release_key_hwnd(la_horde, VK_DOWN)
        elif int_value == 2032:
            release_key_hwnd(la_horde, VK_SPACE)
        elif int_value == 2077:
            release_key_hwnd(la_horde, VK_M)
        elif int_value == 2042:
            release_key_hwnd(la_horde, VK_B)

        # APINT.IO IID Index Integer Date

        




