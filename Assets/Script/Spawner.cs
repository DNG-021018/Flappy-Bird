using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabs;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1.5f;

    public void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefabs, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
