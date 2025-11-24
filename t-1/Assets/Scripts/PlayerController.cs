using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction, dashAction, sprintAction, attackAction;
    private PlayerStateList playerStateList;
    private float xAxis, yAxis;
    [SerializeField] private float moveSpeed = 5f;

    #nullable enable
    private Transform ?attackPoint;
    [SerializeField] private float attackRange = 1.5f;
    private LayerMask enemyLayers;

    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashTimeMS = 200f;
    private float dashX, dashY;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (attackPoint != null) Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

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

        enemyLayers = LayerMask.GetMask("Enemy");
        
        //find and initialize attack point
        attackPoint =  new GameObject("AttackPoint").transform;
        attackPoint.transform.position = transform.position;

        playerStateList = new PlayerStateList();
    }


    void Update()
    {
        GetInput();
        UpdateState();
        Move();
        Dash();
        Attack();
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

        updateAttackDir();
    }

    void updateAttackDir()
    {
        Mouse mouse = Mouse.current;
        Vector2 mousePosition = mouse.position.ReadValue();
        Vector3 mouseScreen = new Vector3(mousePosition.x, mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z));
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 dir = (Vector2)mouseWorld - (Vector2)transform.position;

#pragma warning disable CS8602
    /*  Deference of a possibly null reference warning:
        OnDrawGizmos runs when attackPoint may be null.
        Making attackPoint nullable resolves the issue, but leads to annoying warnings so we suppress them temporarily. 
        This is to be removed once we no longer need to see gizmos for debugging. */

        attackPoint.position = transform.position + (Vector3)(dir.normalized * attackRange);
#pragma warning restore CS8602
    }

    void Move()
    {
        if(playerStateList.Dashing)
            transform.position += new Vector3(dashX, dashY, 0) * dashSpeed * Time.deltaTime;
        else if(sprintAction.IsPressed())
            transform.position += new Vector3(xAxis, yAxis, 0) * moveSpeed * 1.5f * Time.deltaTime;
        else transform.position += new Vector3(xAxis, yAxis, 0) * moveSpeed * Time.deltaTime;

    }

    void Dash()
    {
        if(dashAction.triggered && !playerStateList.Dashing)
            StartCoroutine(DashCoroutine());
    }
    private IEnumerator DashCoroutine()
    {
        float originalSpeed = moveSpeed;
        playerStateList.Dashing = true;
        moveSpeed = dashSpeed;
        dashX = xAxis;
        dashY = yAxis;
        yield return new WaitForSeconds(dashTimeMS / 1000f);
        moveSpeed = originalSpeed;
        playerStateList.Dashing = false;
    }

    void Attack()
    {
        if(attackAction.triggered)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        // Attack logic here
        Debug.Log("Attack triggered");

        yield return null;
    }
}
