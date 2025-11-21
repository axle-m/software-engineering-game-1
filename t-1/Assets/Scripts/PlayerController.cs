using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction, dashAction, sprintAction, attackAction;
    private float xAxis, yAxis;
    [SerializeField] private float moveSpeed = 5f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        // dashAction = InputSystem.actions.FindAction("Dash");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        attackAction = InputSystem.actions.FindAction("Attack");

        moveAction.Enable();
        // dashAction.Enable();
        sprintAction.Enable();
        attackAction.Enable();
    }

    void Update()
    {
        GetInput();
        UpdateState();
        Move();
    }

    void GetInput()
    {
        xAxis = moveAction.ReadValue<Vector2>().x;
        yAxis = moveAction.ReadValue<Vector2>().y;
    }

    void UpdateState()
    {
        
    }

    void Move()
    {
        transform.position += new Vector3(xAxis, yAxis, 0) * moveSpeed * Time.deltaTime;
    }
}
