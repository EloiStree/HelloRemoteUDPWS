Tick: https://github.com/EloiStree/OpenUPM_TickCollection
Relay: https://github.com/EloiStree/2025_04_02_FacadePrimitiveValueRelay
UDP: https://github.com/EloiStree/2020_11_29_UDPThreadSender
Hello Remote: https://github.com/EloiStree/HelloRemoteUDPWS
Generic Int: https://github.com/EloiStree/OpenUPM_PushGenericIID

======================

# Hello Remote UDP & WebSocket

> Petits tutoriels pour créer une télécommande à distance sur Android et Quest 3 avec UDP et WebSocket.

Salut à vous 🤗

Dans ce tutoriel, je vais vous apprendre à mieux contrôler votre vie… enfin, surtout vos appareils 😜

Nous allons découvrir ce qu’est un serveur **UDP** et un serveur **WebSocket**, puis apprendre à les utiliser pour envoyer des actions depuis un téléphone.

![image](https://github.com/user-attachments/assets/49b9d510-f42e-4fe7-b395-e86c7c833e21)

Et comme on veut le faire depuis notre téléphone, nous allons apprendre à le faire sur **Android**.
Puisque le **Quest 3** fonctionne aussi sous Android, on passera ensuite à la réalité augmentée 👓

C’est parti ! 😉

---

### Pourquoi Python ?

Pour éviter d’attendre 5 minutes entre chaque modification dans Unity3D, et parce que **Python est rapide et simple**, nous allons commencer avec ce langage.

#### Installation des outils

**Python** : [https://www.python.org](https://www.python.org)
[![image](https://github.com/user-attachments/assets/6fd1d211-3fbc-4f39-8941-ce8d3447b382)](https://www.python.org)

**Visual Studio Code** : [https://code.visualstudio.com](https://code.visualstudio.com)
[![image](https://github.com/user-attachments/assets/f65b7d0a-a494-498e-8c41-50bf06933e75)](https://code.visualstudio.com)

**Extension Python pour VS Code** :
[https://marketplace.visualstudio.com/items?itemName=ms-python.python](https://marketplace.visualstudio.com/items?itemName=ms-python.python)
[![image](https://github.com/user-attachments/assets/f9df8e3d-247a-4295-92f1-e80366e40060)](https://marketplace.visualstudio.com/items?itemName=ms-python.python)

---

### Bien configurer votre environnement

Plusieurs de mes étudiants ont eu des soucis avec plusieurs versions de Python installées sur leur machine.
Voici comment **choisir le bon interpréteur** dans VS Code :

1. Appuyez sur `Ctrl + Shift + P`
2. Tapez "Python: Select Interpreter"
3. Choisissez la même version que celle utilisée dans votre terminal.

Pour la vérifier, ouvrez un terminal :
`Windows + R` → tapez `cmd`, puis dans la console, entrez :

```bash
python
```

![image](https://github.com/user-attachments/assets/47c332a4-9e92-425a-b3f8-f7884400663e)

---

### Première approche avec Python

Si vous n'avez jamais (ou peu) utilisé Python, pas de panique.
Voici un exemple basé sur le cours de C# (si vous l’avez suivi avec moi 😉).

``` py


je_suis_une_variable = "Hello, Python!"
print(je_suis_une_variable)

def je_suis_une_fonction():
    print("Je suis une fonction !")

def je_suis_une_fonction_avec_parametre(parametre):
    print("Je suis une fonction avec un paramètre :", parametre)

# je suis un appel de fonction
je_suis_une_fonction()

# avec paramètre
je_suis_une_fonction_avec_parametre("Bonjour !")


class JeSuisUneClasse:



    # je suis un constructeur
    def __init__(self, nom):

        # je suis une variable d'instance, membre de la classe
        self.nom = nom

    def je_suis_une_methode_qui_afficher_un_nom(self):
        print("Je suis une méthode de la classe :", self.nom)


# je suis une instance de la classe
eleve = JeSuisUneClasse("Jean")

# je suis un appel de méthode
eleve.je_suis_une_methode_qui_afficher_un_nom()


# je suis un commentaire

"""
Je suis un commentaire multi-ligne
Mais aussi un docstring
"""

text_multiligne = """
Je suis un texte multi-ligne
Je suis un texte multi-ligne
"""
print(text_multiligne)


# je suis une operation arithmétique
a = 5
b = 3
somme = a + b
print("La somme de", a, "et", b, "est :", somme)
# je suis une operation arithmétique
soustraction = a - b
print("La soustraction de", a, "et", b, "est :", soustraction)
# je suis une operation arithmétique
multiplication = a * b
print("La multiplication de", a, "et", b, "est :", multiplication)
# je suis une operation arithmétique
division = a / b
print("La division de", a, "et", b, "est :", division)

je_suis_un_ou = True or False
je_suis_un_et = True and False
je_suis_un_non = not True
je_suis_un_null = None


je_suis_une_condition_if = True
if je_suis_une_condition_if:
    print("Je suis une condition if")
else:
    print("Je suis une condition else")

je_suis_le_compteur_du_while = 0
while je_suis_le_compteur_du_while < 5:
    print("Je suis une boucle while")
    je_suis_le_compteur_du_while += 1

for je_suis_une_variable_for in range(5):
    print("Je suis une boucle for"+ str(je_suis_une_variable_for))


# je suis une liste
ma_liste = [1, 2, 3, 4, 5]
print("Je suis une liste :", ma_liste)

for i in range(len(ma_liste)):
    print("Je suis une boucle for sur une liste :", ma_liste[i])

# je suis un dictionnaire
mon_dictionnaire = {"left": "Tourner a gauche", "right": "Tourner a droite"}
print("Je suis un dictionnaire :", mon_dictionnaire)

for cle, valeur in mon_dictionnaire.items():
    print("Je suis une boucle for sur un dictionnaire :", cle, ":", valeur)

# je suis un check de clé dans un dictionnaire
if "left" in mon_dictionnaire:
    print(mon_dictionnaire["left"])

print("> Je suis un exemple de dictionnaire avec des clés et des valeurs")
while True:
    je_suis_une_variable = input("Entrez une valeur (ou 'continue' pour quitter) : ")
    if je_suis_une_variable == "continuer" or je_suis_une_variable == "continue" or je_suis_une_variable == "exit":
        break
    else:
        print("Vous avez entré :", je_suis_une_variable)

        # je suis une gestion d'erreur
        try:
            print (f"Action a faire : {mon_dictionnaire[je_suis_une_variable]}")
           
        except KeyError:
            print("La clé n'existe pas dans le dictionnaire")



print("> Je suis un exemple de dictionnaire avec des methodes lier a une valeur en chiffre entier")
def action_avancer(bool_press:bool ):
    if bool_press:
        print("Je suis une action d'avancer")
    else:
        print("Je suis une action de ne pas avancer")

def action_reculer(bool_press:bool):
    if bool_press:
        print("Je suis une action de reculer")
    else:
        print("Je suis une action de ne pas reculer")

def action_tourner_a_gauche(bool_press:bool):
    if bool_press:
        print("Je suis une action de tourner a gauche")
    else:
        print("Je suis une action de ne pas tourner a gauche")

def action_tourner_a_droite(bool_press:bool):
    if bool_press:
        print("Je suis une action de tourner a droite")
    else:
        print("Je suis une action de ne pas tourner a droite")

def action_jump(bool_press:bool):
    if bool_press:
        print("Je suis une action de sauter")
    else:
        print("Je suis une action de ne pas sauter")

# Si on utilise ma convention scratch to warcraft   
# https://github.com/EloiStree/2024_08_29_ScratchToWarcraft

# Je suis un dictionnaire d entier avec des methodes lambda
je_suis_dictionnaire_actions_depuis_des_chiffres = {
    "1037": lambda: action_tourner_a_gauche(True),
    "2037": lambda: action_tourner_a_gauche(False),
    "1038": lambda: action_avancer(True),
    "2038": lambda: action_avancer(False),
    "1039": lambda: action_tourner_a_droite(True),
    "2039": lambda: action_tourner_a_droite(False),
    "1040": lambda: action_reculer(True),
    "2040": lambda: action_reculer(False),
}


print("> Je suis un exemple de cle disponible avec \"string join\"")
# Je suis un dictionnaire d entier avec des methodes
keys = list(je_suis_dictionnaire_actions_depuis_des_chiffres.keys())
print("Je suis une liste de clés :", keys)
print("Clés disponibles :", ", ".join(keys))

while True:
    je_suis_une_variable = input("Entrez une valeur (ou 'continuer' pour quitter) : ")
    if je_suis_une_variable == "continuer" or je_suis_une_variable == "continue" or je_suis_une_variable == "exit":
        break
    else:
        print("Vous avez entré :", je_suis_une_variable)
        je_suis_un_nombre:int = int(je_suis_une_variable)

        # je suis une gestion d'erreur
        try:
            if je_suis_un_nombre in je_suis_dictionnaire_actions_depuis_des_chiffres:
                je_suis_dictionnaire_actions_depuis_des_chiffres[je_suis_un_nombre]()

        except KeyError:
            print("La clé n'existe pas dans le dictionnaire")
        except ValueError:
            print("La valeur n'est pas un entier")



print("> Je suis un exemple de l exercice C# dans Warcraft QA macro")
# https://github.com/EloiStree/2025_02_05_WarcraftClientQA


# je suis une importation de module (du code python déjà écrit pour vous)
import time


je_suis_dictionnaire_actions_depuis_des_mots_cles = {
    "LEFT": lambda: action_tourner_a_gauche(True),
    "left": lambda: action_tourner_a_gauche(False),
    "RIGHT": lambda: action_tourner_a_droite(True),
    "right": lambda: action_tourner_a_droite(False),
    "UP": lambda: action_avancer(True),
    "up": lambda: action_avancer(False),
    "DOWN": lambda: action_reculer(True),
    "down": lambda: action_reculer(False),
    "DOWN": lambda: action_jump(True),
    "down": lambda: action_jump(False),
    "wait1": lambda: time.sleep(1),
    "wait2": lambda: time.sleep(2),
    "waitframe": lambda: time.sleep(0.016),
    "100ms": lambda: time.sleep(0.1),
}

print ('> Je suis un exemple de macro')
print("Clés disponibles :", ", ".join(je_suis_dictionnaire_actions_depuis_des_mots_cles.keys()))

example_macro = "UP wait1 up LEFT wait2 left waitframe RIGHT 100ms right DOWN 1000 down 5000 JUMP 10 jump "

while True:

    je_suis_une_variable = input("Entrez une macro : ")
    print("Vous avez entré :", je_suis_une_variable)
  
    je_suis_des_mots_cles = je_suis_une_variable.split(" ")
    for je_suis_un_mot_cle in je_suis_des_mots_cles:
        try:
                
            bool_suis_je_un_nombre = je_suis_un_mot_cle.isdigit()
            if bool_suis_je_un_nombre:
                je_suis_un_nombre:int = int(je_suis_un_mot_cle)
                time.sleep(je_suis_un_nombre/1000.0)
            else:
                    if je_suis_un_mot_cle in je_suis_dictionnaire_actions_depuis_des_mots_cles:
                        je_suis_dictionnaire_actions_depuis_des_mots_cles[je_suis_un_mot_cle]()
        except KeyError:
            print("La clé n'existe pas dans le dictionnaire")
        except ValueError:
            print("La valeur n'est pas un entier")
        except TypeError:
            print("La valeur n'est pas un entier")
        except Exception as e:
            print("Une erreur est survenue :", e)
            
```

Comme vous pouvez le voir, Python est un langage assez direct et simple à utiliser.
C’est la raison pour laquelle, en dehors de l’apprentissage de Unity3D, je recommande de débuter avec Python.

Nous, ce que nous voulons, c’est contrôler des choses à distance, par exemple faire des copier-coller.

Pour cela, nous aurons besoin d’un serveur qui écoute des messages du type 10010101 01001101 0101010 10101010,
pour les traduire en entiers et les interpréter en actions.

Voici un example
``` py
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
                
                # On ouvre le chat
                ouvrir_le_chat_wow()
                time.sleep(0.5)
                copier_texte_dans_le_presse_papier(je_suis_un_dictionnaire_de_texte_pour_wow[string_value_as_integer_littl_endian])
                coller_texte_du_presse_papier()
                time.sleep(0.5)
                # On ferme le chat
                fermer_le_chat_wow()

```



Le code précédent permet d’attendre un entier sur le réseau et d’exécuter une action lorsqu’un chiffre est reçu.
Il nous faut maintenant envoyer un entier depuis un autre ordinateur, ou depuis une autre application.

C’est ce qu’on appelle un Client.

Voici un exemple de client UDP correspondant au serveur UDP.

``` py
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
```

![image](https://github.com/user-attachments/assets/5d586b9c-faf8-45e3-9f2b-3f80a5213f68)



Bon, c’est bien beau Python, mais nous, ce qu’on veut, c’est faire du C# sous Unity3D pour contrôler notre maison avec du code.

Alors, comment fait-on un client en Python ?

Essayons de faire danser notre personnage dans WoW.
(Lancez le serveur que nous avons créé plus haut, puis ouvrez Unity3D.)

Créons un petit `MonoBehaviour`.

Comme on peut directement en faire une boîte à outils, créons un dossier nommé **Runtime**
et un assembly nommé `be.votreNom.helloudpws`.
(Utilisez votre nom ou alias à la place de `votreNom`.)

![image](https://github.com/user-attachments/assets/d27e49f0-dd2d-4fdc-83fd-dacee4fc3990)

En bref, l’assembly permet d’isoler le code du reste du projet, ainsi que du code des autres.

Maintenant, créons un script pour Unity que vous pouvez déposer sur un objet vide.

Son but est de pouvoir envoyer des entiers vers un ordinateur cible ou plusieurs applications.

``` cs
using System;
using System.Text;
using UnityEngine;

// On se fait un petit espace a nous pour stocker nos codes isole du reste
namespace Eloi.HelloUDPWS {

    // On crees un petit block de code pour faire une boite a outils
    // Une classe ne dois bien faire qu une seule chose
    // Comme on est dans Unity on herite de MonoBehaviour
    public class HelloUdpMono_SendIntegerAsUDP : MonoBehaviour
    {
        [Tooltip("Address a qui envoyer les messages UDP 127.0.0.1 pour votre machine")]
        [SerializeField] // Pour que le designer puisse changer l adresse 
        private string m_addressIpOfTarget = "127.0.0.1";

        [Tooltip("Port a qui envoyer les messages UDP 7005 par defaut")]
        [SerializeField] // Pour que le designer puisse changer le port
        private int[] m_portsOfTarget = new int[] { 7005,7006,7007 };

        /// <summary>
        ///  Ce code enverra le message sous format de bytes en UDP a la cible du script
        /// </summary>
        /// <param name="bytesArrayToPush"></param>
        public void PushBytesToTarget(byte[] bytesArrayToPush)
        {
            using (var udpClient = new System.Net.Sockets.UdpClient())
            {
                foreach (int port in m_portsOfTarget)
                {
                    udpClient.Send(bytesArrayToPush, bytesArrayToPush.Length, m_addressIpOfTarget, port);
                }
            }
        }

        // Permettons au developpeur d envoyer une entier dans le format little endian
        // Little Endian est la valeur par defaut pour C# BitConverter
        public void PushIntegerInLittleEndian(int value)
        {
            byte[] bytesArrayToPush = BitConverter.GetBytes(value);
            PushBytesToTarget(bytesArrayToPush);
        }

        // Permettons d envoyer un text en format UTF8
        public void PushIntegerFromIntParse(string integerToParse)
        {
            if (int.TryParse(integerToParse, out int value))
            {
                PushIntegerInLittleEndian(value);
            }
        }

        // Permettons d envoyer un text en format UTF8
        public void PushTextInUTF8(string textUTF8)
        {
            byte[] bytesArrayToPush = Encoding.UTF8.GetBytes(textUTF8);
            PushBytesToTarget(bytesArrayToPush);
        }
    }
}


```


Maintenant que vous pouvez envoyer des bytes à un autre ordinateur depuis Unity 😁,
il nous faut préparer un tableau de textes correspondant à des entiers.

Histoire de proposer une liste d’actions possibles.
On le fait en deux scripts, car la règle d’or en programmation orientée objet est de séparer le code en petites boîtes à outils.


``` py
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// On se fait un petit espace a nous pour stocker nos codes isole du reste
namespace Eloi.HelloUDPWS {
    // Une classe un role, creons en une qui recoit un text et le diffuse en entier
    public class HelloUdpMono_TextToInteger : MonoBehaviour
    {
        // Il nous faut donc une class qui represent un lien en entre un texte et un entier
        // Comme c est propre a notre situation
        // Nous allons faire une classe interne (nested class)

        [System.Serializable]
        public class TextToInteger
        {
            // Le text a donner
            [Tooltip("Alias to give to trigger the integer value")]
            public string m_text;
            // Entier correspondant
            [Tooltip("Integer value to send when the text is found")]
            public int m_integer;

            // Creons deux trois constructeurs pour avoir plus facile
            public TextToInteger(int integer, string text)
            {
                m_integer = integer;
                m_text = text;
            }
            public TextToInteger(string text, int integer)
            {
                m_integer = integer;
                m_text = text;
            }
            public TextToInteger()
            {
                m_integer = 0;
                m_text = "";
            }
        }
        // Il nous faut donc stocker une liste que le designeur pourra modifier
        public List<TextToInteger> m_listTextToInteger = new List<TextToInteger>();
        // Et il nous faut une evenement dont le designeur pourra s abonner pour y reagir
        public UnityEvent<int> m_onEventAsIntegerFound = new UnityEvent<int>();

        // Donnons quelques valeurs par defaut dans Unity quand on depose le script
        private void Reset()
        {
            m_listTextToInteger = new List<TextToInteger>();
            m_listTextToInteger.Add(new TextToInteger("Dancer", 8001));
            m_listTextToInteger.Add(new TextToInteger("Bark", 8002));
            m_listTextToInteger.Add(new TextToInteger("Applaud", 8003));
            m_listTextToInteger.Add(new TextToInteger("Highfive", 8004));
            m_listTextToInteger.Add(new TextToInteger("Hug", 8005));
            m_listTextToInteger.Add(new TextToInteger("42", 42));
            m_listTextToInteger.Add(new TextToInteger("2501", 2501));
            m_listTextToInteger.Add(new TextToInteger("314", 314));
        }


        // Et offrons un petit menu contextuel pour envoyer un message.
        // Pour tester le code par default
        [ContextMenu("Push Dancer")]
        public void PushDancer()
        {
            PushTextToInteger("Dancer");
        }
        [ContextMenu("Push Bark")]
        public void PushBark()
        {
            PushTextToInteger("Bark");
        }
        
        // Il faut donc fournir au integerateur et developpeur
        // Une petit methode pour pousser un texte a envoyer et traduire en entier
        public void PushTextToInteger(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            foreach (TextToInteger textToInteger in m_listTextToInteger)
            {
                if (textToInteger != null && textToInteger.m_text != null && textToInteger.m_text.Length > 0)
                {
                    if (textToInteger.m_text == text)
                    {
                        m_onEventAsIntegerFound?.Invoke(textToInteger.m_integer);
                        return;
                    }
                }
            }
        }

        // Il est possible que un des developpeurs de l equipe veut savoir si le texte est bien dans la liste
        public bool HasText(string text)
        {
            GetTextFromInteger(text, out bool found, out int _);
            return found;
        }
        // Et qu il souhaite plus de details
        public void GetTextFromInteger(string text, out bool found, out int integerFound)
        {

            found = false;
            integerFound = 0;
            if (string.IsNullOrWhiteSpace(text))
                return;
            foreach (TextToInteger textToInteger in m_listTextToInteger)
            {
                if (textToInteger != null && textToInteger.m_text != null && textToInteger.m_text.Length > 0)
                {
                    if (textToInteger.m_text == text)
                    {
                        integerFound = textToInteger.m_integer;
                        found = true;
                        return;
                    }
                }
            }
        }


        // Permettons au developpeur de rajouter un texte lier a un entier pendant que le jeu tourne
        public void AddToListOfText(string textAlias, int integerValue)
        {
            if (string.IsNullOrWhiteSpace(textAlias))
                return;
            foreach (TextToInteger textToInteger in m_listTextToInteger)
            {
                if (textToInteger != null && textToInteger.m_text != null && textToInteger.m_text.Length > 0)
                {
                    if (textToInteger.m_text == textAlias)
                    {
                        textToInteger.m_integer = integerValue;
                        return;
                    }
                }
            }
            m_listTextToInteger.Add(new TextToInteger(integerValue, textAlias));
        }

        // Permettons au developpeur de retirer des textes de la liste
        public void RemoveText(string textAlias)
        {
            if (string.IsNullOrWhiteSpace(textAlias))
                return;
            foreach (TextToInteger textToInteger in m_listTextToInteger)
            {
                if (textToInteger != null && textToInteger.m_text != null && textToInteger.m_text.Length > 0)
                {
                    if (textToInteger.m_text == textAlias)
                    {
                        m_listTextToInteger.Remove(textToInteger);
                        return;
                    }
                }
            }
        }
    }
}

```

![image](https://github.com/user-attachments/assets/2fa2fdc2-5f88-43d0-9ed9-e46607bd9219)



Essayons ces deux classes:  
![image](https://github.com/user-attachments/assets/2328758f-e44f-424d-a7ca-3ac0ec09a28e)  
Changeons le UnityEvent pour relayer en Runtime et Editor vers `SendIntegerAsUDP`  
![image](https://github.com/user-attachments/assets/71bf9e76-4ea9-4f8e-8169-6f3bd3a0cf30)  

Et utiliser le menu contextuel pour declancher un Bark ou un Dancer
![image](https://github.com/user-attachments/assets/bf012be7-edba-459c-a396-5d9f379f7da5)
Si votre server python de plus tot est allumer vous devrier avec un message dans le clipboard et un coller qui c est declanche ;)

Manifique 😁 !!!

-----------

Attendez, ca veut dire que vous pouvez creer un steam deck de 40-200 euro avec un vieux telephone ?
[![image](https://github.com/user-attachments/assets/4b847034-bc79-4880-a20a-566e5ba7c46c)](https://www.thomann.de/be/elgato_stream_deck_xl.htm?glp=1&gad_source=1&gad_campaignid=1565224537&gclid=CjwKCAjwuIbBBhBvEiwAsNypvYvDAsJiQjnh7x3YXAPnbss0C9hYy5uaDXBd2ZVdOZMiI0wqW-5OgBoCvs8QAvD_BwE)

[![image](https://github.com/user-attachments/assets/c80c6e22-66d7-4276-8e1f-ba8c9250a5d8)](https://youtu.be/GZQpInN1XUo?t=658)

> OUI !!!
Essayons:  `⌛+☕+🍕= 🪄🔮` .


![image](https://github.com/user-attachments/assets/96ea8419-430f-4940-9f4b-138de95d9951)
![image](https://github.com/user-attachments/assets/970ffaa8-0bb7-49ea-8a1e-de96ce8b31a9)

Mais pour simplifier les transmissions, il nous faudrait un code qui permette d’envoyer un entier de manière statique via C# dans tout l'application, et que le code que nous avons déjà développé puisse s’y abonner.
Cela nous éviterait d’avoir à dupliquer ce code sur tous nos objets.

Nous allons donc créer une classe statique qui permet d’envoyer des entiers ou des chaînes de caractères à travers notre application.



``` cs

using UnityEngine;

// On se fait un petit espace a nous pour stocker nos codes isole du reste
namespace Eloi.HelloUDPWS {
    // Creaons un script qui permet d envoyer un entier ou un group de mots en text
    public class HelloUdpMono_StaticTextAndIntegerPusher : MonoBehaviour
    {
        // Permettons nous de debugger si il y a un probleme en affichant le dernier entier
        public int m_lastPushInteger;
        // Ainsi aue le dernier text
        public string m_lastPushText;

        // Voici la methode que le developpeur et designeur pourra utiliser pour envoyer une command en entier
        public void PushInteger(int value)
        {
            m_lastPushInteger = value;
            // On demande a la class static qui sait qui est en charge de relayer le message de pousser l entier
            HelloUdpMono_StaticTextAndIntegerRelay.GetInstance()?.PushIntegerToTarget(value);
        }
        // Voici la methode que le developpeur et designeur pourra utiliser pour envoyer une command en text
        public void PushText(string text)
        {
            m_lastPushText = text;
            // On demande a la class static qui sait qui est en charge de relayer le message de pousser l entier
            HelloUdpMono_StaticTextAndIntegerRelay.GetInstance()?.PushTextToWordInterpretor(text);
        }
    }
}
```

On reçoit les données, puis on les transmet à notre code qui sait comment les relayer.
Et si, plus tard, on décide de changer de méthode de transmission, il ne sera pas nécessaire de modifier toute l’application — il suffira simplement d’ajuster les UnityEvent utilisés ici.


``` cs 
using System;
using UnityEngine;
using UnityEngine.Events;

// On se fait un petit espace a nous pour stocker nos codes isole du reste
namespace Eloi.HelloUDPWS {
    // Maintenant, il nous faut une classe qui va relayer les messages a un code qui nous est inconnu dans le future
    public class HelloUdpMono_StaticTextAndIntegerRelay : MonoBehaviour
    {
        // On va faire un singleton pour que le code soit accessible de partout mais avec un seul point script par scene
        private static HelloUdpMono_StaticTextAndIntegerRelay m_scriptInScene;
        // On veut pas le laisser etre modifier donc on le protege avec un private
        public static HelloUdpMono_StaticTextAndIntegerRelay GetInstance()
        {
            return m_scriptInScene;
        }

        // Les messages recu seront transmis a un autre code deposer ici par le designeur ou developpeur
        public UnityEvent<int> m_onIntegerToPushAtTarget = new UnityEvent<int>();
        public UnityEvent<string> m_onWordToInterpret = new UnityEvent<string>();

        // Une fois que notre script apparait dans la scene on le stocke dans la variable static
        private void OnEnable()
        {
            if (m_scriptInScene == null)
            {
                m_scriptInScene = this;
            }
            else
            {
                Debug.LogWarning("There is already a HelloUdpMono_StaticTextAndIntegerRelay in the scene", this.gameObject);

            }
        }
        // Quand le script disparait de la scene on le retire de la variable static
        private void OnDisable()
        {
            if (m_scriptInScene == this)
            {
                m_scriptInScene = null;
            }
        }

        // Ajoutons un methode pour permettre de pousser la valeur entiere vers la cible exterieure
        public void PushIntegerToTarget(int value)
        {
            m_onIntegerToPushAtTarget?.Invoke(value);
        }

        // Ajouter une methode pour pousser un text qui sera decouper en groupe de mots
        public void PushTextToWordInterpretor(string groupeDeMots)
        {
            string[] words = groupeDeMots.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;
                m_onWordToInterpret?.Invoke(word);
            }

        }
    }
}
```


Pour envoyer un message, il nous suffit maintenant de déposer un petit script **statique** et d’utiliser soit un `UnityEvent` de Unity, soit un morceau de code personnalisé :
![image](https://github.com/user-attachments/assets/82b8ffff-1b15-496f-b88b-6abbff63183a)

Ensuite, il suffit de connecter la réception de ces messages à notre `Broadcaster UDP` :
![image](https://github.com/user-attachments/assets/9136b604-ef69-45b8-bf53-ab33de4f2dfe)

Et si on décide de changer de méthode plus tard, cela n'affectera pas notre scène 😜



À partir d’ici, le cours pourrait facilement évoluer vers un cours sur les interfaces **UI 2D** de Unity3D.
![image](https://github.com/user-attachments/assets/2da0c0ef-83d4-4539-93fb-0b7a459725e7)

Mais ce que nous voulons faire, c’est plutôt utiliser **nos mains, la voix, nos pieds** et la **XR**.
Nous allons donc nous orienter davantage vers le **Input Action System** de Unity par la suite.

---

Avant d’explorer les entrées disponibles et les builds Android, il nous manque encore quelque chose...
Quand vous testez votre code sur votre propre ordinateur, vous devez à chaque fois lancer le code, puis revenir manuellement sur la fenêtre cible…
Pas très pratique.

Comment pourrait-on envoyer directement une fausse touche, comme `Enter`, `Backspace` ou `Ctrl+V` ?

C’est possible, à condition de connaître le nom de l’application cible et que celle-ci utilise les codes spécifiques de Windows.
Mais attention : cela ne fonctionnera pas avec toutes les applications.

Explorons donc **`ctypes`**.


``` py
# Essayons plutôt d'envoyer le Ctrl+V avec ctypes
import ctypes
import win32gui
import time  # Ajout manquant pour utiliser time.sleep

boo_use_ctypes_instead_of_pyautogui = True  # Corrigé "cytpes"

# Définissons un port sur l'ordinateur pour écouter les messages UDP
int_port_listen = 7005
ipv4_mask = "0.0.0.0"

# Définissons une touche à utiliser pour ouvrir le chat dans World of Warcraft
string_key_for_wow_chat = "enter"
hexadecimal_key_for_wow_chat = 0x0D
windows_to_target = "World of Warcraft"

# Utilisé pour envoyer des événements de pression ou de relâchement de touche
WM_KEYDOWN = 0x0100
WM_KEYUP = 0x0101

# Définir les codes de touches virtuelles nécessaires
# https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
VK_CONTROL = 0x11
VK_V = 0x56
VK_ENTER = 0x0D
VK_BACKSPACE = 0x08

# Stockons les handles des fenêtres à cibler 
target_windows = []

# Fonction pour obtenir les handles des fenêtres par le titre donné
def get_windows_by_title(title):
    windows = []
    win32gui.EnumWindows(lambda hwnd, _: windows.append((hwnd, win32gui.GetWindowText(hwnd))), None)
    return [hwnd for hwnd, window_title in windows if title.lower() in window_title.lower()]

# Obtenir les handles des fenêtres cibles au démarrage du script
target_windows = get_windows_by_title(windows_to_target)

# Permet de simuler la pression d'une touche pour une fenêtre spécifique
def press_key_hwnd(hwnd, key):
    ctypes.windll.user32.PostMessageW(hwnd, WM_KEYDOWN, key, 0)

# Permet de simuler la libération d'une touche pour une fenêtre spécifique                                      
def release_key_hwnd(hwnd, key):
    ctypes.windll.user32.PostMessageW(hwnd, WM_KEYUP, key, 0)

# Permet de simuler la pression et la libération d'une touche pour une fenêtre spécifique
def press_and_release_key_hwnd(hwnd, key):
    press_key_hwnd(hwnd, key)
    time.sleep(0.1)  # Ajustez le délai si nécessaire
    release_key_hwnd(hwnd, key)

# Permet de simuler la pression d'une touche pour toutes les fenêtres stockées basées sur le titre
def send_key_press(key):
    for hwnd_main in target_windows:
        if hwnd_main == 0:
            return
        press_key_hwnd(hwnd_main, key)

# Permet de simuler la libération d'une touche pour toutes les fenêtres stockées basées sur le titre
def send_key_release(key):
    for hwnd_main in target_windows:
        if hwnd_main == 0:
            return
        release_key_hwnd(hwnd_main, key)

```


On est d'accord, ça va vite faire beaucoup de lignes de code.

Je vous invite donc à vous inspirer du code suivant pour créer le vôtre :
`HelloServerPostMessageClipboard.py`

De mon côté, j’utilise un code pour mes projets qui s’appelle **ScratchToWarcraft**.
Pour ne pas réinventer la roue, je vais l’utiliser :
[https://github.com/EloiStree/2024_08_29_ScratchToWarcraft](https://github.com/EloiStree/2024_08_29_ScratchToWarcraft)

Je vous propose plusieurs zones de test sur lesquelles `PostMessage` de Ctypes fonctionne :

* [https://hordes.io](https://hordes.io) sur Firefox
* World of Warcraft : [https://worldofwarcraft.blizzard.com/fr-fr/](https://worldofwarcraft.blizzard.com/fr-fr/)
* Brawlhalla : [https://www.brawlhalla.com](https://www.brawlhalla.com) sur Steam
* Votre téléphone avec : [https://github.com/Genymobile/scrcpy](https://github.com/Genymobile/scrcpy)

Si vous avez quelques euros à perdre, voici mes préférés :

* **10 Seconds Ninja** : [https://store.steampowered.com/app/271670/](https://store.steampowered.com/app/271670/)
* **Stealth Bastard** : [https://store.steampowered.com/app/209190/](https://store.steampowered.com/app/209190/)

Pour la démonstration, je vous invite à tester sur *scrcpy* : cela montre que votre code fonctionne pour tous les jeux mobiles Android.
Mais pour pratiquer, je vous conseille de tester sur un de vos jeux ou sur l’un de ceux listés ci-dessus.

Allons automatiser du code Android depuis Unity3D 🔮🪄



Commençons par télécharger **ScratchToWarcraft** et **scrcpy**
Download : [https://github.com/Genymobile/scrcpy/releases/tag/v3.2](https://github.com/Genymobile/scrcpy/releases/tag/v3.2)

```bash
# Je vous propose de stocker le projet Scratch dans un dossier Git
mkdir "C:\Git"

# Je vous propose de stocker le code scrcpy dans Exe pour le retrouver facilement
mkdir "C:\Exe"

# mkdir permet de créer un dossier et cd de se déplacer dans le système via la console
cd "C:\Git"

# Je clone le projet dans le dossier Git
git clone https://github.com/EloiStree/2024_08_29_ScratchToWarcraft.git

cd "C:\Exe"

# J’ouvre la page web de scrcpy pour le télécharger
start "" "https://github.com/Genymobile/scrcpy/releases"

# J’ouvre le dossier où l’extraire (à adapter selon votre explorateur ou besoin)
start "" ""

# Tada
```

Avant d utiliser SCRCPY, je vais vous donner deux boites a outils pour plus tard
- Une boite a outils de fichier bat pour interagir avec scrcpy
  - https://github.com/EloiStree/2024_05_23_SCRCPYBatFiles
- Une boite a outils pour installer un jeu android sur plusieurs telephone et Quest3 en meme temps.
  - https://github.com/EloiStree/2025_01_12_BuildAndRunApkBroadcast.git

``` bash
git clone https://github.com/EloiStree/2024_05_23_SCRCPYBatFiles.git  BatFiles
git clone https://github.com/EloiStree/2025_01_12_BuildAndRunApkBroadcast.git BroadcastAndRun
# A cloner a coter de  `adb.exe` et `scrcpy.exe`
```

Comme nous allons travaillez avec Android, il va nous falloir donner plus de pouvoir a vos telephone Android, ou Quest3.
Cela est possible en les passants Administrateur.
- [Sur telephone Android =>](https://www.youtube.com/results?search_query=passer+en+mode+developer+android+sur+telephone)
- [Sur Quest 3 =>](https://www.youtube.com/results?search_query=passer+en+mode+developer+android+sur+quest3) 

Comme ca change avec le temps et le temps, je laisse soint au Youtuber professionnel de vous montrer la dernier maniere de faire pour passer developper.
Je me fais une petit pizza pendant ce temps la 🍕🤗...

-------------------------

Si votre telephone est bien maintenant developpeur :), on va pouvoir s amuser.


Essayons deja de faire un Hello World.


Pour cela, il nous faudra un telephone brancher en USB.
Un message Authoriser ce telephone devrait apparaitre.
Accepter pour toujours ce telephone sur le PC

Allez dans votre dossier  `scrcpy` `C:\Exe\scrcpy` telecharger precedemment.
Et essayer cette command:
```
adb devices
```

![image](https://github.com/user-attachments/assets/9adc6d42-c1b9-434d-9ff5-a19d53b657f1)

Si vous voyez ce message c est que;
- votre telephone est en mode developpeur
- vous avez authoriser le telephone
- vous etes dans le dossier ou ce trouve adb.exe 😉
![image](https://github.com/user-attachments/assets/d30d813f-42d1-4dda-a4e8-793a19b943d8)

ADB ca veut dire Android debug bridge:
Un pont qui permet de debugger vtore telephone android via USB (ou Wifi)

Essayons cette command pour tester SCRCPY:
```
scrcpy.exe --keyboard=uhid --video-source=display --audio-source=output --no-audio --orientation=0 --max-size 1024 --max-fps 10 --window-title "HelloADB"
``` 
``` bash
# Si vous etes sur Quest3
scrcpy.exe --crop 1920:1920:0:0 --keyboard=uhid --video-source=display --audio-source=output --no-audio --orientation=0 --max-size 1024 --max-fps 20 --window-title "HelloADB"
```

Vous devriez maintenant voir l ecran de votre telephone avec un resolution max de 1024 et un frame rate de 10 sans l audio et vous pouvez utiliser un clavier sur la fenetre donnee. Magic !!! 
![image](https://github.com/user-attachments/assets/065de691-71f2-4a5e-9ccf-15e84d930782)


Maintenant, il nous faut lancer ScratchToWarcraft avec les noms d applications `HelloADB` sur le port `7073`:
`C:\Git\2024_08_29_ScratchToWarcraft\PythonBridge\LaunchGame\Launch_HelloADB.bat`
``` bash
cd ..
python IntegerToWarcraft.py "HelloADB" 7073
pause 10
```
![image](https://github.com/user-attachments/assets/525ef0ac-6ec4-48e0-88c5-85f87af46687)


Cela veut dire que nous avons un Server UDP qui ecoute a des entiers en little endian associer a des touches qui seront injecter sur la fenetre ADB si vous les envoyer sur l ordinateur et le port 7073.

Essayons avec un touche, un boutton, un axe et un joystick en Unity3D via une boite a outil que j utilise quand, je fais du prototype;
``` 
https://github.com/EloiStree/OpenUPM_TickCollection.git
```
![image](https://github.com/user-attachments/assets/9d035899-7405-4636-99ea-8c93d39a8192)






# Hummm... it works but..

Apparemment, oui, cela fonction d envoyer de fausse touche a ScrCpy... Mais pas autant que ADB, PyAutoGUI dans la fenetre, du BLE avec un ESP32
On va garder nos connaissances de SCRCPY et Android pour la suite sur le cours de Quest3 et Android.
C est en creant se cours que je m en suis apercu. 

Essayons autre choses.

Dans la piece du cours, se trouve des lampe Govee and des prises Meross.
Si le reseau securiser de la formation, ne nous bloque pas.
Essayons de les attendres avec du Python et de les controllers depuis votre telephone.

...

Et c est Meross et Govee qui decide de me saboter mon cours ^^. 
Quand ca marche, ca marche, mais quand ca fonctionne pas... Vous avez envie de tout bruller.
![image](https://github.com/user-attachments/assets/39f25ba1-7143-45b4-bada-34e7aa666add)


# On, va bouger un OVNI 🛸

La convention Scratch 2 Warcraft n est qu une convention.

On peut se servir du Stream Deck que l on construit poru piloter un jeu.









- On va utiliser c est deux packages pour fabriquer un drone:
  - https://github.com/EloiStree/2024_08_26_WowMovingInUnity
  - https://github.com/EloiStree/2025_04_15_KidToyOvniCode
  - https://github.com/EloiStree/2024_08_05_UvDrawableDrones
- Mais on va le rendre compatible World of Warcraft pour pouvoir reutiliser le code de celui-ci.

Si vous desirez faire un parcours:
- https://github.com/EloiStree/2024_09_03_SkyRidingPath
- https://github.com/EloiStree/2024_06_31_DroneRaceStep
- https://github.com/EloiStree/2023_02_16_DroneSoccerGoal

Et que vite fait, faire que la camera vous suive;
- https://github.com/EloiStree/2024_09_16_QuickFollowIt







==============

- Note: https://github.com/EloiStree/HelloInput/issues/28
- Meross: https://github.com/EloiStree/2024_12_13_IntegerToMerossFromPython
- Govee: https://github.com/EloiStree/2025_03_19_IntegerToGoveeFromPython
  - https://github.com/EloiStree/2025_01_26_XboxAndKeyboardOnPiToInteger
- https://github.com/EloiStree/OpenUPM_PushGenericIID
- https://github.com/EloiStree/OpenUPM_BasicActionIID
