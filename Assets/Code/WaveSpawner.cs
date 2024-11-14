using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSpawner;

public class WaveSpawner : MonoBehaviour
{
    private GameObject UIHolderOb;
    private UIMenus WonGame;


    [System.Serializable]
   
    public class WavesContent
    {
        [SerializeField] GameObject[] CreatureSpawner;

        public GameObject[] GetCreatureSpawnList()
        {
            return CreatureSpawner;
        }

    }

    [SerializeField] WavesContent[] waves;
    int currentWave = 0;
    float SpawnRangeZ = 5;
    float SpawnRangeX = 10;
    public List<GameObject> currentCreature;
    void Start()
    {
        UIHolderOb = GameObject.Find("Canvas");
        WonGame = UIHolderOb.GetComponent<UIMenus>();

        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCreature.Count == 0)
        {
            Debug.Log("next wave");
            currentWave++;
            SpawnWave();
        }
        if (currentWave == 3)
        {
            Debug.Log("We have won");
            WonGame.Won();
        }
    }

    void SpawnWave()
    {
        for(int i = 0; i < waves[currentWave].GetCreatureSpawnList().Length; i++)
        {
            
            GameObject newspawn = Instantiate(waves[currentWave].GetCreatureSpawnList()[i],FindSpawnLoc(),Quaternion.identity );
            currentCreature.Add(newspawn);

            NPControler monster = newspawn.GetComponent<NPControler>();
            monster.SetSpawner(this);
        }
    }

    Vector3 FindSpawnLoc()
    {
        Vector3 SpawnPos;

        float xLoc = Random.Range(-SpawnRangeX, SpawnRangeX) + transform.position.x;
        float zLoc = Random.Range(-SpawnRangeZ, SpawnRangeZ) + transform.position.z;
        float yloc = transform.position.y;

        SpawnPos = new Vector3(xLoc, yloc, zLoc);

        if (Physics.Raycast(SpawnPos, Vector3.down, 5))
        {
            return SpawnPos;
        }
        else
        {
            return FindSpawnLoc();
        }

    }
}
