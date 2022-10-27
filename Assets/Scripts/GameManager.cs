using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject alien_;

    public int score = 0;
    public int difficulty = 1;

    private bool can_spawn = true;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseDifficulty());
    }

    // Update is called once per frame
    void Update()
    {
        if(can_spawn)
        {
            StartCoroutine(SpawnTimer(growth_function(difficulty)));
        }
    }

    float growth_function(float x)
    {
        return 3.0f/(1.0f+Mathf.Exp((x-5.0f)*0.4f)) + 2.0f;
    }

    void SpawnBoss()
    {
        //Spawn Boss!
        Debug.Log("Spawning BBEG");
    }

    private IEnumerator SpawnTimer(float seconds)
    {
        can_spawn = false;
        yield return new WaitForSeconds(seconds);
        var position = new Vector2(12, Random.Range(-5.0f, 5.0f));

        Instantiate(alien_, position, Quaternion.identity);
        can_spawn = true;
    }

    private IEnumerator IncreaseDifficulty()
    {
        yield return new WaitForSeconds(3);
        difficulty++;
        if(difficulty > 100)
        {
            SpawnBoss();
        }
        else
        {
            StartCoroutine(IncreaseDifficulty());
        }

    }
}
