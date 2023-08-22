using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private GameObject waterdeadEffect;
    Animator anim;
    Rigidbody rb;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    public enum E_DirectionType
    {
        Up = 0,
        Down,
        Left,
        Right
    }
    [SerializeField]
    protected E_DirectionType e_DirectionType = E_DirectionType.Up;
    protected void PlayerMove(E_DirectionType p_moveType)
    {
        Vector3 offsetPos = Vector3.zero;
        switch (p_moveType)
        {
            case E_DirectionType.Up:
                offsetPos = Vector3.forward;
                break;
            case E_DirectionType.Down:
                offsetPos = Vector3.back;
                break;
            case E_DirectionType.Left:
                offsetPos = Vector3.left;
                break;
            case E_DirectionType.Right:
                offsetPos = Vector3.right;
                break;
            default:
                Debug.LogErrorFormat("SetPlayerMove : Error{0}", p_moveType);
                break;
        }
        this.transform.position += offsetPos;
    }

    void Update()
    {

        ControllPlayer();
    }


    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if(moveHorizontal == 0 || moveVertical == 0)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayerMove(E_DirectionType.Up);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayerMove(E_DirectionType.Down);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PlayerMove(E_DirectionType.Left);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PlayerMove(E_DirectionType.Right);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if(other.transform.CompareTag("Car"))
        {
            GameObject effect = Instantiate(deadEffect);
            effect.transform.position = transform.position;
            Destroy(gameObject);
        }*/
        if (other.transform.CompareTag("Water"))
        {
            GameObject effect = Instantiate(waterdeadEffect);
            effect.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}