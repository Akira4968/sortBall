using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        [SerializeField] GameObject _setting;
        [SerializeField] GameObject _ratepanel;
        [SerializeField] Animator _volume;
        [SerializeField] Animator _music;
        /*[SerializeField] Image _volumeOn;
        [SerializeField] Image _volumeOff;
        [SerializeField] Image _musicOn;
        [SerializeField] Image _musicOff;*/



        private void Awake()
        {
            Instance = this;
            _setting.SetActive(false);
            _ratepanel.SetActive(false);
           
        }
        public void OnClickPlay()
        {
            LoadScene("Level", true, 5f);
        }
        public static void LoadScene(string sceneName, bool showLoading = true, float loadingScreenSpeed = 5f)
        {
            var loadingPanel = SharedUIManager.LoadingPanel;
            if (showLoading && loadingPanel != null)
            {
                loadingPanel.Speed = loadingScreenSpeed;
                loadingPanel.Show(completed: () =>
                {
                    SceneManager.LoadScene(sceneName);
                    loadingPanel.Hide();
                });
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        public void Restart()
        {
            SceneManager.LoadScene("Level");
        }
        public void Setting()
        {
            _setting.SetActive(true);
        }
        public void CancelSetting()
        {
            _setting.SetActive(false);
        }
        public void CancelRate()
        {
            _ratepanel.SetActive(false);
            _setting.SetActive(true);
        }
        public void Volume()
        {
            _volume.SetBool("IsOn", !_volume.GetBool("IsOn"));
        }
        public void Music()
        {
            _music.SetBool("Ison", !_music.GetBool("Ison"));
        }
        public void RateUs()
        {
            _ratepanel.SetActive(true);
            _setting.SetActive(false);
        }
    }
}