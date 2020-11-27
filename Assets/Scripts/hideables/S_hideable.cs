
using UnityEngine.Events;
using UnityEngine;

public class S_hideable : MonoBehaviour
{
    public GameObject player;
    S_hidding hidding;
    float playerHiddingDistance;

    public UnityEvent onPlayerEnterRange = new UnityEvent();
    public UnityEvent onPlayerExitRange = new UnityEvent();

    public Transform hidePosition;
    bool _onSights = false;

    public bool inverseHidding = true;

    private void Start()
    {
        hidding = player.GetComponent<S_hidding>();
        this.playerHiddingDistance = hidding.hideDistance;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= playerHiddingDistance)
        {
            onPlayerEnterRange.Invoke();
            hidding.hiddingTarget = this;
            _onSights = true;
        }
        else
        {
            if (_onSights)
            {
                onPlayerExitRange.Invoke();
                hidding.hiddingTarget = null;
                _onSights = false;
            }
        }
    }
}
