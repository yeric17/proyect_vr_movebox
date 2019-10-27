using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GameScene {
    public class UIController : AutoCleanSingleton<UIController>
    {
        public UIController instace;
        [SerializeField] GameObject loadPanel = null;
        [SerializeField] GameObject mainMenuPanel = null;
        private void Start(){
            instace = Instance;
        }

        private void Update(){
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex((int)ScenesInGame.load)){
                if(loadPanel.activeSelf==false) loadPanel.SetActive(true);
            } 
            else {
                if(loadPanel.activeSelf) loadPanel.SetActive(false);
            }

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex((int)ScenesInGame.mainMenu)){
                if(mainMenuPanel.activeSelf == false) mainMenuPanel.SetActive(true);
            } 
            else {
                if(mainMenuPanel.activeSelf) mainMenuPanel.SetActive(false);
            }
        }
    }

}
