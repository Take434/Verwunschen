using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DiceSpawn : MonoBehaviour
{
    public GameObject dicePrefab;
    public GameObject diceParent;
    public int timeToSpawn = 10;
    public int diceCount = 3;
    private float _a;
    private List<GameObject> _spawnedDice = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        dicePrefab = (GameObject)Resources.Load("Prefabs/Dice");
        _a = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (_a <= 0)
        {
            foreach(GameObject dice in _spawnedDice)
            {
                Destroy(dice);
            }
            
            for (int i = 0; i < diceCount; i++)
            {
                float x = Random.Range(-3f, 3f);
                float y = Random.Range(-3f, 3f);
                float z = Random.Range(-13f, -10f);
                GameObject dice = Instantiate(dicePrefab, new Vector3(x, y, z), Quaternion.Euler(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f)));
                dice.transform.SetParent(dicePrefab.transform);
                _spawnedDice.Add(dice);
            }
            _a = timeToSpawn;
        }
        else
        {
            _a -= Time.deltaTime;
        }
    }
}
