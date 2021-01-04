using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LootLockerAdminRequests;
using ViewType;
using System;
using LootLocker;
using System.Linq;

namespace LootLockerAdmin
{
    public partial class LootlockerAdminPanel : EditorWindow
    {
        void DrawMissionsView()
        {
            // missionsSection.x = 0;
            // missionsSection.y = 60;
            // missionsSection.width = Screen.width;
            // missionsSection.height = Screen.height - 100;

            // GUI.DrawTexture(missionsSection, defaultSectionTexture);

            GUILayout.BeginArea(ContentSection);
            EditorGUILayout.Space();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Back", GUILayout.Height(20)))
            {
                currentView = View.Menu;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

        }
    }
}