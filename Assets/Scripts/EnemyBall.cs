using UnityEngine;
using DG.Tweening;


public class EnemyBall : MonoBehaviour
{
    public float moveSpeed;
    private Transform playerTransform;
    private Vector3 direction;

    private void Start()
    {
        playerTransform = GameManager.Instance.player.transform;
        direction = playerTransform.position - transform.position;
        direction += Vector3.up;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.playerHealth > 20)
            {
                GameManager.Instance.playerHealth -= 20;
                DOTween.To(() => UiManager.Instance.healtBar.fillAmount,
                    x => UiManager.Instance.healtBar.fillAmount = x,
                    UiManager.Instance.healtBar.fillAmount - 0.2f, 0.25f);
                Destroy(gameObject);
            }
            else
            {
                DOTween.To(() => UiManager.Instance.healtBar.fillAmount,
                    x => UiManager.Instance.healtBar.fillAmount = x,
                    0, 0.25f).SetUpdate(true);
                UiManager.Instance.levelFailUI.SetActive(true);
                PlayerController.Instance.playerAnimator.SetTrigger("Death");
                Time.timeScale = 0;
            }
        }
    }

    private void Update()
    {
        transform.Translate(direction * (Time.deltaTime * moveSpeed));
    }
}