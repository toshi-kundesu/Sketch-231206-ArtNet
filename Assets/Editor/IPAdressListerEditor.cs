using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IPAddressLister))]
public class IPAddressListerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IPAddressLister myScript = (IPAddressLister)target;
        if(GUILayout.Button("Get Available IPs"))
        {
            myScript.GetAvailableIPs();
        }
    }
}