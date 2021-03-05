using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private Image fadeImg;

    void Start()
    {
        PlayerMovment player = FindObjectOfType<PlayerMovment>();
        player.enabled = false;
        fadeImg.color = new Color(0, 0, 0, 1);
        fadeImg.DOFade(0, fadeTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            player.enabled = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
