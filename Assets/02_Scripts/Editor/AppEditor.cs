
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(App))]

public class AppEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        App delTestA = (App)target;
        if (GUILayout.Button("go train"))
        {
            App.Instance.traingo.Invoke();
        }
    }
}