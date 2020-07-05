using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshCombineStudio
{
    public class SwapCombineKey : MonoBehaviour
    {
        static public List<MeshCombiner> meshCombinerList = new List<MeshCombiner>();
        MeshCombiner meshCombiner;

        private void Awake()
        {
            meshCombiner = GetComponent<MeshCombiner>();
            meshCombinerList.Add(meshCombiner);
        }

        void Update()
        {
            if (Input.GetKeyDown(meshCombiner.combineSwapKey))
            {
                meshCombiner.SwapCombine();
            }
        }
        
        private void OnGUI()
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(10, 10, 200, 20), "Toggle with '" + meshCombiner.combineSwapKey.ToString() +"' key.");

            for (int i = 0; i < meshCombinerList.Count; i++)
            {
                MeshCombiner meshCombiner = meshCombinerList[i];
                if (meshCombiner.combinedActive) GUI.Label(new Rect(10, 30 + (i * 20), 300, 20), meshCombiner.gameObject.name + " is Enabled.");
                else GUI.Label(new Rect(10, 30 + (i * 20), 300, 20), meshCombiner.gameObject.name + " is Disabled.");
            }
            GUI.color = Color.white;
        }
    }
}
