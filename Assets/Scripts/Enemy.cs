using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Die = Animator.StringToHash("Die");

    // Component
    private Animator m_Anim;
    private NavMeshAgent m_Agent;

    // Enemy
    private Transform m_Target;

    bool isHit = false;

    public Transform baseObj;
    private int baseDist = 10;
    private Vector3 starPos;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
        starPos = transform.position;
    }

    public void SetEnemy(Transform target){
        m_Target = target;
    }

    private void Update()
    {
        if(m_Target!=null){
          m_Agent.SetDestination(m_Target.position);

            float distance = Vector3.Distance(m_Target.position, transform.position);
            if(distance<=1){
                m_Anim.Play(Attack);
             }else{
                 m_Anim.Play(Walk);
             }

        }

         float distance2 = Vector3.Distance(baseObj.position, transform.position);
        //  Debug.Log("distance2: "+distance2);
          if(distance2>baseDist){
            m_Target = null;
            m_Anim.Play(Walk);
            m_Agent.SetDestination(starPos);
          }


        if(m_Target==null){
            float distance3 = Vector3.Distance(baseObj.position, transform.position);
            if(distance3<=1){
                m_Anim.Play(Idle);
            }
        }

    }
}