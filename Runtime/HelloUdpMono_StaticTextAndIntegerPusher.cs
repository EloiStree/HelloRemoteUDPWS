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