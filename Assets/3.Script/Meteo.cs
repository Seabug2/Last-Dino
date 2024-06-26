using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Meteo : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �������� �ӵ�
    /// </summary>
    [SerializeField, Tooltip("��� �������� �ӵ�")]
    float speed;

    private void FixedUpdate()

    {
        rb.AddForce(Vector3.Normalize(Vector3.zero - transform.position) * speed,ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent(out Dino dino))
        {
            Destroy(dino.gameObject);
        }

        else
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}
