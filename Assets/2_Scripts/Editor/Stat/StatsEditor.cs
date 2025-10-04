#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Stats))]
public class StatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);
        GUILayout.Label("[ Func ]");
        
        if (GUILayout.Button("Report", GUILayout.Height(25)))
        {
            Stats stats = target as Stats;
            
            stats?.Report();
        }
    }
}
#endif