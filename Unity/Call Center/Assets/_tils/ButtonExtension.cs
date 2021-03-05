using DG.Tweening;
//using HuntroxGames.Utils.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HuntroxGames.Utils
{
    public class ButtonExtension : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
    {

        [SerializeField] private DoScaleVars OnEnterAnimation;
        [SerializeField] private DoScaleVars OnExitAnimation;
        [SerializeField] private DoPunchScaleVars OnClickAnimation;
        //[SerializeField] private SoundClip OnClickSFX = new SoundClip();
        //[SerializeField] private SoundClip OnEnterSFX = new SoundClip();
    
        private Animator animator;
        private Button button;
        private void Start()
        {
            animator = GetComponent<Animator>();
            button = GetComponent<Button>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!button.interactable) return;
           //AudioController.PlaySoundClip(OnClickSFX);
            transform.DOPunchScale(OnClickAnimation.punchScale,
                OnClickAnimation.Duration,
                OnClickAnimation.Vibrato,
                OnClickAnimation.Elasticity).
                SetEase(OnClickAnimation.ease);//.OnComplete(() => target.localScale = Vector3.one);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
             //if (OnEnterSFX.clip != null)
                //AudioController.PlaySoundClip(OnEnterSFX);
            if (!button.interactable) return;
            transform.DOScale(OnEnterAnimation.Scale, OnEnterAnimation.Duration).SetEase(OnEnterAnimation.ease);

        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if (!button.interactable) return;
            transform.DOScale(OnExitAnimation.Scale, OnExitAnimation.Duration).SetEase(OnExitAnimation.ease);

        }




        [System.Serializable]
        public class DoScaleVars
        {
            public AnimationCurve ease;
            public float Scale;
            public float Duration;
        }

        [System.Serializable]
        public class DoPunchScaleVars
        {
            public AnimationCurve ease;
            public Vector3 punchScale;
            public int Vibrato;
            public float Elasticity;
            public float Duration;
        }
    }
}