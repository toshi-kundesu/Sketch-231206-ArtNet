using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class RGBWLightControllerUpdater
{
    static RGBWLightControllerUpdater()
    {
        EditorApplication.update += UpdateAllRGBWLightControllers;
    }

    private static void UpdateAllRGBWLightControllers()
    {
        if (EditorApplication.isPlaying)
        {
            return;
        }

        RGBWLightController[] controllers = UnityEngine.Object.FindObjectsOfType<RGBWLightController>();

        foreach (RGBWLightController controller in controllers)
        {
            if (controller != null)
            {
                controller.UpdateFixture();
            }
        }
    }
}