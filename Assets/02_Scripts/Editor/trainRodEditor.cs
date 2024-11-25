
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(trainRod))]

public class trainRodEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        trainRod delTestA = (trainRod)target;
        if (GUILayout.Button("pull lever"))
        {
            delTestA.Doit();
        }


    }
}