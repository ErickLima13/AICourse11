using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    private GameObject[] goalLocations;
    private NavMeshAgent agent;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        anim = GetComponent<Animator>();
        anim.SetFloat("wOffset", Random.Range(0, 1));
        anim.SetTrigger("isWalking");
        float sm = Random.Range(0.5f, 1);
        anim.SetFloat("speedMulti", sm);
        agent.speed *= sm;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
