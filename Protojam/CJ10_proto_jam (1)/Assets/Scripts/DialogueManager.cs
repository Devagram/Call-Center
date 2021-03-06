using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{

	[SerializeField]private TextMeshProUGUI dialogueText;
	[SerializeField]private TextMeshProUGUI dialogueNPCName;
	[SerializeField]private TextMeshProUGUI interaction_Text;
	[SerializeField]private Button dialogueButton;
	[SerializeField]private RectTransform dialogueBox;
	[Header("Animation")]
	[SerializeField]private float anchorY= 248.75f;
	[SerializeField]private float dialogueBoxAnimationDuration=0.6f;
	[SerializeField]private AnimationCurve dialogueBoxAnimationCurve;	
	[SerializeField]private float textDuration=0.6f;
	private Dialogue[] dialogues;
	private int currentDialogue = 0;
	private AudioSource voiceAS;
	private UnityEvent onDialogueEnd;


	private void Start()
	{
		voiceAS = GetComponent<AudioSource>();
		dialogueButton.onClick.AddListener(nextButton);
	}
	[ContextMenu("ShowDialogue")]
	private void Test()
	{
		Dialogue[] d = new Dialogue[]
		{
			new Dialogue()
			{
				dialogueText="Uther: I entreat you old one, an evil more ancient than yourself has emerged in my homeland, we no longer possess the wisdoms to contend with it. I present my life as bargain for the bygone words that might bind and banish this evil. ",
				dialogueButtonText="hmmmm"
			},
			new Dialogue()
			{
				dialogueText="Guardian: Hmmm, yes I thought I smelt something awry in the west. I shall give you an old word, it will help you traverse the land at great speed, you may use it to seek out the spider god, whose memory is better than my own. Tell her Kimber the slothlord sent you. ",
				dialogueButtonText="ok"
			},
		};
		ShowDialogueBox(d);
	}
	public void ShowDialogueBox(Dialogue[] p_dialogues,string name="",UnityEvent p_onDialogueEnd= null)
	{
		currentDialogue = 0;
		onDialogueEnd = p_onDialogueEnd;
		dialogues = p_dialogues;
		dialogueText.text = "";
		dialogueBox.DOKill();
		dialogueBox.DOAnchorPosY(anchorY, dialogueBoxAnimationDuration).SetEase(dialogueBoxAnimationCurve).OnComplete(StartDialogue);
		dialogueNPCName.text = name;
	}

	void StartDialogue()
	{
		dialogueText.SetText("");
		dialogueText.DOKill();
		dialogueText.DOText(dialogues[currentDialogue].dialogueText, textDuration).SetEase(Ease.InOutSine);
		dialogueButton.GetComponentInChildren<TextMeshProUGUI>().text = dialogues[currentDialogue].dialogueButtonText;
		voiceAS.Stop();
		if (dialogues[currentDialogue].voice)
		{
			voiceAS.clip = dialogues[currentDialogue].voice;
			voiceAS.Play();
		}

		currentDialogue++;
	}

	[ContextMenu("Next")]
	public void nextButton()
	{
		if (currentDialogue == dialogues.Length)
		{
			onDialogueEnd?.Invoke();
			HideDialogu();
			return;
		}
		StartDialogue();
	}

	[ContextMenu("HideDialogue")]
	public void HideDialogu()
	{
		onDialogueEnd = null;
		dialogueNPCName.text = "";
		currentDialogue = 0;
		dialogueBox.DOKill();
		dialogueText.text = "";
		dialogueBox.DOAnchorPosY(-anchorY, dialogueBoxAnimationDuration).SetEase(dialogueBoxAnimationCurve);
	}




	public void ShowinteractionText()
	{
		interaction_Text.GetComponent<RectTransform>().DOKill();
		interaction_Text.DOKill();
		interaction_Text.GetComponent<RectTransform>().DOAnchorPosY(0, 0.4f).SetEase(Ease.InOutSine);
		interaction_Text.DOFade(1, 0.4f).SetEase(Ease.InOutSine);
	}
	public void HideinteractionText()
	{
		interaction_Text.GetComponent<RectTransform>().DOKill();
		interaction_Text.DOKill();
		interaction_Text.GetComponent<RectTransform>().DOAnchorPosY(-120, 0.6f).SetEase(Ease.InOutSine);
		interaction_Text.DOFade(0, 0.6f).SetEase(Ease.InOutSine);
	}
}
