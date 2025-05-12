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