using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Objects;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<S_playerMovement>())
        {

            foreach (var item in Objects)
            {
                item.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)

    {
        if (other.GetComponent<S_playerMovement>())
        {

            foreach (var item in Objects)
            {
                item.SetActive(false);
            }
        }
    }

}
