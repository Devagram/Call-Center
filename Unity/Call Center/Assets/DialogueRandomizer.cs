using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRandomizer : MonoBehaviour
{
    GameObject dialogueTexttoRandomize;
    // Start is called before the first frame update
    void Start()
    {
        dialogueTexttoRandomize = GameObject.Find("DialogueText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
