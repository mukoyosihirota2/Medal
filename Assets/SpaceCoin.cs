using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceCoin : MonoBehaviour
{
    public int Lifecoin = 50;
    public TextMeshProUGUI textcoin;
       
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // オブジェクトがトリガーコライダーに触れた時の処理
        Destroy(other.gameObject);
        Lifecoin += 1;
    }
    // Update is called once per frame
    void Update()
    {
        textcoin.text = "Lifecoin"+Lifecoin;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Lifecoin != 0)
            {
                float xPositeon = Random.Range(-4f, 4f);
                float yPositeon = Random.Range(4f, 6f);
                float zPositeon = Random.Range(-8f, -12f);
                Vector3 randomPosition = new Vector3(
                    xPositeon,
                    yPositeon,
                    zPositeon
                );

                Instantiate(coinPrefab, randomPosition, Quaternion.identity);
                Lifecoin--;
            }
        }
    }
}