using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Randoms.ParkingKit.LevelEditor
{
    using Randoms.Editor.Util;
    
    

    public class LevelEditorWindow: EditorWindow 
    {

        private   static  Texture2D    backgroundTexture;
        private   const   float        windowSize = 400;
        private   static  bool         isDraging = false;
        private   static  Vector2      inspectorScrollPos;
        private   static  Vector2      gridScrollPos;
        private   static  bool         canScrollGrid = false;
        

        private  static   GameObject  obj;
        public static string[] selStrings = new string [1000];
        
        public static int selGridInt = 0;

        /// <summary>
        /// Opens Window
        /// <summary>
        [MenuItem ("Randoms/ParkingKit/LevelEditor")]
        private static void OpenWindow ()
        {
            bool createFloatingWindow = false;
            EditorWindow window = EditorWindow.GetWindow (typeof (LevelEditorWindow), createFloatingWindow, "Level Editor", true);
            backgroundTexture = Resources.Load <Texture2D>("DarkGreyDots_texture") as Texture2D;
            
            for (int i = 0 ; i < selStrings.Length ; i += 1)
            {
                selStrings [i] = $"Grid_{i}";   
            }
            
        }

        
        /// <summary>
        /// OnGUI is called for rendering and handling GUI events.
        /// This function can be called multiple times per frame (one call per event).
        /// </summary>
        private void OnGUI()
        {
            EventHandler ();
            
            GUILayout.BeginVertical ();
            {

                GUILayout.BeginHorizontal();
                {
                    InspectorWindow ();
                    GUILayout.Space (10);
                    RenderGrid ();
                }
                GUILayout.EndHorizontal ();

            }
            GUILayout.EndVertical ();
        }
        

        /// <summary>
        /// Handles Events
        /// </summary>
        private void EventHandler ()
        {
            Event e = Event.current;
            if (Event.current.type == EventType.MouseDown)
            {
                Debug.Log ("Mouse Down");
            }
            
            canScrollGrid = e.alt;
            
            if (canScrollGrid) Debug.Log ("Alt Press");
        }
        

        /// <summary>
        /// Inspector Window
        /// </summary>
        private void InspectorWindow ()
        {
            float width = position.width / 4f;
            //  GUIStyleUtil.CardStyle
            inspectorScrollPos = EditorGUILayout.BeginScrollView(inspectorScrollPos, false, true, GUIStyle.none, GUIStyle.none, GUIStyleUtil.CardStyleMini, GUILayout.Width(width), GUILayout.Height(position.height));
            {
                GUILayout.BeginVertical ();
                GUILayout.Label ("Level Editor Inspector", GUIStyleUtil.BoldTitleCentered);
                GUILayout.Space (10);
                
                for (int i = 0 ; i < 10; i  += 1)
                {
                    GUILayout.BeginHorizontal ();
                    GUILayout.Space (5);
                    obj = (GameObject)EditorGUILayout.ObjectField(obj, typeof(GameObject), false);
                    GUILayout.EndHorizontal ();
                }

                GUILayout.Space (10);
                GUILayout.Button ("Add Objects", GUIStyleUtil.DropDownMiniButton);

                GUILayout.EndVertical ();
            }
            EditorGUILayout.EndScrollView ();
            
        }


        private void RenderGrid ()
        {
            gridScrollPos = EditorGUILayout.BeginScrollView (gridScrollPos, true, true, GUIStyle.none, GUIStyle.none, GUIStyleUtil.BoxContainer);
            {
                selGridInt = GUILayout.SelectionGrid (selGridInt, selStrings, 20); 
            }
            EditorGUILayout.EndScrollView ();
        }
    }
}



