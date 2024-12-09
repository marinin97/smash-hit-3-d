using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] hallwayPrefabs;

    private GameObject previousHallway;
    private GameObject currentHallway;
    private GameObject lastHallway;

    private void Awake()
    {
        if (hallwayPrefabs != null)
        {
            int rnd = Random.Range(0, hallwayPrefabs.Length);
            currentHallway = Instantiate(hallwayPrefabs[rnd]);
            currentHallway.transform.position = transform.position;

            rnd = Random.Range(0, hallwayPrefabs.Length);

            lastHallway = Instantiate(hallwayPrefabs[rnd]);
            lastHallway.transform.position = currentHallway.GetComponent<Hallway>().Ending.position;
        }
    }

    public void BuildContinue()
    {
        if (previousHallway != null)
        {
            Destroy(previousHallway);
        }

        previousHallway = currentHallway;
        currentHallway = lastHallway;

        int rnd = Random.Range(0, hallwayPrefabs.Length);

        lastHallway = Instantiate(hallwayPrefabs[rnd]);
        lastHallway.transform.position = currentHallway.GetComponent<Hallway>().Ending.position;
    }
}
