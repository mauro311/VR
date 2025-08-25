using UnityEngine;
using UnityEngine.InputSystem;

public class VRwepon : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform target;
    [SerializeField] float fireRate;
    [SerializeField] float shootForce;
    private float nextFire;


    [SerializeField] InputAction fireAction;

    private void Awake()
    {
        fireAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        fireAction.Enable();
    }

    private void Update()
    {
        if (fireAction.ReadValue<float>() > 0 && Time.time >= nextFire)
        {
            Shoot();
            nextFire = Time.time + 0.5f / fireRate;
        }
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(prefab, target.position, target.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(target.forward * shootForce, ForceMode.Impulse);
        }
    }
    private void OnDestroy()
    {
        fireAction.Disable();
    }

}
