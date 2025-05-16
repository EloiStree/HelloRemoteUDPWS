

import socket
import struct
import time


ipv4_address = "127.0.0.1"
int_port_listen = 7073

int_index_player = 1

dico_text_to_integer= {
    "TAB": 1009,
    "tab": 2009,
    "LEFT": 1037,
    "left": 2037,
    "UP": 1038,
    "up": 2038,
    "RIGHT": 1039,
    "right": 2039,
    "DOWN": 1040,
    "down": 2040,
    "SPACE": 1032,
    "space": 2032,
    "MAP": 1077,
    "map": 2077,
    "BAG": 1042,
    "bag": 2042,
    "ENTER": 1013,
    "enter": 2013,
    "P1": 1049,
    "p1": 2049,
    "P2": 1050,
    "p2": 2050,
    "P3": 1051,
    "p3": 2051,
    "P4": 1052,
    "p4": 2052,
    "P5": 1053,
    "p5": 2053,
    "P6": 1054,
    "p6": 2054,
    "P7": 1055,
    "p7": 2055,
    "P8": 1056,
    "p8": 2056,
    "P9": 1057,
    "p9": 2057,
    "P0": 1048,
    "p0": 1048,

    
}

while True:
        # TAB tab P1 p1 P1 p1 P1 p1 P1 p1 P1 p1 P1 p1 P1 p1
        #TAB 0.1 P1 1.6 p1 0.1 P1 1.6 p1 0.1 P1 1.6 p1 0.1 P1 1.6 p1 0.1 P1 1.6 p1 0.1 P1 1.6 p1
        string_what_to_send = input("Donnez moi un entier a envoyer : ")
        string_words = string_what_to_send.split()
        for string_word in string_words:
            send_integer = 0

            if "." in string_word:
                time_to_sleep = float(string_word)
                print("Vous avez entre : ", time_to_sleep)
                time.sleep(time_to_sleep)
                continue

            if string_word.isdigit():
                print("Ce n'est pas un entier !")
                int_what_to_send = int(string_word)
                print("Vous avez entre : ", int_what_to_send)
                send_integer = int_what_to_send

            else:
                if string_word in dico_text_to_integer:
                    print("Vous avez entre : ", string_word)
                    send_integer = dico_text_to_integer[string_word]
                    print("Vous avez entre : ", send_integer)

            if send_integer == 0:
                continue

            bytes_little_endian = struct.pack("<ii",int_index_player, send_integer)
            socket_send = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
            socket_send.sendto(bytes_little_endian, (ipv4_address, int_port_listen))

