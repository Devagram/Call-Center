using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private AnimationCurve ppopupAnimation;
    [SerializeField] private Image Transition_BG;
    [SerializeField] private float ppopupAnimationDuration=0.6f;
    [SerializeField] private AudioSource source;
    [SerializeField] private float waitTime=7;
    [SerializeField] private float fadeTime=1.7f;
    [SerializeField] private float cameraMoveTimer=1.7f;
    [SerializeField] private Transform mainCamera;
    private bool pressed =false;
    IEnumerator Start()
    {
        startText.transform.localScale = Vector2.zero;
        yield return new WaitForSeconds(1f);
        RectTransform st = startText.GetComponent<RectTransform>();
        st.DOScale(1, ppopupAnimationDuration).SetEase(ppopupAnimation).OnComplete(() =>
        {
            st.DOScale(1.1f, 4f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        });
        DontDestroyOnLoad(source.gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !pressed)
        {
            StartCoroutine(ToMainLevel());
        }
        
    }

	IEnumerator ToMainLevel()
	{
        pressed = true;
        source.Play();
        startText.GetComponent<RectTransform>().DOKill();
        startText.DOFade(0, 0.8f).SetEase(Ease.InOutSine);
        startText.GetComponent<RectTransform>().DOLocalMoveY(-70, 1f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
   
        });
        yield return new WaitForSeconds(waitTime);
        mainCamera.DOMoveX(9, cameraMoveTimer).SetEase(Ease.InOutSine);
        Transition_BG.DOFade(1f, fadeTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            SceneManager.LoadSceneAsync(1);
        });

    }
}
