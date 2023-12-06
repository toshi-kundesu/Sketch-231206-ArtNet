using UnityEngine;
using UnityEditor;

public class ChannelSetter : EditorWindow
{
    GameObject rootObject;
    int startAddress = 1;
    int interval = 1;

    [MenuItem("Window/ChannelSetter")]
    public static void ShowWindow()
    {
        GetWindow<ChannelSetter>("ChannelSetter");
    }

    void OnGUI()
    {
        GUILayout.Label("Set Start Addresses for RGBWLightController", EditorStyles.boldLabel);

        rootObject = (GameObject)EditorGUILayout.ObjectField("Root Object", rootObject, typeof(GameObject), true);
        startAddress = EditorGUILayout.IntField("Start Address", startAddress);
        interval = EditorGUILayout.IntField("Interval", interval);

        if (GUILayout.Button("Set Start Addresses"))
        {
            if (rootObject != null)
            {
                SetStartAddresses(rootObject, startAddress, interval);
            }
        }
    }

    void SetStartAddresses(GameObject root, int startAddress, int interval)
    {
        RGBWLightController[] controllers = root.GetComponentsInChildren<RGBWLightController>();
        foreach (RGBWLightController controller in controllers)
        {
            controller.startAddress = startAddress;
            startAddress += interval;
        }
    }
}