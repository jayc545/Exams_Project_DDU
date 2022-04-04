using UnityEditor;
using UnityEditor.XR.Interaction.Toolkit;

[CustomEditor(typeof(SocketWithTagCheck))]
public class SocketWithTagEditor : XRSocketInteractorEditor
{
    private SerializedProperty targetTag = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        targetTag = serializedObject.FindProperty("targetTag");
    }

    protected override void DrawBeforeProperties()
    {
        base.DrawBeforeProperties();
        EditorGUILayout.PropertyField(targetTag);
    }
}
