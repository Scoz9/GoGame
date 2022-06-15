using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [SerializeField] Text coinText;
    [SerializeField] int coins;

    private void Awake() { instance = this; }

    // Start is called before the first frame update
    void Start() {
        coins = PlayerPrefs.GetInt("COINS");
        coinText.text = coins.ToString();
    }

   public void AddCoins(int _coins) {
        coins += _coins;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("COINS", coins);
   }

    //public void PayCoins(int _coins) {} servirà per togliere monete

   /* public void SaveCoins() {
        PlayerPrefs.SetInt("COINS", coins);
        PlayerPrefs.Save();
    } */
}
