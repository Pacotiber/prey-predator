using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    [SerializeField, Min(0)] private float wolfspeed = 4f;
    [SerializeField, Min(0)] private float catchDistance = 2f;

    float angle;
    float roatationSpeed = 90f;     // degrés par seconde
    float visionRadius = 20f;
    Quaternion targetrotation;

    void Start()
    {
        angle = Random.Range(0f, 360f);
        targetrotation = Quaternion.Euler(0f, angle, 0f);
    }

    void Update()
    {
        // Déclarés ICI : ils repartent de zéro à chaque image
        SheepBehaviour closestSheep = null;
        float closestSqrDist = float.MaxValue;

        Collider[] colliders = Physics.OverlapSphere(transform.position, visionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out SheepBehaviour sheep))
            {
                Vector3 sheepWolfVector = sheep.transform.position - transform.position;
                sheepWolfVector.y = 0f;
                float sqrDist = sheepWolfVector.sqrMagnitude;
                if (sqrDist < closestSqrDist)
                {
                    closestSqrDist = sqrDist;
                    closestSheep = sheep;
                    if (sqrDist > 0.001f)
                        targetrotation = Quaternion.LookRotation(sheepWolfVector);
                }
            }
        }

        if (closestSheep != null && closestSqrDist < catchDistance * catchDistance)
        {
            Destroy(closestSheep.gameObject);
        }

        transform.position += transform.forward * Time.deltaTime * wolfspeed;
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, targetrotation, roatationSpeed * Time.deltaTime);
    }
}