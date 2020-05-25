using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{

    public enum Difficulties { easy, normal, hard };
    public static Difficulties Difficulty = Difficulties.normal;
    public GameObject difficultyToggles;

   
    void Start()
    {
        difficultyToggles.transform.GetChild((int)Difficulty).GetComponent<Toggle>().isOn = true;
    }
 
    void Update()
    {
        
    }
    #region Difficulty

    public void SetEasyDifficulty(bool isOn)
    {
        if (isOn)
        {
            Difficulty = Difficulties.easy;
        }
    }
    public void SetNormalDifficulty(bool isOn)
    {
        if (isOn)
        {
            Difficulty = Difficulties.normal;
        }
    }
    public void SetHardDifficulty(bool isOn)
    {
        if (isOn)
        {
            Difficulty = Difficulties.hard;
        }
    }

    #endregion
}
