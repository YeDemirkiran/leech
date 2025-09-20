using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public enum Type { Dialogue, Delay };
    public Type type;

    [Header("Dialogue Settings")]
    public string ownerID;
    [TextArea]
    public string dialogue;
    public float charPerSecond = -1f;

    [Header("Delay Settings")]
    public float delay = 0f;
}

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Scriptables/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public Dialogue[] dialogues;
}
