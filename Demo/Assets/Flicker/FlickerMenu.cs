using UnityEditor;
using UnityEngine;

namespace Flicker
{
#if (UNITY_EDITOR)
    public class FlickerMenu
    {
        [MenuItem("Flicker/Flicker Input")]
        public static void CreateFlickerInput()
        {
            var inputObj = CreateEmpty();
            inputObj.AddComponent<FlickerInput>();
        }

        static GameObject CreateEmpty()
        {
            GameObject obj = new GameObject("Flicker Input");
            Undo.RegisterCreatedObjectUndo(obj, "Create new empty");
            Selection.objects = new Object[] {obj};
            return obj;
        }
    }
#endif
}
