using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Eloi.HelloUDPWS
{
    public class HelloUdpMono_WarcraftClipboard: MonoBehaviour
    {
        public UnityEvent<int> m_onIntegerActionPushed;
        public int m_lastPushed;
        public HelloUdpEnumScratchToWarcraftKeyboard m_control = HelloUdpEnumScratchToWarcraftKeyboard.Control;
        public HelloUdpEnumScratchToWarcraftKeyboard m_keyV = HelloUdpEnumScratchToWarcraftKeyboard.KeyV;
        public HelloUdpEnumScratchToWarcraftKeyboard m_backspace = HelloUdpEnumScratchToWarcraftKeyboard.Backspace;
        public HelloUdpEnumScratchToWarcraftKeyboard m_openChatKey = HelloUdpEnumScratchToWarcraftKeyboard.Enter;
        public HelloUdpEnumScratchToWarcraftKeyboard m_closeChatKey = HelloUdpEnumScratchToWarcraftKeyboard.Enter;

        public float m_timeBeforeKeys = 0.05f;

        public float m_timeBeforeChatOpen = 0.3f;
        public float m_timeToPast = 0.1f;

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

        [ContextMenu("Push Chat Past")]
        public void TriggerChatPast()
        {
            StartCoroutine(Coroutine_ChatPast());
        }

        private IEnumerator Coroutine_ChatPast()
        {
            PushStart((int)m_openChatKey);
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStop((int)m_openChatKey);

            yield return new WaitForSeconds(m_timeBeforeChatOpen);
            yield return Coroutine_Past();
            yield return new WaitForSeconds(m_timeToPast);

            yield return Coroutine_BackSpace();
            yield return Coroutine_BackSpace();

            PushStart((int)m_closeChatKey);
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStop((int)m_closeChatKey);


        }

        private IEnumerator Coroutine_BackSpace()
        {
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStart((int)m_backspace);
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStop((int)m_backspace);
        }

        public void TriggerPastCoroutine()
        {

            StartCoroutine(Coroutine_Past());
        }
        private IEnumerator Coroutine_Past()
        {
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStart((int)m_control);
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStart((int)m_keyV);
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStop((int)m_keyV);
            yield return new WaitForSeconds(m_timeBeforeKeys);
            PushStop((int)m_control);
        }

    }

}