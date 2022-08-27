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
        numberOfCoins = SaveGame.GetCoins();
    }

    void FixedUpdate()
    {
        RenderCoins();
    }

    private void RenderCoins()
    {
        coinsText.text = numberOfCoins.ToString();
    }

}
