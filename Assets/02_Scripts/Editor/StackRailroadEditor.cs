using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StackRailroad))]
public class StackRailroadEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StackRailroad delTestA = (StackRailroad)target;
        if (GUILayout.Button("Add wood"))
        {
            delTestA.AddRail();
        }
        //if(GUILayout.Button("Add stone")){
        //     delTestA.addstone();
        // }


    }

}
