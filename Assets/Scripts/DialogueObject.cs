using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public float charPerSecond;
}

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Scriptables/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public Dialogue[] dialogues;
}
