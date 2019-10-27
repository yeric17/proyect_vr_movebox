using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace GameScene
{
    public class SceneController : AutoCleanSingleton<SceneController>
    {
        [SerializeField] private ScenesInGame loadScene = ScenesInGame.load;
        [SerializeField] private ScenesInGame startScene = ScenesInGame.mainMenu;
        [SerializeField] Slider progressSlider = null;
        [SerializeField] TextMeshProUGUI percentageText = null;

        public SceneController sceneController;

        protected private void OnEnable() {
            PlayerPrefs.SetInt("NextScene", (int)ScenesInGame.mainMenu);
            
        }
        private void Start(){
            sceneController = Instance;
        }
        public void Load(int sceneIdx)
        {
            
            if (SceneManager.GetActiveScene().buildIndex != (int)loadScene)
            {
              // Debug.Log("NO es la pantalla de carga");
                PlayerPrefs.SetInt("NextScene", sceneIdx);
                SceneManager.LoadScene((int)loadScene);
            }
            else
            {
                // Debug.Log("Es la pantalla de carga");
                StartCoroutine(LoadSceneAsync(sceneIdx));
            }
        }
        IEnumerator LoadSceneAsync(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);

                if (percentageText)
                {
                    percentageText.text = progress * 100 + "%";
                }
                if (progressSlider)
                {
                    progressSlider.value = progress;
                }

                yield return null;
            }
        }

        public int GetStartScene(){
            return (int)startScene;
        }

    }
    enum ScenesInGame
    {
        load,
        mainMenu,
        testLevel
    }
}
