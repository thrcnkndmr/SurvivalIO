using UnityEngine;
using DG.Tweening;

public class PlayerInteractions : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.coinAmount++;
            UiManager.Instance.coinText.text = GameManager.Instance.coinAmount.ToString();
            PlayerPrefs.SetInt("CoinAmount",  GameManager.Instance.coinAmount);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            if (GameManager.Instance.playerHealth<100)
            {
                GameManager.Instance.playerHealth += 20;
                DOTween.To(() => UiManager.Instance.healtBar.fillAmount,
                    x => UiManager.Instance.healtBar.fillAmount = x,
                    UiManager.Instance.healtBar.fillAmount + 0.2f, 0.25f);
                Destroy(other.gameObject);
            }
            
        }
    }
}