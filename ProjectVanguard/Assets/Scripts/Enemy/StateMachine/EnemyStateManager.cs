using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : StateMachineBehaviour
{

    [SerializeField] protected Transform player;
    [SerializeField] protected GameObject enemy;
    [SerializeField] protected Animator animator;

    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected List<Transform> patrolPoints = new List<Transform>();

    [SerializeField] protected float chaseRange = 10f;
    [SerializeField] protected float attackRange = 1.6f;
    [SerializeField] protected float timer;

    //[SerializeField] protected Animator animator;
    private void Awake()
    {
        this.GetComp();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Count)].position);
        
    }

    protected void GetComp()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("PatrolPoint");
        foreach (Transform t in obj.transform)
        {
            patrolPoints.Add(t);
        }

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        animator = enemy.GetComponent<Animator>();
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
