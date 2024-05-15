using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    public int Hp { get; private set; } = 4;

    public bool IsDead => Hp <= 0;
    
    [SerializeField] private Transform target;
    
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        CheckIfDead();
    }
    private void CheckIfDead()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
