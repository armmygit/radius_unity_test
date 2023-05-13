using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 m_Offset;

    private Transform m_Player;

    private void Start()
    {
        m_Player = GameObject.FindObjectOfType<Player>().transform;
        Debug.Log(m_Player);
    }

    private void LateUpdate()
    {
        transform.position = m_Player.transform.position + m_Offset;
    }
}
