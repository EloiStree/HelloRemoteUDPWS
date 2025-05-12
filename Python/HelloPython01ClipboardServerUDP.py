# Importont une bibliothèque pour compresser des données en binaire : struct
import struct
# Importont une bibliothèque pour copier/coller du texte : pyperclip
import pyperclip
# Importont une bibliothèque pour simuler des frappes clavier : pyautogui
import pyautogui
# Importont une bibliothèque pour créer un socket UDP : socket
import socket

# Importont une bibliothèque pour le temps : time
import time

# Definissons un port sur l ordinateur pour ecouter les messages UDP
int_port_listen =7005
# Definissons une touche a utiliser pour ouvrir le chat dans World of Warcraft
string_key_for_wow_chat = "enter"

# Definisions des temps d attente entre les actions pour faire un coller de texte
time_before_opening_chat = 0.6
time_waiting_for_chat_open = 0.2
time_waiting_for_clipboard_to_paste = 0.1
time_waiting_for_ctrl_v_to_paste = 0.1

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
    pyautogui.hotkey(string_key_for_wow_chat)
    print("Chat ouvert dans World of Warcraft.")

# Pemettons de fermer le chat en validant avec enter
def fermer_le_chat_wow():
    """
    Ferme le chat dans World of Warcraft.
    """
    pyautogui.hotkey("enter")
    print("Chat fermé dans World of Warcraft.")


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
    pyautogui.hotkey("ctrl", "v")
    print("Texte collé depuis le presse-papier.")


# Ecoutons continuellement les messages UDP sur le port donnee
while True:
    # Creons un server UDP qui ecoute
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    # Specificons le port donnee et qui accepte les messages de n importe quelle adresse IP
    # Utiliser 127.0.0.1 si vous ne voulez que depuis votre machine
    sock.bind(("0.0.0.0", int_port_listen))

    print(f"Listening for UDP messages on port {int_port_listen}...")

    while True:
        # Commencons l ecoute 
        data, addr = sock.recvfrom(1024)  # Buffer size is 1024 bytes
        
        # Ce qui est recu existe il ?
        if not data:
            break
        # As t il la taille voulue ?
        lenght = len(data)
        # Si c est un entier, il doit faire 4 octets
        if lenght == 4:
            # On le convertit en entier
            string_value_as_integer_littl_endian = str(struct.unpack("<I", data)[0])
            # Comme je donne des cours C# le format d entier et en Little-endian
            print(f"Received integer (little-endian): {string_value_as_integer_littl_endian}")
            # si c est un entier fait partie d un simple dictionnaire de texte
            if string_value_as_integer_littl_endian in je_suis_un_dictionnaire_de_texte_normal:
                # On le colle dans le presse papier
                copier_texte_dans_le_presse_papier(je_suis_un_dictionnaire_de_texte_normal[string_value_as_integer_littl_endian])
                coller_texte_du_presse_papier()
            
            # si c est un entier fait partie d un dictionnaire de texte pour le chat de World of Warcraft
            elif string_value_as_integer_littl_endian in je_suis_un_dictionnaire_de_texte_pour_wow:
                
             
                time.sleep(time_before_opening_chat)
                # On ouvre le chat
                ouvrir_le_chat_wow()
                time.sleep(time_waiting_for_chat_open)
                copier_texte_dans_le_presse_papier(je_suis_un_dictionnaire_de_texte_pour_wow[string_value_as_integer_littl_endian])
                time.sleep(time_waiting_for_clipboard_to_paste)
                
                coller_texte_du_presse_papier()
                time.sleep(time_waiting_for_ctrl_v_to_paste)
                # On ferme le chat
                fermer_le_chat_wow()



