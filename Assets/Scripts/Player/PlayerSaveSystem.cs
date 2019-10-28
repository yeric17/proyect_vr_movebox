using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSaveSystem : MonoBehaviour
{
    PlayerData playerData = null;
    string playerName = "default";

    Color color = Color.red;
    [SerializeField] Color[] avaibleColors = null;
    [SerializeField] TMP_InputField inputName = null;
    [SerializeField] TMP_Dropdown dropdownColors = null;

    private void Start()
    {
        if (PlayerPrefs.HasKey(playerName))
        {
            playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(playerName));
            playerName = playerData.playerName;
            color = playerData.lifeBarColor;
        }
    }
    public void Save()
    {
        string datos = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(playerName, datos);
    }

    public void ChangeName(){
        playerName = inputName.text;
    }

    public void ChangeColor() {
        SetColor(dropdownColors.value);
    }
    private void SetColor(int color){
        this.color = avaibleColors[color];
    }


}
