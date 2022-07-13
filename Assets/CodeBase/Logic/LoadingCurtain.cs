using DG.Tweening;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show() => Curtain.DOFade(1, 1f);

        public void Hide() => Curtain.DOFade(0, 1f);
    }
}