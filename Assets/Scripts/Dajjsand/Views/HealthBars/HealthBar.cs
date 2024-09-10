using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dajjsand.Views.HealthBars
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _hpBarImage;
        
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        public void UpdatePos(Transform hpBarTarget)
        {
            Vector3 screenPos = _mainCamera.WorldToScreenPoint(hpBarTarget.position);
            ((RectTransform)transform).position = screenPos;
        }

        public void UpdateValue(float percent)
        {
            _hpBarImage.fillAmount = percent;
        }
    }
}