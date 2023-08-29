using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 1;
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private GameObject waterdeadEffect;
    [SerializeField] private GameObject raft;
    [SerializeField] private Transform raftPos;
    [SerializeField] private GameObject plane;
    public Map map;
    Animator anim;
    Rigidbody rb;
    bool isMove = false;
    bool isRaft = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        map.UpdateForwardBackMove((int)this.transform.position.z);
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
                offsetPos = (Vector3.forward * movementSpeed) + Vector3.up;               
                break;
            case E_DirectionType.Down:
                offsetPos = (Vector3.back * movementSpeed) + Vector3.up;
                break;
            case E_DirectionType.Left:
                offsetPos = (Vector3.left * movementSpeed) + Vector3.up;
                break;
            case E_DirectionType.Right:
                offsetPos = (Vector3.right * movementSpeed) + Vector3.up;
                break;
            default:
                Debug.LogErrorFormat("SetPlayerMove : Error{0}", p_moveType);
                break;
        }
        this.transform.position += offsetPos;
        map.UpdateForwardBackMove((int)this.transform.position.z);
    }

    void Update()
    {

        ControllPlayer();
        UpdateRaft();
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if(moveHorizontal == 0 || moveVertical == 0)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 planePos = Vector3.forward;
            if (Input.GetKeyDown(KeyCode.UpArrow) && !isMove)
            {
                isMove = true;
                PlayerMove(E_DirectionType.Up);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
                plane.transform.position += planePos;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)&& !isMove)
            {
                isMove = true;
                PlayerMove(E_DirectionType.Down);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMove)
            {
                isMove = true;
                PlayerMove(E_DirectionType.Left);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
                anim.SetInteger("Walk", 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && !isMove)
            {
                isMove = true;
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
    Vector3 raftoffsetPos = Vector3.zero;
    public void UpdateRaft()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 outraft = new Vector3(0f, 0f, 1.5f);
            this.transform.position = raft.transform.position + outraft;
            isRaft = false;
            raft = null;
            raftPos = null;

        }
        else if(isRaft == true)
        {
            Vector3 actorpos = raft.transform.position;
            this.transform.position = actorpos;
        }
        if (raft == null)
        {
            return;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Car"))
        {
            GameObject effect = Instantiate(deadEffect);
            effect.transform.position = transform.position;
            //Destroy(gameObject);
        }
        if (other.transform.CompareTag("Water"))
        {
            GameObject effect = Instantiate(waterdeadEffect);
            effect.transform.position = transform.position;
            //Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            isMove = false;
        }
        if (collision.transform.CompareTag("Raft"))
        {
            raft = collision.gameObject;
            raftPos = raft.transform;
            //raftoffsetPos = this.transform.position - raft.transform.position;            
            isRaft = true;            
            isMove = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.CompareTag("Raft"))
        {
            raftPos = null;
            raft = null;
            raftoffsetPos = Vector3.zero;
            isRaft = false;
        }
        
    }
}