using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;

        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promtMessage = EditorGUILayout.TextField("Prompt message", interactable.promtMessage);
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }

            return;
        }
        base.OnInspectorGUI();

        if (interactable.useEvents && interactable.GetComponent<InteractionEvent>() == null)
        {
            interactable.gameObject.AddComponent<InteractionEvent>();
        } else if (interactable.TryGetComponent<InteractionEvent>(out var temp))
        {
            DestroyImmediate(temp);
        }
    }
}
