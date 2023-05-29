using Blended;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    private Pool pool;
    public Transform spawnPoint;
    public bool didIThrow;
    private int splinePointCount = 6;
    public GameObject boomerang;
    public float shotPower = 1f;


    private void Awake()
    {
        pool = Pool.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !didIThrow)
        {
            didIThrow = true;
            boomerang = pool.SpawnObject(spawnPoint.position, PoolItemType.Boomerang, null);
            Vector3[] path = new Vector3[splinePointCount];

            boomerang.GetComponent<TrailRenderer>().enabled = true;

            Vector3 targetDirection = (other.gameObject.transform.position - boomerang.transform.position).normalized;
            targetDirection += Vector3.up;
            Vector3 shotDirection = targetDirection + (targetDirection * 10);

            for (int i = 0; i < splinePointCount; i++)
            {
                float t = i / (float)(splinePointCount - 1);
                Vector3 pointPosition = Vector3.Lerp(spawnPoint.position, other.gameObject.transform.position, t) +
                                        shotDirection * Mathf.Sin(t * Mathf.PI);
                path[i] = pointPosition;
            }

            boomerang.transform.DOPath(path, shotPower, PathType.CatmullRom).SetOptions(true).SetLookAt(0.01f)
                .SetEase(Ease.Linear);
            Destroy(boomerang, 1f);
        }
    }

    private void Update()
    {
        if (boomerang == null)
        {
            didIThrow = false;
        }
    }
}