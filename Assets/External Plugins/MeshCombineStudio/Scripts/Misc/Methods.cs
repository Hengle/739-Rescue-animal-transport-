using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshCombineStudio
{
    static public class Methods
    {
        static public void SetTag(GameObject go, string tag)
        {
            Transform[] tArray = go.GetComponentsInChildren<Transform>();
            for (int i = 0; i < tArray.Length; i++) { tArray[i].tag = tag; }
        }

        static public void SetTagWhenCollider(GameObject go, string tag)
        {
            Transform[] tArray = go.GetComponentsInChildren<Transform>();
            for (int i = 0; i < tArray.Length; i++)
            {
                if (tArray[i].GetComponent<Collider>() != null) tArray[i].tag = tag;
            }
        }

        static public void SetTagAndLayer(GameObject go, string tag, int layer)
        {
            // Debug.Log("Layer " + layer);
            Transform[] tArray = go.GetComponentsInChildren<Transform>();
            for (int i = 0; i < tArray.Length; i++) { tArray[i].tag = tag; tArray[i].gameObject.layer = layer; }
        }

        static public void SetLayer(GameObject go, int layer)
        {
            go.layer = layer;
            Transform[] tArray = go.GetComponentsInChildren<Transform>();
            for (int i = 0; i < tArray.Length; i++) tArray[i].gameObject.layer = layer;
        }

        static public bool Contains(string compare, string name)
        {
            List<string> cuts = new List<string>();
            int index;

            do
            {
                index = name.IndexOf("*");

                if (index != -1)
                {
                    if (index != 0) { cuts.Add(name.Substring(0, index)); }
                    if (index != name.Length - 1) { name = name.Substring(index + 1); }
                    else break;
                }
            }
            while (index != -1);

            cuts.Add(name);

            for (int i = 0; i < cuts.Count; i++)
            {
                //Debug.Log(cuts.items[i] +" " + compare);
                if (!compare.Contains(cuts[i])) return false;
            }
            //Debug.Log("Passed");
            return true;
        }

        static public T[] Search<T>(GameObject parentGO = null)
        {
            GameObject[] gos;
            // if (parentGO == null) gos = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            gos = new GameObject[] { parentGO };

            if (typeof(T) == typeof(GameObject))
            {
                List<GameObject> list = new List<GameObject>();
                for (int i = 0; i < gos.Length; i++)
                {
                    Transform[] transforms = gos[i].GetComponentsInChildren<Transform>(true);
                    for (int j = 0; j < transforms.Length; j++) list.Add(transforms[j].gameObject);
                }
                return list.ToArray() as T[];
            }
            else
            {
                if (parentGO == null)
                {
                    List<T> list = new List<T>();
                    for (int i = 0; i < gos.Length; i++)
                    {
                        list.AddRange(gos[i].GetComponentsInChildren<T>(true));
                    }
                    return list.ToArray();
                }
                else return parentGO.GetComponentsInChildren<T>(true);
            }
        }

        static public T Find<T>(GameObject parentGO, string name) where T : Object
        {
            T[] gos = Search<T>(parentGO);

            for (int i = 0; i < gos.Length; i++)
            {
                if (gos[i].name == name) return gos[i];
            }
            return null;
        }

        static public void SetCollidersActive(Collider[] colliders, bool active, string[] nameList)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                for (int j = 0; j < nameList.Length; j++)
                {
                    if (colliders[i].name.Contains(nameList[j])) colliders[i].enabled = active;
                }
            }
        }
    }
}