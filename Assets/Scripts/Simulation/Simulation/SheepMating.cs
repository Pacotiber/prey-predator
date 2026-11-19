using UnityEngine;

public class Sheep : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject sheepPrefab; 
    [SerializeField, Min(0)] private float sheepspeed = 0.1f;
    Quaternion targetrotation;
    float roatationSpeed = 90f;     
    static float catchDistance=0.1f;
    void Start()
    {   
        
    }
      // glisse Sheep.prefab ici dans l'Inspector

    void CreerMouton(Vector3 position,Quaternion rotation)
    {
        GameObject nouveauMouton = Instantiate(sheepPrefab, position, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        SheepBehaviour closestSheep = null;
        float closestSqrDist = float.MaxValue;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 180f);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out SheepBehaviour sheep))
            {
                Vector3 sheepmatingVector = sheep.transform.position - transform.position;
                sheepmatingVector.y = 0f;
                float sqrDist = sheepmatingVector.sqrMagnitude;
                if (sqrDist < closestSqrDist)
                {
                    closestSqrDist = sqrDist;
                    closestSheep = sheep;
                    if (sqrDist > 0.001f)
                        targetrotation = Quaternion.LookRotation(sheepmatingVector);
                }
            }
        }

        if (closestSheep != null && closestSqrDist < catchDistance * catchDistance)
        {
            CreerMouton(transform.position,transform.rotation);
        }

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, targetrotation, roatationSpeed * Time.deltaTime*sheepspeed);
    }
}
