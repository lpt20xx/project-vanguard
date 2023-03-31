using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    public Transform target;
    public NavMeshAgent agent;

    //patrol random point
    public float range;
    public Transform centrePoint;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    //animation
    public Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        this.GetNMAComponent();
    }

    private void GetNMAComponent()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        this.Patrolling();
        this.Chasing();
    }

    private void Patrolling()
    {
        agent.speed = patrolSpeed;
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            Vector3 point;
            if(RandomPoint(centrePoint.position, range, out point))
            {
                animator.SetBool("isWalk", true);
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
                
            }
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void Chasing()
    {

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= lookRadius)
        {
            agent.speed = chaseSpeed;

            agent.SetDestination(target.position);

            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", true);

            if(distance <= agent.stoppingDistance)
            {
                this.FaceTarget();
            }
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
