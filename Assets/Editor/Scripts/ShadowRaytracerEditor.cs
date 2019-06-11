using UnityEngine;
using UnityEditor;
using UTJ.RaytracedHardShadow;

namespace UTJ.RaytracedHardShadowEditor
{
    [CustomEditor(typeof(UTJ.RaytracedHardShadow.ShadowRaytracer))]
    public class ShadowRaytracerEditor : Editor
    {
        [MenuItem("GameObject/RaytracedHardShadow/Create ShadowRaytracer", false, 10)]
        public static void CreateMeshSyncServer(MenuCommand menuCommand)
        {
            var go = new GameObject();
            go.name = "ShadowRaytracer";
            var srt = go.AddComponent<ShadowRaytracer>();
            Undo.RegisterCreatedObjectUndo(go, "ShadowRaytracer");
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();

            var t = target as ShadowRaytracer;
            var so = serializedObject;

            EditorGUILayout.PropertyField(so.FindProperty("m_shadowBuffer"));
            EditorGUILayout.PropertyField(so.FindProperty("m_camera"));
            EditorGUILayout.PropertyField(so.FindProperty("m_ignoreSelfShadow"));
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(so.FindProperty("m_lightScope"));
            if (t.lightScope == ShadowRaytracer.ObjectScope.SelectedScenes)
                EditorGUILayout.PropertyField(so.FindProperty("m_lightScenes"), true);
            else if (t.lightScope == ShadowRaytracer.ObjectScope.SelectedObjects)
                EditorGUILayout.PropertyField(so.FindProperty("m_lightObjects"), true);
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(so.FindProperty("m_geometryScope"));
            if (t.geometryScope == ShadowRaytracer.ObjectScope.SelectedScenes)
                EditorGUILayout.PropertyField(so.FindProperty("m_geometryScenes"), true);
            else if (t.geometryScope == ShadowRaytracer.ObjectScope.SelectedObjects)
                EditorGUILayout.PropertyField(so.FindProperty("m_geometryObjects"), true);
            EditorGUILayout.Space();

            so.ApplyModifiedProperties();
        }
    }
}