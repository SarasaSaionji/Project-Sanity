using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int collectedCoins, victoryCondition = 5;

    private static GameManager instance;

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        UImanager.MyInstance.UpdateCoinUI(collectedCoins, victoryCondition);
    }

    public void AddCoins(int _coins)
    {
        collectedCoins += _coins;
        UImanager.MyInstance.UpdateCoinUI(collectedCoins, victoryCondition);
        Debug.Log(_coins);
    }

    public void  Finish() 
    {
        if (collectedCoins >= victoryCondition)
        {
            SceneManager.LoadScene("True Ending");
        }
        else
        {
            UImanager.MyInstance.ShowVictoryCondition(collectedCoins,victoryCondition);
        }
    }
}
