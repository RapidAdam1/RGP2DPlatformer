using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public static UI Instance;
    public Text CoinText;
    public Health HealthContainer;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins(int Coins)
    {
      CoinText.text = "Coins: " + Coins.ToString();
    }

    public void UpdateHealth(int Health)
    {
        HealthContainer.UpdateHealth(Health);
    }
}
