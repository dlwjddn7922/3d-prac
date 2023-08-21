using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    void Start()
    {
        
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
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMove(E_DirectionType.Up);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMove(E_DirectionType.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerMove(E_DirectionType.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerMove(E_DirectionType.Right);
        }
    }
}
