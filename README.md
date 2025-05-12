
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











