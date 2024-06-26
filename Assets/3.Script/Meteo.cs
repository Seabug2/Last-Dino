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
    /// 떨어지는 속도
    /// </summary>
    [SerializeField, Tooltip("운석이 떨어지는 속도")]
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
