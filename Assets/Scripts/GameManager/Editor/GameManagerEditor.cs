using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public bool showFolDout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager fsm = (GameManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        if (fsm.stateMachine == null) return;

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

