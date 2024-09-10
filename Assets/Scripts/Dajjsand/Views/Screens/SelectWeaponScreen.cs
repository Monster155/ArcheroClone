using System;
using Dajjsand.Utils;
using Dajjsand.Utils.Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dajjsand.Views.Screens
{
    public class SelectWeaponScreen : MonoBehaviour
    {
        [SerializeField] private GunAndButton[] _gunAndButtons;

        private void Start()
        {
            foreach (GunAndButton gunAndButton in _gunAndButtons)
            {
                Button button = gunAndButton.Button;
                GunType gunType = gunAndButton.GunType;
                
                button.onClick.AddListener(() => SelectWeapon(gunType));
            }
        }

        private void SelectWeapon(GunType weaponType)
        {
            GlobalValues.SelectedGun = weaponType;
            SceneManager.LoadScene(0);
        }

        [Serializable]
        private class GunAndButton
        {
            public Button Button;
            public GunType GunType;
        }
    }
}