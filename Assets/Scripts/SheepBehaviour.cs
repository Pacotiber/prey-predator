using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    // Variables de la classe : on les DÉCLARE ici, sans les calculer
    [SerializeField, Min(0)] private float sheepspeed = 4f;   // degrés par seconde
    Quaternion targetrotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // On les CALCULE ici, une fois au début
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime*sheepspeed;
        if(transform.position.x>32f||transform.position.x<-32f)
        {
             Destroy(gameObject);
        }
        if(transform.position.z>32f||transform.position.z<-32f)
        {
             Destroy(gameObject);
        }
    }
}