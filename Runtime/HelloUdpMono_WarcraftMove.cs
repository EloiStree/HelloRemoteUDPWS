using System;
using UnityEngine;
using UnityEngine.Events;


namespace Eloi.HelloUDPWS
{


    public class HelloUdpMono_WarcraftMove : MonoBehaviour
{
    public UnityEvent<int> m_onIntegerActionPushed;
    public int m_lastPushed;
    public int m_strafeLeft = 1081;
    public int m_strafeRight = 1069;
    public int m_moveForward = 1038;
    public int m_moveBackward = 1040;
    public int m_moveUp = 1032;
    public int m_moveDown = 1088;
    public int m_rotateLeft = 1037;
    public int m_rotateRight = 1039;

    public int m_attack1 = 1049;
    public int m_attack2 = 1050;

    public int m_tabulation = 1009;
    public int m_interaction = 1070;

    public int m_flyKey = 1048;


    public void TapFlyKey()
    {
        PushStart(m_flyKey);
        PushStop(m_flyKey);
    }

    public void TapTabulation()
    {
        PushStart(m_tabulation);
        PushStop(m_tabulation);
    }
    public void TapInteraction()
    {
        PushStart(m_interaction);
        PushStop(m_interaction);
    }
    public void TapMoveUp()
    {
        PushStart(m_moveUp);
        PushStop(m_moveUp);
    }
    public void TapAttack2()
    {
        PushStart(m_attack1);
        PushStop(m_attack1);
    }
    public void TapAttack1()
    {
        PushStart(m_attack2);
        PushStop(m_attack2);
    }


    public int m_pitchUp = 1033;
    public int m_pitchDown = 1034;
    public void StartPitchDown() => PushStart(m_pitchDown);
    public void StopPitchDown() => PushStop(m_pitchDown);
    public void StartPitchUp() => PushStart(m_pitchUp);
    public void StopPitchUp() => PushStop(m_pitchUp);

    public void SetPitchDown(bool isOn)
    {
        if (isOn)
            PushStart(m_pitchDown);
        else
            PushStop(m_pitchDown);
    }
    public void SetPitchUp(bool isOn)
    {
        if (isOn)
            PushStart(m_pitchUp);
        else
            PushStop(m_pitchUp);
    }




    public void PushStart(int action)
    {
        m_lastPushed = action;
        m_onIntegerActionPushed?.Invoke(action);
    }
    public void PushStop(int action)
    {
        m_lastPushed = action+1000;
        m_onIntegerActionPushed?.Invoke(action + 1000);
    }

    public void SetStrafeLeft(bool isOn)
    {
        if (isOn)
            PushStart(m_strafeLeft);
        else
            PushStop(m_strafeLeft);
    }
    public void SetStrafeRight(bool isOn)
    {
        if (isOn)
            PushStart(m_strafeRight);
        else
            PushStop(m_strafeRight);
    }
    public void SetMoveForward(bool isOn)
    {
        if (isOn)
            PushStart(m_moveForward);
        else
            PushStop(m_moveForward);
    }
    public void SetMoveBackward(bool isOn)
    {
        if (isOn)
            PushStart(m_moveBackward);
        else
            PushStop(m_moveBackward);
    }
    public void SetMoveUp(bool isOn)
    {
        if (isOn)
            PushStart(m_moveUp);
        else
            PushStop(m_moveUp);
    }
    public void SetMoveDown(bool isOn)
    {
        if (isOn)
            PushStart(m_moveDown);
        else
            PushStop(m_moveDown);
    }
    public void SetRotateLeft(bool isOn)
    {
        if (isOn)
            PushStart(m_rotateLeft);
        else
            PushStop(m_rotateLeft);
    }
    public void SetRotateRight(bool isOn)
    {
        if (isOn)
            PushStart(m_rotateRight);
        else
            PushStop(m_rotateRight);
    }
    public void SetAttack1(bool isOn)
    {
        if (isOn)
            PushStart(m_attack1);
        else
            PushStop(m_attack1);
    }
    public void SetAttack2(bool isOn)
    {
        if (isOn)
            PushStart(m_attack2);
        else
            PushStop(m_attack2);
    }
    public void SetTabulation(bool isOn)
    {
        if (isOn)
            PushStart(m_tabulation);
        else
            PushStop(m_tabulation);
    }
    public void SetInteraction(bool isOn)
    {
        if (isOn)
            PushStart(m_interaction);
        else
            PushStop(m_interaction);
    }



    [ContextMenu("Push Start Strafe Left")]
    public void StartStrafeLeft() => PushStart(m_strafeLeft);

    [ContextMenu("Push Stop Strafe Left")]
    public void StopStrafeLeft() => PushStop(m_strafeLeft);

    [ContextMenu("Push Start Strafe Right")]
    public void StartStrafeRight() => PushStart(m_strafeRight);

    [ContextMenu("Push Stop Strafe Right")]
    public void StopStrafeRight() => PushStop(m_strafeRight);

    [ContextMenu("Push Start Move Forward")]
    public void StartMoveForward() => PushStart(m_moveForward);
    [ContextMenu("Push Stop Move Forward")]
    public void StopMoveForward() => PushStop(m_moveForward);
    [ContextMenu("Push Start Move Backward")]
    public void StartMoveBackward() => PushStart(m_moveBackward);

    [ContextMenu("Push Stop Move Backward")]
    public void StopMoveBackward() => PushStop(m_moveBackward);
    [ContextMenu("Push Start Move Up")]
    public void StartMoveUp() => PushStart(m_moveUp);
    [ContextMenu("Push Stop Move Up")]
    public void StopMoveUp() => PushStop(m_moveUp);
    [ContextMenu("Push Start Move Down")]
    public void StartMoveDown() => PushStart(m_moveDown);
    [ContextMenu("Push Stop Move Down")]
    public void StopMoveDown() => PushStop(m_moveDown);

    [ContextMenu("Push Start Rotate Left")]
    public void StartRotateLeft() => PushStart(m_rotateLeft);

    [ContextMenu("Push Stop Rotate Left")]
    public void StopRotateLeft() => PushStop(m_rotateLeft);

    [ContextMenu("Push Start Rotate Right")]
    public void StartRotateRight() => PushStart(m_rotateRight);

    [ContextMenu("Push Stop Rotate Right")]
    public void StopRotateRight() => PushStop(m_rotateRight);

    [ContextMenu("Push Start Attack1")]
    public void StartAttack1() => PushStart(m_attack1);

    [ContextMenu("Push Stop Attack1")]
    public void StopAttack1() => PushStop(m_attack1);

    [ContextMenu("Push Start Attack2")]
    public void StartAttack2() => PushStart(m_attack2);

    [ContextMenu("Push Stop Attack2")]
    public void StopAttack2() => PushStop(m_attack2);

    [ContextMenu("Push Start Tabulation")]
    public void StartTabulation() => PushStart(m_tabulation);

    [ContextMenu("Push Stop Tabulation")]
    public void StopTabulation() => PushStop(m_tabulation);

    [ContextMenu("Push Start Interaction")]
    public void StartInteraction() => PushStart(m_interaction);

    [ContextMenu("Push Stop Interaction")]
    public void StopInteraction() => PushStop(m_interaction);

    [ContextMenu("Tap All Move")]
    public void TapAllMove()
    {
        StartStrafeLeft();
        StartStrafeRight();

        StartMoveForward();
        StartMoveBackward();

        StartMoveUp();
        StartMoveDown();

        StartRotateLeft();
        StartRotateRight();

        StopStrafeLeft();
        StopStrafeRight();

        StopMoveForward();
        StopMoveBackward();

        StopMoveUp();
        StopMoveDown();

        StopRotateLeft();
        StopRotateRight();

    }
}

}