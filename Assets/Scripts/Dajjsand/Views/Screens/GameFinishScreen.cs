﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dajjsand.Views.Screens
{
    public class GameFinishScreen : MonoBehaviour
    {
        [SerializeField] private SelectWeaponScreen _selectWeaponScreen;
        [SerializeField] private Button _nextButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _maxShowTime = 1f;
        [SerializeField] private float _maxHideTime = 1f;

        private Coroutine _showCoroutine;
        private Coroutine _hideCoroutine;

        private void Start()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.gameObject.SetActive(false);
            _nextButton.onClick.AddListener(NextButton_OnClick);
        }

        public void Show()
        {
            if (_hideCoroutine != null)
                StopCoroutine(_hideCoroutine);
            _showCoroutine = StartCoroutine(ShowCoroutine());
        }

        public void Hide()
        {
            if (_showCoroutine != null)
                StopCoroutine(_showCoroutine);
            _hideCoroutine = StartCoroutine(HideCoroutine());
        }

        private IEnumerator ShowCoroutine()
        {
            _canvasGroup.gameObject.SetActive(true);

            float timer = _maxShowTime;
            while (timer > 0)
            {
                _canvasGroup.alpha = 1 - timer / _maxShowTime;
                timer -= Time.deltaTime;
                yield return null;
            }
            _canvasGroup.alpha = 1;

            _showCoroutine = null;
        }

        private IEnumerator HideCoroutine()
        {
            _canvasGroup.gameObject.SetActive(true);

            float timer = _maxHideTime;
            while (timer > 0)
            {
                _canvasGroup.alpha = timer / _maxHideTime;
                timer -= Time.deltaTime;
                yield return null;
            }
            _canvasGroup.alpha = 0;

            _hideCoroutine = null;
            
            _canvasGroup.gameObject.SetActive(false);
        }

        private void NextButton_OnClick() => _selectWeaponScreen.gameObject.SetActive(true);
    }
}