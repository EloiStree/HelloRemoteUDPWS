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