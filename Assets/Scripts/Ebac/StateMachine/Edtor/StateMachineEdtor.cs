using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FSMexemple))]
public class StateMachineEdtor : Editor
{
    public bool showFolDout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FSMexemple fsm = (FSMexemple)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        //if (fsm.stateMachine == null) return;

        if (fsm.stateMachine.currentstate != null)
        {
            EditorGUILayout.LabelField("current state: ", fsm.stateMachine.currentstate.ToString());
        }

        showFolDout = EditorGUILayout.Foldout(showFolDout, "Avaliable States");

        if (showFolDout)
        {
            if (fsm.stateMachine.dictionarystate != null)
            {
                var keys = fsm.stateMachine.dictionarystate.Keys.ToArray();
                var vals = fsm.stateMachine.dictionarystate.Values.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }
            }
        }
    }
}
