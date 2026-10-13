using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCController : MonoBehaviour
{
    public Transform targetTR;

    NavMeshAgent nav;

    // Start is called once before the first execution of Update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTR != null)
        {
            nav.SetDestination(targetTR.position);
        }
    }
}