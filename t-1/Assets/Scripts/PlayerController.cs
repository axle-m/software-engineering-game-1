using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction, dashAction, sprintAction, attackAction;
    private float xAxis, yAxis;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1.5f;
    private LayerMask enemyLayers;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Dash");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        attackAction = InputSystem.actions.FindAction("Attack");

        moveAction.Enable();
        dashAction.Enable();
        sprintAction.Enable();
        attackAction.Enable();

        enemyLayers = LayerMask.GetMask("Enemy");
        
        //find and initialize attack point
        attackPoint = gameObject.transform.GetChild(0);
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
        //flip with movement direction
        transform.localScale = new Vector3(xAxis == 0 ? transform.localScale.x : Mathf.Sign(xAxis) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        //update attack point
        float x = xAxis == 0 ? 0 : attackRange / 2;
        float y = yAxis == 0 ? 0 : Mathf.Sign(yAxis) * attackRange / 2;

        if(xAxis != 0 && yAxis != 0)
        {
            x = attackRange / 2 * 0.7f;
            y = Mathf.Sign(yAxis) * attackRange / 2 * 0.7f;
        }

        attackPoint.localPosition = new Vector3(x, y, 0);
    }

    void Move()
    {
        transform.position += new Vector3(xAxis, yAxis, 0) * moveSpeed * Time.deltaTime;
    }
}
