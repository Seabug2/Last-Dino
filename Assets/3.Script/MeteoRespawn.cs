using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoRespawn : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Transform meteo;

    [SerializeField]
    float respwanHeight = 40f;

    [SerializeField]
    float respwanTerm = 1f;

    private void Start()
    {
        MeteoRain = StartCoroutine(MeteoRain_co());
    }

    Coroutine MeteoRain;

    IEnumerator MeteoRain_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(respwanTerm);
            Random.InitState(Time.frameCount);
            Transform m = Instantiate(meteo);
            m.position = Random.onUnitSphere * respwanHeight;
            m.gameObject.SetActive(true);
        }
    }
}
