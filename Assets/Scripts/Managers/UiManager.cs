using Blended;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoSingleton<UiManager>
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI killingText;
    public Image healtBar;
    public GameObject levelFailUI;

    private void Start()
    {
        healtBar.fillAmount = GameManager.Instance.playerHealth;
        coinText.text = PlayerPrefs.GetInt("CoinAmount", GameManager.Instance.coinAmount).ToString();
        killingText.text = PlayerPrefs.GetInt("killingCount", GameManager.Instance.killingEnemies).ToString();
    }
}
