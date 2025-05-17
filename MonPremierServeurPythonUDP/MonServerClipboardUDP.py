# pip install pyperclip

# Importont une bibliothèque pour compresser des données en binaire : struct
import struct
# Importont une bibliothèque pour copier/coller du texte : pyperclip
import pyperclip
# Importont une bibliothèque pour créer un socket UDP : socket
import socket

# Definissons un port sur l ordinateur pour ecouter les messages UDP
int_port_listen =7005


# Prenons le temps d associer les entiers a des textes pour le clipboard
je_suis_un_dictionnaire_de_texte_normal = {
    "42": "Je suis le sens de la vie, de l'univers et de tout",
    "2501": "Je suis une reference a Ghost in the shell",
    "314": "3.1418", 
    "8001": "/dance",
    "8002": "/bark",
    "8003": "/applaud",
    "8004": "/highfive",
    "8005": "/hug",
    "80085": "Why not (v) (; ; ) (v)  ?",
    "9001": "<>",
    "9002": "()",
    "9003": "[]",
    "9003": "{}",
    "9101": "helloudp1@apint.io",
    "9102": "helloudp2@apint.io",
    "9103": "helloudp3@apint.io",
    "9103": "helloudp4@apint.io",
    "9105": "helloudp5@apint.io",

}

# Pemettons de copier du texte dans le presse-papier
def copier_texte_dans_le_presse_papier(texte):
    """
    Copie le texte donné dans le presse-papier.
    """
    pyperclip.copy(texte)
    print(f"Texte copié dans le presse-papier : {texte}")


ipv4_mask= "127.0.0.1"
ipv4_mask= "0.0.0.0"

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
        data, addr = sock.recvfrom(4096)  # Buffer size is 1024 bytes
        
        # Ce qui est recu existe il ?
        if not data:
            break
        # As t il la taille voulue ?
        lenght = len(data)

        int_value = 0
        if lenght == 4:
            int_value = struct.unpack('<i', data)[0]
        elif lenght == 8:
            int_index, int_value = struct.unpack('<ii', data)
        elif lenght == 12:
            int_value, ulong_timestamp = struct.unpack('<iQ', data)
        elif lenght == 16:
            int_index, int_value, ulong_timestamp = struct.unpack('<iiQ', data)

        # Si c est un entier, il doit faire 4 octets
        if int_value != 0:
            # Comme je donne des cours C# le format d entier et en Little-endian
            print(f"Received integer (little-endian): {int_value}")
            # si c est un entier fait partie d un simple dictionnaire de texte
            key_to_found = str(int_value)
            if key_to_found in je_suis_un_dictionnaire_de_texte_normal:
                # On le colle dans le presse papier
                copier_texte_dans_le_presse_papier(je_suis_un_dictionnaire_de_texte_normal[key_to_found])
            else :
                print (f"Integer {int_value} not found in dictionary.")  
            
