using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using Ebac.StateMachine;

[CustomEditor(typeof(AnimatorManagerPlayer))]
public class StateMachinePlayerGui : Editor
{
    public bool showFolDout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AnimatorManagerPlayer fsm = (AnimatorManagerPlayer)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        //if (fsm.stateMachine == null) return;

        if (fsm.stateMachines.currentstate != null)
        {
            EditorGUILayout.LabelField("current state: ", fsm.stateMachines.currentstate.ToString());
        }

        showFolDout = EditorGUILayout.Foldout(showFolDout, "Avaliable States");

        if (showFolDout)
        {
            if (fsm.stateMachines.dictionarystate != null)
            {
                var keys = fsm.stateMachines.dictionarystate.Keys.ToArray();
                var vals = fsm.stateMachines.dictionarystate.Values.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }
            }
        }
    }
}
