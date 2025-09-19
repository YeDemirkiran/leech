using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string ownerID;
    [TextArea]
    public string dialogue;
    public float charPerSecond = -1f;
}

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Scriptables/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public Dialogue[] dialogues;
}
