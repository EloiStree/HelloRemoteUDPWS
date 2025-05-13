# Importons une bibliothèque pour compresser des données en binaire : struct
import struct
import sys
# Importons une bibliothèque pour copier/coller du texte : pyperclip
import pyperclip
# Importons une bibliothèque pour simuler des frappes clavier : pyautogui
import pyautogui
# Importons une bibliothèque pour créer un socket UDP : socket
import socket

# Importons une bibliothèque pour le temps : time
import time

# Essayons plus to d envoyer le controle V avec ctype
import ctypes
import win32gui

boo_use_cytpes_instead_of_pyautogui = True

# Definissons un port sur l ordinateur pour ecouter les messages UDP
int_port_listen =7005
ipv4_mask= "0.0.0.0"
# Definissons une touche a utiliser pour ouvrir le chat dans World of Warcraft
string_key_for_wow_chat = "enter"
hexadecimal_key_for_wow_chat = 0x0D
windows_to_target = "World of Warcraft" #V
windows_to_target = 'Hordes.io'#V on firefox
windows_to_target = 'QUEST LITE' #V
windows_to_target = '- Remote Desktop - RustDesk' #X
windows_to_target = 'Shadow PC - Display' #X
windows_to_target = '10 Second Ninja' #V
windows_to_target = '- Cookie Clicker' #X Firefox
windows_to_target = 'scrcpy.exe' #X Ne fonctionne pas car une sous fenetre avec les nom de l appareil est cree.
windows_to_target = 'Brawlhalla' #V  https://www.brawlhalla.com
windows_to_target = 'Metal Slug: Awakening' # Vhttps://store.steampowered.com/app/2963870/Metal_Slug_Awakening/
# Note que vous pouvez proablement renommer la fenetre avec un paramettre de scrcpy pour avoir toujour la meme fenetre


# Use to send key press or release event
WM_KEYDOWN = 0x0100
WM_KEYUP = 0x0101
# Define virtual key codes you will need
# https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
VK_CONTROL = 0x11
VK_V = 0x56
VK_X = 0x58
VK_A = 0x41
VK_ENTER = 0x0D
VK_BACKSPACE = 0x08
VK_SPACE = 0x20



# Si il y a des paramètres de la ligne de commande
if len(sys.argv) > 1:
    # Si une personne lance le programme avec un parametre
    # C est qu il a un tittre en tete a tester
    windows_to_target = sys.argv[1]
    print(f"Target window title: {windows_to_target}")

# Stockons les handles des fenetres a cibler 
target_windows=[]


# Fonction pour obtenir les handles des fenêtres par le titre donné
def get_windows_by_title(title):
    windows = []
    win32gui.EnumWindows(lambda hwnd, _: windows.append((hwnd, win32gui.GetWindowText(hwnd))), None)
    return [hwnd for hwnd, window_title in windows if title.lower() in window_title.lower()]

def get_windows_by_executable_name(executable_name):
    windows = []
    win32gui.EnumWindows(lambda hwnd, _: windows.append((hwnd, win32gui.GetWindowText(hwnd))), None)
    return [hwnd for hwnd, window_title in windows if executable_name.lower() in window_title.lower()]

# Fonction pour obtenir le handle de la fenêtre quand le script est lancé
target_windows = get_windows_by_executable_name(windows_to_target)
target_windows += get_windows_by_title(windows_to_target)

# Retirons les doublons sur le handle id
target_windows = list({hwnd: None for hwnd in target_windows}.keys())

if len(target_windows) > 0:
    print(f"Fenêtres trouvées avec le titre '{windows_to_target}':")
    # Display handle , title and executable name
    handles = []
    for hwnd in target_windows:
        title = win32gui.GetWindowText(hwnd)
        executable_name = win32gui.GetClassName(hwnd)
        handles.append((hwnd, title, executable_name))
        print(f"Handle: {hwnd}, Title: {title}, Executable Name: {executable_name}")

else :
    print(f"Aucune fenêtre trouvée avec le titre '{windows_to_target}'.")



# Nous permettons de simuler la pression de touches pour une fenêtre spécifique
def press_key_hwnd(hwnd, key):
    ctypes.windll.user32.PostMessageW(hwnd, WM_KEYDOWN, key, 0)

# Nous permettons de simuler la libération de touches pour une fenêtre spécifique                                      
def release_key_hwnd(hwnd, key):
    ctypes.windll.user32.PostMessageW(hwnd, WM_KEYUP, key, 0)

# Nous permettons de simuler la pression et la libération de touches pour une fenêtre spécifique
def press_and_release_key_hwnd(hwnd, key):
    press_key_hwnd(hwnd, key)
    time.sleep(0.1)  # Adjust the delay as needed
    release_key_hwnd(hwnd, key)


# Nous permettons de simuler la pression de touches pour toutes les fenêtres stockees baser sur le titre
def send_key_press (key):
    for hwnd_main in target_windows:
        if hwnd_main == 0:
             return
        press_key_hwnd(hwnd_main, key)

# Nous permettons de simuler la libération de touches pour toutes les fenêtres stockees baser sur le titre
def send_key_release (key):
    for hwnd_main in target_windows:
        if hwnd_main == 0:
             return
        release_key_hwnd(hwnd_main, key)

# Nous permettons de simuler la pression et la libération de touches pour toutes les fenêtres stockees baser sur le titre
def send_key_click( key):
    for hwnd_main in target_windows:
        if hwnd_main == 0:
            return
        press_and_release_key_hwnd(hwnd_main, key)
        
# Definisions des temps d attente entre les actions pour faire un coller de texte
# Les variables sont a ajuster selon la puissance de votre ordinateur et la vitesse de votre connexion
time_before_opening_chat = 0.01
time_waiting_for_chat_open = 0.25
time_waiting_for_clipboard_to_paste = 0.01
time_waiting_for_ctrl_v_to_paste = 0.01
time_waiting_for_backspace = 0.01
time_waiting_between_ctrl_v = 0.05
time_waiting_between_enter = 0.05


# Prenons le temps d associer les entiers a des textes pour le clipboard
je_suis_un_dictionnaire_de_texte_normal = {
    "42": "Je suis le sens de la vie, de l'univers et de tout",
    "2501": "Je suis une reference a Ghost in the shell",
    "314": "3.1418",
}

# Prenons le temps d associer les entiers a des textes pour le chat de World of Warcraft
je_suis_un_dictionnaire_de_texte_pour_wow = {   
    "8001": "/dance",
    "8002": "/bark",
    "8003": "/applaud",
    "8004": "/highfive",
    "8005": "/hug",
}

# Pemettons d ouvrir le chat dans World of Warcraft
def ouvrir_le_chat_wow():
    """
    Ouvre le chat dans World of Warcraft.
    """    
    if not boo_use_cytpes_instead_of_pyautogui:
        pyautogui.hotkey(string_key_for_wow_chat)
    else:
        send_key_press( hexadecimal_key_for_wow_chat)
        time.sleep(time_waiting_between_enter)  # Adjust the delay as needed
        send_key_release( hexadecimal_key_for_wow_chat)
            

# Pemettons de fermer le chat en validant avec enter
def fermer_le_chat_wow():
    """
    Ferme le chat dans World of Warcraft.
    """

    if not boo_use_cytpes_instead_of_pyautogui:
        pyautogui.hotkey("enter")
    else:
        send_key_press( VK_ENTER)
        time.sleep(time_waiting_between_enter)  # Adjust the delay as needed
        send_key_release( VK_ENTER)
    print("Chat fermé dans World of Warcraft.")


def send_backspace():
    """
    Simule la pression de la touche "backspace" pour supprimer le dernier caractère.
    """
    if not boo_use_cytpes_instead_of_pyautogui:
        pyautogui.press("backspace")
    else:
        send_key_press(VK_BACKSPACE)
        time.sleep(time_waiting_for_backspace)
        send_key_release(VK_BACKSPACE)
        time.sleep(time_waiting_for_backspace)

def double_backspace():
        send_backspace()
        send_backspace()

# Pemettons de copier du texte dans le presse-papier
def copier_texte_dans_le_presse_papier(texte):
    """
    Copie le texte donné dans le presse-papier.
    """
    pyperclip.copy(texte)
    print(f"Texte copié dans le presse-papier : {texte}")

# Pemettons de coller le texte du presse-papier avec les touches de l ordinateur
def coller_texte_du_presse_papier():
    """
    Colle le texte du presse-papier à la position actuelle du curseur.
    """
    if not boo_use_cytpes_instead_of_pyautogui:
        pyautogui.hotkey("ctrl", "v")
    else:

        #press ctrl
        send_key_press(VK_CONTROL)
        time.sleep(time_waiting_between_ctrl_v)
        #press v
        send_key_press(VK_V)
        time.sleep(time_waiting_between_ctrl_v)
        #release v
        send_key_release(VK_V)
        time.sleep(time_waiting_between_ctrl_v)
        #release ctrl
        send_key_release(VK_CONTROL)

    print("Texte collé depuis le presse-papier.")



# For the test
for i in range(1, 10):
    send_key_press(VK_SPACE)
    time.sleep(0.1)
    send_key_release(VK_SPACE)
    time.sleep(1)

# Ecoutons continuellement les messages UDP sur le port donnee
while True:
    # Creons un server UDP qui ecoute
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    # Specificons le port donnee et qui accepte les messages de n importe quelle adresse IP
    # Utiliser 127.0.0.1 si vous ne voulez que depuis votre machine
    sock.bind((ipv4_mask, int_port_listen))

    print(f"Listening for UDP messages on port {int_port_listen}...")

    while True:
        # Commencons l ecoute 
        data, addr = sock.recvfrom(1024)  # Buffer size is 1024 bytes
        
        # Ce qui est recu existe il ?
        if not data:
            break
        # As t il la taille voulue ?
        lenght = len(data)

        index=0
        value = 0

        if lenght == 4:
            value = struct.unpack("<i", data)[0]
        elif lenght == 8:
            index , value = struct.unpack("<ii", data)[0]
        elif lenght == 12:
            value, longDate = struct.unpack("<iQ", data)[0]
        elif lenght == 16:
            index,value, longDate = struct.unpack("<iiQ", data)[0]

        if value != 0:
            # On le convertit en entier
            string_value_as_integer_little_endian = str(value)
            # Comme je donne des cours C# le format d entier et en Little-endian
            print(f"Received integer (little-endian): {string_value_as_integer_little_endian}")
            # si c est un entier fait partie d un simple dictionnaire de texte
            if string_value_as_integer_little_endian in je_suis_un_dictionnaire_de_texte_normal:
                # On le colle dans le presse papier
                copier_texte_dans_le_presse_papier(je_suis_un_dictionnaire_de_texte_normal[string_value_as_integer_little_endian])
                coller_texte_du_presse_papier()
            
            # si c est un entier fait partie d un dictionnaire de texte pour le chat de World of Warcraft
            elif string_value_as_integer_little_endian in je_suis_un_dictionnaire_de_texte_pour_wow:
                
             
                time.sleep(time_before_opening_chat)
                # On ouvre le chat
                ouvrir_le_chat_wow()
                time.sleep(time_waiting_for_chat_open)
                copier_texte_dans_le_presse_papier(je_suis_un_dictionnaire_de_texte_pour_wow[string_value_as_integer_little_endian])
                time.sleep(time_waiting_for_clipboard_to_paste)
                
                coller_texte_du_presse_papier()
                time.sleep(time_waiting_for_ctrl_v_to_paste)

                if boo_use_cytpes_instead_of_pyautogui:
                    # use bascksapace to delete the last character
                    double_backspace()
                    
                # On ferme le chat
                fermer_le_chat_wow()



