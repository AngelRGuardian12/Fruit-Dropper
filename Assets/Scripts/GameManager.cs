using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //list
    public GameObject[] fruitList;
    //spawn wait time
    public int SpawnRate;
    //next fruit index
    private int upFruitRate;
    //fruit spawn
    public GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        upFruitRate = 0;
        SpawnNewFruit();
    }
    //function fruit spawn
    public void SpawnNewFruit()
    {
        StartCoroutine("CreateNewFruit");

    }

    //function that creates fruit objects
    IEnumerator CreateNewFruit()
    {
        yield return new WaitForSeconds(SpawnRate);

        GameObject fruitClone = Instantiate(fruitList[upFruitRate], SpawnPoint.transform.position, Quaternion.identity);

        fruitClone.GetComponent<Dragdrop>().dragBool = true;

        upFruitRate = 0;
    }
}
