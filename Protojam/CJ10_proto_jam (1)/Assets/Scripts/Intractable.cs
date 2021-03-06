using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Intractable : MonoBehaviour
{


    [SerializeField] private string npcName;
    [SerializeField] private Dialogue[] dialogues;
    [SerializeField] private UnityEvent OnDialogueEnd;

    private DialogueManager dialogueManager;
    private bool interacted = false;
    

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }



    // Update is called once per frame
    void Update()
    {
        if(interacted && Input.GetKeyDown(KeyCode.E))
		{
            if (dialogues.Length > 0) 
                dialogueManager.ShowDialogueBox(dialogues, npcName, OnDialogueEnd);

            dialogueManager.HideinteractionText();
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("Player"))
		{
            interacted = true;
            dialogueManager.ShowinteractionText();
        }

	}
	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            interacted = false;
            dialogueManager.HideDialogu();
            dialogueManager.HideinteractionText();

        }
    }
}
