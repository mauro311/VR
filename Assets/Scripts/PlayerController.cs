using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]

    [SerializeField] float speed;
    private float moveHorizontal;
    private float moveVertical;
    [SerializeField] CharacterController character;

    [Header("Jump")]

    [SerializeField] Transform checkedGround;
    private float graviity = -9.81f;
    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGround;
    [SerializeField] LayerMask layerCollision;
    [SerializeField] float radiusDetection;
    [SerializeField] int forceJump;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }


    void Update()
    {
        isGround = Physics.CheckSphere(checkedGround.position, radiusDetection, layerCollision);
        if (isGround && velocity.y < -2)
        {
            velocity.y = -2;
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(forceJump * -2 * graviity);
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        character.Move(move * speed * Time.deltaTime);

        velocity.y += graviity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkedGround.position, radiusDetection);
    }
}
