using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GatherResource))]

public class GatherResourceEditor : Editor

{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GatherResource delTestA= (GatherResource)target;
        if(GUILayout.Button("Add wood")){
            delTestA.addwood();
        }
        if(GUILayout.Button("Add stone")){
            delTestA.addstone();
        }
        

    }
}