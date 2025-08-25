using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] float destroyInTime;
    private float currentTime;
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > destroyInTime)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
