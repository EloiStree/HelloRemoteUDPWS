# Importons le code pour envoyer un entier via UDP
import socket
# Importons le code pour convertir un entier en binaire
import struct
# Importons le module pour faire patienter le programme
import time

# Définissons une adresse IP, ici la nôtre
string_ip_destinataire = "127.0.0.1"

# Port de l'application qui écoute
int_port_destinataire = 7005

# Permet de convertir un nombre et de l'envoyer au destinataire
def envoyer_entier_udp(entier):
    """
    Envoie un entier via UDP à l'adresse IP et au port spécifiés.
    """
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    data = struct.pack("<i", entier)  
    sock.sendto(data, (string_ip_destinataire, int_port_destinataire))
    print(f"Entier {entier} envoyé à {string_ip_destinataire}:{int_port_destinataire}")


# Préparons le dictionnaire de texte lié à un entier
dictionnaire_text_a_entier = {
        'Dancer': 8001,
        'Bark': 8002,
        'Applaud': 8003,
        'Highfive': 8004,
        'Hug': 8005,
        '42': 42,
        '2501': 2501,
        '314': 314,
    }


# Si vous faites des tests, vous voulez peut-être attendre un peu avant d'envoyer
temps_avant_envoyer_en_milliseconds = 3000


# Attendons la saisie de l'utilisateur
# et envoyons l'entier correspondant
while True:
    
    print("Entrez un texte ou un entier (ou 'exit' pour quitter) :")
    # Attendre la saisie de l'utilisateur
    texte = input()
    # On retire les espaces avant et après ainsi que les retours à la ligne
    texte = texte.strip()
    # Le texte est-il connu dans le dictionnaire ?
    if texte in dictionnaire_text_a_entier:
        # On cherche la valeur de la clé
        entier = dictionnaire_text_a_entier[texte]
        # On attend que vous soyez prêt
        time.sleep(temps_avant_envoyer_en_milliseconds / 1000)
        # On envoie l'entier au serveur pour être interprété
        envoyer_entier_udp(entier)
    else:
        print("Texte non reconnu.")