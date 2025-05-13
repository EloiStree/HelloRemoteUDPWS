using System;
using UnityEditor;
using UnityEngine;

namespace Eloi.HelloUDPWS { 
[CustomEditor(typeof(HelloUdpMono_WarcraftMove))]
public class HelloUdpMono_WarcraftMoveEditor : Editor
{
    int columnSize = 100;

    public static bool m_left;
    public static bool m_right;
    public static bool m_forward;
    public static bool m_backward;
    public static bool m_up;
    public static bool m_down;
    public static bool m_rotateLeft;
    public static bool m_rotateRight;

    public static bool m_attack1;
    public static bool m_attack2;
    public static bool m_tabulation;
    public static bool m_interaction;
    public override void OnInspectorGUI()
    {
        HelloUdpMono_WarcraftMove t = (HelloUdpMono_WarcraftMove)target;
        GUILayout.BeginVertical();
        AxisButton("Left", "Right", ref m_left, ref m_right, t.StartStrafeLeft, t.StopStrafeLeft, t.StartStrafeRight, t.StopStrafeRight);
        AxisButton("Backward", "Forward", ref m_backward, ref m_forward, t.StartMoveBackward, t.StopMoveBackward, t.StartMoveForward, t.StopMoveForward);
        AxisButton("Down", "Up", ref m_down, ref m_up, t.StartMoveDown, t.StopMoveDown, t.StartMoveUp, t.StopMoveUp);
        AxisButton("Rotate Left", "Rotate Right", ref m_rotateLeft, ref m_rotateRight, t.StartRotateLeft, t.StopRotateLeft, t.StartRotateRight, t.StopRotateRight);
        //AxisButton("Backward", "Forward", t.StartMoveBackward, t.StopMoveBackward, t.StartMoveForward, t.StopMoveForward);
        //AxisButton("Down", "Up", t.StartMoveDown, t.StopMoveDown, t.StartMoveUp, t.StopMoveUp);
        //AxisButton("Rotate Left", "Rotate Right", t.StartRotateLeft, t.StopRotateLeft, t.StartRotateRight, t.StopRotateRight);
        GUILayout.EndVertical();
        
        GUILayout.BeginHorizontal();
        IsButtonChanged("Attack 1", ref m_attack1, t.StartAttack1, t.StopAttack1);
        IsButtonChanged("Attack 2", ref m_attack2, t.StartAttack2, t.StopAttack2);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        IsButtonChanged("Tabulation", ref m_tabulation, t.StartTabulation, t.StopTabulation);
        IsButtonChanged("Interact", ref m_interaction, t.StartInteraction, t.StopInteraction);
        GUILayout.EndHorizontal();
        
        if (GUILayout.Button("Tap All Move", GUILayout.Width(columnSize)))
        {
            t.TapAllMove();
        }
        base.OnInspectorGUI();


    }

    public void IsButtonChanged(string label, ref bool isButton, Action start, Action stop)
    {
        bool previous = isButton;
        bool toggled = GUILayout.Toggle(isButton, label, GUILayout.Width(columnSize));
        if (previous != toggled)
        {
            isButton = toggled;
            if (isButton)
            {
                start();
            }
            else
            {
                stop();
            }
        }
    }
    private void AxisButton(string v1, string v2, ref bool negativeMemory, ref bool positiveMemory, Action startNegative, Action stopNegative, Action startPositive, Action stopPositive)
    {
        GUILayout.BeginHorizontal();
        IsButtonChanged(v1, ref negativeMemory, startNegative, stopNegative);
        IsButtonChanged(v2, ref positiveMemory, startPositive, stopPositive);
        GUILayout.EndHorizontal();
    }
}
}
