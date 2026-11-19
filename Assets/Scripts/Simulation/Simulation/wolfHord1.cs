using UnityEngine;

public class wolfHord1 : MonoBehaviour
{
    [SerializeField] private GameObject WolfPrefab;
    [SerializeField, Min(0)] private int nbWolf = 100;

    // Start est appelée une fois, avant le premier Update
    private void Start()
    {
        Spawn(WolfPrefab, nbWolf);
    }

    private void Spawn(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position = new(Random.Range(-32f, 32f), 0f, Random.Range(-32f, 32f));
            Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            Instantiate(prefab, position, rotation, transform);
        }
    }
}