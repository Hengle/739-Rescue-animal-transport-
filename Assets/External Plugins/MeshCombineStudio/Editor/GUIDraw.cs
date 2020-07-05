using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshCombineStudio
{ 
    static public class GUIDraw
    {

        static public void DrawSpacer(float space = 5)
        {
            GUILayout.Space(space);
            EditorGUILayout.BeginHorizontal();
            GUI.color = new Color(0.5f, 0.5f, 0.5f, 1);
            GUILayout.Button("", GUILayout.Height(5));
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(space);

            GUI.color = Color.white;
        }

        static public void Label(string label, int fontSize)
        {
            int fontSizeOld = EditorStyles.label.fontSize;
            EditorStyles.boldLabel.fontSize = fontSize;
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel, GUILayout.Height(fontSize + 6));
            EditorStyles.boldLabel.fontSize = fontSizeOld;
        }

        static public void LabelWidthUnderline(string label, int fontSize, bool boldLabel = true)
        {
            int fontSizeOld = EditorStyles.label.fontSize;
            EditorStyles.boldLabel.fontSize = fontSize;
            EditorGUILayout.LabelField(label, boldLabel ? EditorStyles.boldLabel : EditorStyles.label, GUILayout.Height(fontSize + 6));
            EditorStyles.boldLabel.fontSize = fontSizeOld;
            Rect rect = GUILayoutUtility.GetLastRect();
            if (EditorGUIUtility.isProSkin) GUI.color = Color.grey; else GUI.color = Color.black;
            GUI.DrawTexture(new Rect(rect.x, rect.yMax, rect.width, 1), Texture2D.whiteTexture);
            GUI.color = Color.white;
            GUILayout.Space(5);
        }

        static public void PropertyArray(SerializedProperty property, bool drawUnderLine = true, bool editArrayLength = true)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.indentLevel++;
            GUILayout.Space(0);
            Rect rect = GUILayoutUtility.GetLastRect();
            property.isExpanded = EditorGUI.Foldout(new Rect(rect.x, rect.y + 3, 25, 18), property.isExpanded, "");
            if (drawUnderLine && property.isExpanded) LabelWidthUnderline(property.displayName, 12); else Label(property.displayName, 12);
            EditorGUILayout.EndHorizontal();

            if (property.isExpanded)
            {
                GUILayout.Space(2);
                EditorGUI.indentLevel++;
                if (editArrayLength) property.arraySize = EditorGUILayout.IntField("Size", property.arraySize);
                
                for (int i = 0; i < property.arraySize; i++)
                {
                    SerializedProperty elementProperty = property.GetArrayElementAtIndex(i);

                    EditorGUILayout.PropertyField(elementProperty);
                }
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }
    }
}