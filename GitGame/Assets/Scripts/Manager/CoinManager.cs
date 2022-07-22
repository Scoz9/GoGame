using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    public int numberOfCoins;
    public static CoinManager instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
    }

    void FixedUpdate()
    {
        //SaveGame.SaveCoins(100);
        //numberOfCoins = SaveGame.GetCoins();
        RenderCoins();
    }

    private void RenderCoins()
    {
        coinsText.text = numberOfCoins.ToString();
    }

    /*public void SaveCoins()
    {
        SaveGame.SaveCoins(coins);
    }*/

    /*public bool RemoveMoney(int moneyToRemove)
    {
        if (moneyToRemove > coins)
        {
            return false;
        }
        coins -= moneyToRemove;
        RenderCoins();
        return true;
    }*/
}
