using UnityEngine;
using System.Collections;

namespace MeshCombineStudio
{
	public class FPSmeter : MonoBehaviour {

        // A FPS counter.
        // It calculates frames/second over each updateInterval,
        // so the display does not keep changing wildly.
        
		public float updateInterval = 0.5f;
		private float lastInterval; // Last interval end time
		private int frames = 0; // Frames over current interval
		public static float fps; // Current FPS
		public bool showFPS = true;
        
        float timeNow;
        
		void OnGUI()
        {
            if (showFPS) {
                GUI.color = Color.red;
                GUI.Label(new Rect(Screen.width - 75, 10, 150, 20), "FPS " + (Mathf.Round(fps * 100) / 100).ToString("F0"));
                GUI.color = Color.white;
			}
		}
		
		void Update()
        {
            timeNow = Time.realtimeSinceStartup;

            ++frames;
           
            if (timeNow > lastInterval + updateInterval ) {
				fps = frames / (timeNow - lastInterval);
                frames = 0;
				lastInterval = timeNow;
			}
		}
	}
}