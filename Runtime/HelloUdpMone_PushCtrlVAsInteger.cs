using System.Collections;
using Eloi.HelloUDPWS;
using UnityEngine;
using UnityEngine.Events;

public class HelloUdpMone_PushCtrlVAsInteger : MonoBehaviour
{
    public UnityEvent<int> m_onIntegerPushed;
    public int m_lastPushedInteger;
    public HelloUdpEnumScratchToWarcraftKeyboard m_intKeyEnter = HelloUdpEnumScratchToWarcraftKeyboard.Enter;
    public HelloUdpEnumScratchToWarcraftKeyboard m_intKeyOpenChat = HelloUdpEnumScratchToWarcraftKeyboard.Enter;
    public HelloUdpEnumScratchToWarcraftKeyboard m_intKeyCtrl = HelloUdpEnumScratchToWarcraftKeyboard.LeftControl;
    public HelloUdpEnumScratchToWarcraftKeyboard m_intKeyV = HelloUdpEnumScratchToWarcraftKeyboard.KeyV;
    public HelloUdpEnumScratchToWarcraftKeyboard m_intKeyBackspace = HelloUdpEnumScratchToWarcraftKeyboard.Backspace;
    public float m_timeForChatToOpen = 0.3f;
    public float m_timeBetweenKeyPress = 0.1f;
   
    public void StartPressingEnterKey()
    {
        PushIntegerPress((int)m_intKeyEnter);

    }
    public void StopPressingEnterKey() {

        PushIntegerRelease((int)m_intKeyEnter);
    }
    public void TriggerOpenChat()
    {
        PushIntegerPress((int)m_intKeyOpenChat);
    }
    public void TriggerCloseChat() {

        PushIntegerRelease((int)m_intKeyOpenChat);
    }

    [ContextMenu(" Trigger Chat Past")]
    public void TriggerOpenPastAndCloseChat() {

        StartCoroutine(Coroutine_TriggerOpenPastAndCloseChat());
    }
    public IEnumerator Coroutine_TriggerOpenPastAndCloseChat() {

        PushIntegerPress((int)m_intKeyOpenChat);
        yield return new WaitForSeconds(m_timeForChatToOpen);
        PushIntegerRelease((int)m_intKeyOpenChat);


        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerPress((int)m_intKeyBackspace);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerRelease((int)m_intKeyBackspace);

        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerPress((int)m_intKeyCtrl);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerPress((int)m_intKeyV);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerRelease((int)m_intKeyV);
       // Debug.Log("T"+ m_intKeyV);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerRelease((int)m_intKeyCtrl);

        for (int i = 0; i < 2; i++)
        {
            PushIntegerPress((int)m_intKeyBackspace);
            yield return new WaitForSeconds(m_timeBetweenKeyPress);
            PushIntegerRelease((int)m_intKeyBackspace);
            yield return new WaitForSeconds(m_timeBetweenKeyPress);
        }


        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerPress((int)m_intKeyEnter);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerRelease((int)m_intKeyEnter);

    }

    [ContextMenu(" Trigger Past")]
    public void TriggerPast()
    {


        StartCoroutine(Coroutine_TriggerPast(false));

    }
    [ContextMenu(" Trigger Past with Backspace")]
    public void TriggerPastWithBackspace()
    {

        StartCoroutine(Coroutine_TriggerPast(true));

    }
    public IEnumerator Coroutine_TriggerPast(bool useBackspace)
    {
        PushIntegerPress((int)m_intKeyCtrl);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerPress((int)m_intKeyV);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerRelease((int)m_intKeyV);
        yield return new WaitForSeconds(m_timeBetweenKeyPress);
        PushIntegerRelease((int)m_intKeyCtrl);
        if (useBackspace)
        {
            for (int i = 0; i < 3; i++)
            {
                PushIntegerPress((int)m_intKeyBackspace);
                yield return new WaitForSeconds(m_timeBetweenKeyPress);
                PushIntegerRelease((int)m_intKeyBackspace);
                yield return new WaitForSeconds(m_timeBetweenKeyPress);
            }
        }
    }
    public void PushIntegerPress(int value)
    {
        m_lastPushedInteger = value;
        m_onIntegerPushed?.Invoke(value);
    }
    public void PushIntegerRelease(int value)
    {
        m_lastPushedInteger = value+1000;
        m_onIntegerPushed?.Invoke(value+1000);
    }
}
