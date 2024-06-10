using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
public class UnlockObjectReplacer : EditorWindow
{

    private GameObject[] replacingObject;
    private bool[] activeElement = new bool[] { false };
    private GameObject prefab;
    private static List<GameObject> newObject;
    private Transform parent;
    [MenuItem("Window/UnlockObjectReplacer")]
    static void EditorInit()
    {
        newObject = new List<GameObject>();
        UnlockObjectReplacer editor = GetWindow<UnlockObjectReplacer>("Replacer");
        editor.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button(new GUIContent("Load", "LoadObject"), GUILayout.Width(40), GUILayout.Height(40)))
        {
            replacingObject = GameObject.FindGameObjectsWithTag("roomUnlocking");
        }
            activeElement[0] = EditorGUILayout.Foldout(activeElement[0], "Objects");
        if (activeElement[0])
        {
            for(int i  = 0;  i < replacingObject.Length; i++)
            {
                replacingObject[i] = (GameObject)EditorGUILayout.ObjectField(new GUIContent(title = "UnlockOld "+i), replacingObject[i], typeof(GameObject), true);
            }
        }
        parent = (Transform)EditorGUILayout.ObjectField(new GUIContent(title = "Parent"), parent, typeof(Transform), true);
        prefab = (GameObject)EditorGUILayout.ObjectField(new GUIContent(title = "Prefab"), prefab, typeof(GameObject),true);
        if (GUILayout.Button(new GUIContent("Replace", "Replace Object"), GUILayout.Width(40), GUILayout.Height(40)))
        {
            for(int i = 0; i < replacingObject.Length;i++)
            {
                Creator(replacingObject[i]);
            }
        }
    }

    private void Creator(GameObject oldObject)
    {
        GameObject replacedUnlokcer = PrefabUtility.InstantiatePrefab(prefab, parent) as GameObject;
        replacedUnlokcer.transform.position = oldObject.transform.position;
        UnlockingEnvironment newUnEnvi = replacedUnlokcer.GetComponent<UnlockingEnvironment>(),
            oldUnEnvi = oldObject.GetComponent<UnlockingEnvironment>();

        newUnEnvi.unlockingObject = oldUnEnvi.unlockingObject;
        newUnEnvi.hideObject = oldUnEnvi.hideObject;
        newUnEnvi.cost = oldUnEnvi.cost;
        newUnEnvi.roomNumber = oldUnEnvi.roomNumber;
        newUnEnvi.environmentId = oldUnEnvi.environmentId;
        replacedUnlokcer.name = oldObject.name;
        GameObject.DestroyImmediate(oldObject);
    }

}
#endif
