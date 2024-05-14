using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int maxCoins = 50;
    public int minCoins = 10;
    public float spawnInterval = 0.1f;

    private void Start()
    {
        StartCoroutine(SpawnCoinsWithDelay());
    }

    private IEnumerator SpawnCoinsWithDelay()
    {
        while (true)
        {
            int currentCoins = CountCoinsWithTag("Coin");
            if (currentCoins <= minCoins)
            {
                int coinsToSpawn = maxCoins - currentCoins;
                for (int i = 0; i < coinsToSpawn; i++)
                {
                    float xPositeon = Random.Range(-4f, 4f);
                    float yPositeon = Random.Range(2f, 4f);
                    float zPositeon = Random.Range(-4f, 4f);
                    Vector3 randomPosition = new Vector3(
                        xPositeon,
                        yPositeon,
                        zPositeon
                    );

                    Instantiate(coinPrefab, randomPosition, Quaternion.identity);
                    yield return new WaitForSeconds(spawnInterval);
                }
            }
            yield return null; // ŽŸ‚ÌƒtƒŒ[ƒ€‚Ü‚Å‘Ò‹@
        }
    }

    private int CountCoinsWithTag(string tag)
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag(tag);
        return coins.Length;
    }
}
