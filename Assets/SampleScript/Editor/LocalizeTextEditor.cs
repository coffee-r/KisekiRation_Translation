using UnityEditor;

[CanEditMultipleObjects, CustomEditor(typeof(LocalizeText), true)]
public class LocalizeTextEditor : UnityEditor.UI.TextEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        this.serializedObject.Update();
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("textId"), true);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("language"), true);
        this.serializedObject.ApplyModifiedProperties();
    }
}