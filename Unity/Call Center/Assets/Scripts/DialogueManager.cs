using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{

    private RectTransform dialogueBox = null;
    private Button btn = null;

    private TextMeshProUGUI textbox = null;
    [Header("Animation")]
    [SerializeField] private bool skipTextAnimation = false;
    [SerializeField] private float TextAnimationDuration = 3f;
    [SerializeField] private AnimationCurve dialogueBoxAnimCurve;
    [SerializeField] private float dialogueBoxAnimationDuration = 1.2f;
    [SerializeField] private float dialogueBoxStartPos = 512f;
    [SerializeField] private float dialogueBoxEndPos = -50;

    private UnityAction onDialogueEnd;
    private int currentDialogue = 0;
    private AudioSource voiceAS;
    private Dialogue[] dialogues = null;

    void Start()
    {
        dialogueBox = GameObject.Find("Canvas").transform.Find("dialogueBox").GetComponent<RectTransform>();
        btn = dialogueBox.Find("bg/nextButton").GetComponent<Button>();
        textbox = dialogueBox.Find("Textbox").GetComponent<TextMeshProUGUI>();
        voiceAS = GetComponent<AudioSource>();
        btn.onClick.AddListener(nextButton);
    }

    public void ShowDialogue(Dialogue[] dialogue, UnityAction p_onDialogueEnd = null)
    {
        dialogueBox.DOKill();
        textbox.text = "";
        dialogues = dialogue;
        onDialogueEnd = p_onDialogueEnd;
        dialogueBox.DOAnchorPosY(dialogueBoxEndPos, dialogueBoxAnimationDuration).SetEase(dialogueBoxAnimCurve).OnComplete(StartDialogue);
    }


    void StartDialogue()
    {
        textbox.SetText("");
        textbox.DOKill();
        textbox.DOText(dialogues[currentDialogue].npcDialogue, TextAnimationDuration).SetEase(Ease.InOutSine);
        voiceAS.Stop();
        if (dialogues[currentDialogue].npcVoice)
        {
            voiceAS.clip = dialogues[currentDialogue].npcVoice;
            voiceAS.Play();
        }

        currentDialogue++;
    }

    [ContextMenu("Next")]
    public void nextButton()
    {
        if (dialogues.IsNullOrEmpty()) return;
        if (currentDialogue == dialogues.Length)
        {

            HideDialogue();
            return;
        }
        StartDialogue();
    }

    [ContextMenu("HideDialogue")]
    public void HideDialogue()
    {
      
      
        currentDialogue = 0;
        dialogueBox.DOKill();
        voiceAS.Stop();
        dialogueBox.DOAnchorPosY(dialogueBoxStartPos, dialogueBoxAnimationDuration).SetEase(dialogueBoxAnimCurve).OnComplete(() =>
        {
            textbox.SetText("");
            onDialogueEnd?.Invoke();
            onDialogueEnd = null;
            dialogues = null;
        });

    }



}
