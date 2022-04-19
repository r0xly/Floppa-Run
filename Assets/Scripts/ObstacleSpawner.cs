using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Mouse;
    public int MouseChance;
    public float SpawnRate;
    public GameObject[] Obstacles;
    public float SpawnPositionX;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(Random.Range(SpawnRate / 2, SpawnRate) / GameLoop.Speed);
        
        if (!GameLoop.Paused)
        {
            int chance = Random.Range(0, 100);
            var selectedObject = Obstacles[Random.Range(0, Obstacles.Length)];

            if (MouseChance >= chance && GameLoop.Health < GameLoop.MaxHealth)
                selectedObject = Mouse;

            var newObject = Instantiate(selectedObject, new Vector2(SpawnPositionX, selectedObject.transform.position.y), Quaternion.identity);
        }

        StartCoroutine(SpawnObstacle());
    }
}
