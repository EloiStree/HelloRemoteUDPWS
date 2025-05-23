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

        [Tooltip("Port a qui envoyer les messages UDP 7005 par defaut")]
        [SerializeField] // Pour que le designer puisse changer le port
        private int m_settablePortOfTarget = 7074;


        public byte[] m_bytesPushed = new byte[0];
        public int m_integerPushed = 0;


        public void SetTargetIpv4AndPort(string ipv4Address)
        {
            m_addressIpOfTarget = ipv4Address;
            string[] parts = ipv4Address.Split(':');
            if (parts.Length == 2)
            {
                m_addressIpOfTarget = parts[0];
                if (int.TryParse(parts[1], out int port))
                {
                    m_settablePortOfTarget = port;
                }
            }
            else { 
            
                string[] ipPart = ipv4Address.Split(".");
                if (ipPart.Length == 4)
                {
                    m_addressIpOfTarget = ipPart[0] + "." + ipPart[1] + "." + ipPart[2] + "." + ipPart[3];
                }
            }
        }
        public void SetSettablePort(int port)
        {
            m_settablePortOfTarget = port;
        }
        public void GetSettablePort(out int port)
        {
            port = m_settablePortOfTarget;
        }
        public void GetTargetIpv4WithoutPort(out string ip)
        {
            ip = m_addressIpOfTarget;
        }
        public void GetTargetIpv4AndPort(out string ip, out int port)
        {
            ip = m_addressIpOfTarget;
            port = m_settablePortOfTarget;
        }
        public void SetTargetIpv4WithoutPort(string ip)
        {
            m_addressIpOfTarget = ip;
        }

        /// <summary>
        ///  Ce code enverra le message sous format de bytes en UDP a la cible du script
        /// </summary>
        /// <param name="bytesArrayToPush"></param>
        public void PushBytesToTarget(byte[] bytesArrayToPush)
        {
            try { 
            m_bytesPushed = bytesArrayToPush;
            using (var udpClient = new System.Net.Sockets.UdpClient())
            {
                foreach (int port in m_portsOfTarget)
                {
                    udpClient.Send(bytesArrayToPush, bytesArrayToPush.Length, m_addressIpOfTarget, port);
                }
                udpClient.Send(bytesArrayToPush, bytesArrayToPush.Length, m_addressIpOfTarget, m_settablePortOfTarget);
            }
            }
            catch (Exception e)
            {

            }
        }

        // Permettons au developpeur d envoyer une entier dans le format little endian
        // Little Endian est la valeur par defaut pour C# BitConverter
        public void PushIntegerInLittleEndian(int value)
        {
            m_integerPushed = value;
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