using UnityEngine;

[System.Serializable]
public class Dialogue 
{
	public string npcName;
	[TextArea(1,10)]public string npcDialogue;
	public AudioClip npcVoice;
}
