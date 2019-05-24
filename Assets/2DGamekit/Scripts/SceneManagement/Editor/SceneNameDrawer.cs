﻿using System;
using UnityEditor;
using UnityEngine;

namespace Gamekit2D
{
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNameDrawer : PropertyDrawer
    {
        int m_SceneIndex = -1;
        GUIContent[] m_SceneNames;
        readonly string[] k_ScenePathSplitters = { "/", ".unity" };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (EditorBuildSettings.scenes.Length == 0) return;
            if (m_SceneIndex == -1)
                Setup(property);

            int oldIndex = m_SceneIndex;
            m_SceneIndex = EditorGUI.Popup(position, label, m_SceneIndex, m_SceneNames);

            if (oldIndex != m_SceneIndex)
                property.stringValue = m_SceneNames[m_SceneIndex].text;
        }

        void Setup(SerializedProperty property)
        {
            EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
            m_SceneNames = new GUIContent[scenes.Length];

            for (int i = 0; i < m_SceneNames.Length; i++)
            {
                string path = scenes[i].path;
                string[] splitPath = path.Split(k_ScenePathSplitters, StringSplitOptions.RemoveEmptyEntries);

                string sceneName = "";
                if (splitPath.Length > 0)
                    sceneName = splitPath[splitPath.Length - 1];
                else
                    sceneName = "(Deleted Scene)";
                m_SceneNames[i] = new GUIContent(sceneName);
            }

            if (m_SceneNames.Length == 0)
                m_SceneNames = new[] { new GUIContent("[No Scenes In Build Settings]") };

            if (!string.IsNullOrEmpty(property.stringValue))
            {
                bool sceneNameFound = false;
                for (int i = 0; i < m_SceneNames.Length; i++)
                {
                    if (m_SceneNames[i].text == property.stringValue)
                    {
                        m_SceneIndex = i;
                        sceneNameFound = true;
                        break;
                    }
                }
                if (!sceneNameFound)
                    m_SceneIndex = 0;
            }
            else m_SceneIndex = 0;

            property.stringValue = m_SceneNames[m_SceneIndex].text;
        }
    }
}