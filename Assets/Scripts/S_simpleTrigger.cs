using UnityEngine;
using UnityEngine.Events;

public class S_simpleTrigger : MonoBehaviour
{
    public UnityEvent onTriggerEvent = new UnityEvent();
    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag)
        {
            this.onTriggerEvent.Invoke();
            Destroy(this, 1f);
        }
    }
}
