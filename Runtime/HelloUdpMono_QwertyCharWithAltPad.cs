using System;
using System.Collections;
using Codice.Client.Common.Connection;
using UnityEngine;
using UnityEngine.Events;


namespace Eloi.HelloUDPWS
{
    public class HelloUdpMono_QwertyCharWithAltPad : MonoBehaviour {

        HelloUdpEnumScratchToWarcraftKeyboard m_alt = HelloUdpEnumScratchToWarcraftKeyboard.Alt;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad0 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad0;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad1 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad1;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad2 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad2;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad3 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad3;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad4 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad4;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad5 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad5;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad6 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad6;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad7 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad7;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad8 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad8;
        HelloUdpEnumScratchToWarcraftKeyboard m_numpad9 = HelloUdpEnumScratchToWarcraftKeyboard.Numpad9;




        [System.Serializable]
        public class CharToNumpad {
            public string m_charAsString;
            public char m_char;
            public int m_numpadCode;
            public CharToNumpad(char c, int numpadCode)
            {
                m_charAsString = c.ToString();
                m_char = c;
                m_numpadCode = numpadCode;
            }
        }

        // for ~!@#$%^&*()_-=+[]{};:'",<.>/?\|
        public CharToNumpad[] m_charToNumpad = new CharToNumpad[] {

            new CharToNumpad('~', 126),
            new CharToNumpad('!', 33),
            new CharToNumpad('@', 64),
            new CharToNumpad('#', 35),
            new CharToNumpad('$', 36),
            new CharToNumpad('%', 37),
            new CharToNumpad('^', 94),
            new CharToNumpad('&', 38),
            new CharToNumpad('*', 42),
            new CharToNumpad('(', 40),
            new CharToNumpad(')', 41),
            new CharToNumpad('_', 95),
            new CharToNumpad('-', 45),
            new CharToNumpad('=', 61),
            new CharToNumpad('+', 43),
            new CharToNumpad('[', 91),
            new CharToNumpad(']', 93),

            new CharToNumpad('{', 123),
            new CharToNumpad('}', 125),
            new CharToNumpad(';', 59),
            new CharToNumpad(':', 58),
            new CharToNumpad('\'', 39),
            new CharToNumpad('"', 34),
            new CharToNumpad(',', 44),
            new CharToNumpad('<', 60),
            new CharToNumpad('.', 46),
            new CharToNumpad('>', 62),
            new CharToNumpad('?', 63),
            new CharToNumpad('/', 47),
            new CharToNumpad('\\', 92),
            new CharToNumpad('|', 124),
            new CharToNumpad('`', 96),
            new CharToNumpad(' ', 32),

        };

        public void TryPushCharInList(char c)
        {
            foreach (CharToNumpad charToNumpad in m_charToNumpad)
            {
                if (charToNumpad.m_char == c)
                {
                    PushInNumpadCodeWithAlt(charToNumpad.m_numpadCode);
                    return;
                }
            }
            Debug.LogWarning("Char not found in list: " + c);
        }
        public void TryPushCharInList(string c)
        {

            if (int.TryParse(c, out int numpadCode))
            {
                PushInNumpadCodeWithAlt(numpadCode);
                return;
            }
            foreach (CharToNumpad charToNumpad in m_charToNumpad)
            {
                if (charToNumpad.m_charAsString == c)
                {
                    PushInNumpadCodeWithAlt(charToNumpad.m_numpadCode);
                    return;
                }
            }
            Debug.LogWarning("Char not found in list: " + c);
        }

        public void PushInNumpadCodeWithAlt(int code)
        {
            StartCoroutine(Coroutine_PushInNumpadCodeWithAlt(code));
        }

        public void PushInNumpadCodeWithAltAsGivenText(string text)
        {
            StartCoroutine(Coroutine_PushInNumpadCodeWithAltGivenText(text));
        }

        public float m_timeForAltToBePressed = 0.05f;
        public float m_timeBetzeenCharPress = 0.05f;
        public float m_timeBeforeReleaseAlt = 0.05f;
        public float m_timeAfterReleaseAlt = 0.05f;
        public float m_timeBetweenPresseNumpad = 0.05f;

        public IEnumerator Coroutine_PushInNumpadCodeWithAltGivenText(string text)
        {
            foreach (char c in text)
            {
                if(TryRenewToken(c, out int code))
                {
                    yield return Coroutine_PushInNumpadCodeWithAlt(code);
                }
                
            }
        }

        private bool TryRenewToken(char c, out int code)
        {
            foreach (CharToNumpad charToNumpad in m_charToNumpad)
            {
                if (charToNumpad.m_char == c)
                {
                    code = charToNumpad.m_numpadCode;
                    return true;
                }
            }
            code = -1;
            return false;
        }

        public IEnumerator Coroutine_PushInNumpadCodeWithAlt(int[] codes )
        {
            foreach (int code in codes)
            {
                yield return Coroutine_PushInNumpadCodeWithAlt(code);
            }
        }    
        private IEnumerator Coroutine_PushInNumpadCodeWithAlt(int code)
        {
            StartPressingAlt();
            yield return new WaitForSeconds(m_timeForAltToBePressed);

            string text = code.ToString();
            foreach (char c in text)
            {
                yield return Coroutine_PUshInNumpad(c);
                yield return new WaitForSeconds(m_timeBetzeenCharPress);
            }

            yield return new WaitForSeconds(m_timeBeforeReleaseAlt);
            StopPressingAlt();
            yield return new WaitForSeconds(m_timeAfterReleaseAlt);
        }


        private IEnumerator  Coroutine_PUshInNumpad(char c)
        {
            switch (c)
            {

                case '0':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad0);
                    break;
                case '1':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad1);
                    break;
                case '2':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad2);
                    break;
                case '3':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad3);
                    break;
                case '4':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad4);
                    break;
                case '5':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad5);
                    break;
                case '6':

                    yield return Coroutine_PushStartStopDirect((int)m_numpad6);
                    break;
                case '7':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad7);
                    break;
                case '8':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad8);
                    break;
                case '9':
                    yield return Coroutine_PushStartStopDirect((int)m_numpad9);
                    break;
                default:

                    break;

            }
        }

        private void PushInNumpad(char c)
        {
            switch (c)
            {

                case '0':
                    PushStartStopDirect((int)m_numpad0);
                    break;
                case '1':
                    PushStartStopDirect((int)m_numpad1);
                    break;
                case '2':
                    PushStartStopDirect((int)m_numpad2);
                    break;
                case '3':
                    PushStartStopDirect((int)m_numpad3);
                    break;
                case '4':
                    PushStartStopDirect((int)m_numpad4);
                    break;
                case '5':
                    PushStartStopDirect((int)m_numpad5);
                    break;
                case '6':

                    PushStartStopDirect((int)m_numpad6);
                    break;
                case '7':
                    PushStartStopDirect((int)m_numpad7);
                    break;
                case '8':
                    PushStartStopDirect((int)m_numpad8);
                    break;
                case '9':
                    PushStartStopDirect((int)m_numpad9);
                    break;
                default:
                  
                    break;

            }
        }
        public UnityEvent<int> m_onIntegerActionPushed;
        public int m_lastPushed; 
        public void PushStart(int action)
        {
            m_lastPushed = action;
            m_onIntegerActionPushed?.Invoke(action);
        }
        public void PushStop(int action)
        {
            m_lastPushed = action + 1000;
            m_onIntegerActionPushed?.Invoke(action + 1000);
        }
        public IEnumerator Coroutine_PushStartStopDirect(int action)
        {
            PushStart(action);
            yield return new WaitForSeconds(m_timeBetweenPresseNumpad);
            PushStop(action);
        }
        public void PushStartStopDirect(int action)
        {
            PushStart(action);
            PushStop(action);
        }
        public void StartPressingAlt()
        {
            PushStart((int)m_alt);
        }
        public void StopPressingAlt()
        {
            PushStop((int)m_alt);
        }

    }

}