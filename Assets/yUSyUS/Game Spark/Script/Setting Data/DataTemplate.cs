using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameSpark
{
    public abstract class DataTemplate : ScriptableObject
    {
#if UNITY_EDITOR
        protected SerializedObject myView;
#endif

        public static float elementSpace = 5;
        public static float sectionSpace = 20;

        public abstract void DrawTap();
    }
}

